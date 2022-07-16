using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Sellers;
using EXShop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.SellerPanel.Inventories;
public class IndexModel : BaseRazorPage
{
    private readonly ISellerService _sellerService;
    private readonly IRenderViewToString _renderViewToString;
    public IndexModel(ISellerService sellerService, IRenderViewToString renderViewToString)
    {
        _sellerService = sellerService;
        _renderViewToString = renderViewToString;
    }

    public List<InventoryDTO>? Inventories { get; set; }
    public async Task<IActionResult> OnGet()
    {
        var seller = await _sellerService.GetSellerByUserId();
        if (seller == null) return Redirect("/");

        Inventories = await _sellerService.GetSellerInventories();
        return Page();
    }

    public async Task<IActionResult> OnGetEditPage(long inventoryId)
    {
        return await AjaxTryCatch(async () =>
        {
            var inventory = await _sellerService.GetSellerInventoryById(inventoryId);
            if (inventory == null) return ApiResult<string>.Error("not found");
            var view = await _renderViewToString.RenderToStringAsync("_Edit", new EditSellerInventoryCommand
            {
                SellerId = inventory.SellerId,
                InventoryId = inventory.Id,
                Count = inventory.Count,    
                DiscountPercentage = inventory.DiscountPercentage,
                Price = inventory.Price,
            }, PageContext);
            return ApiResult<string>.Success(view);
        });
    }       
    public async Task<IActionResult> OnPost(EditSellerInventoryCommand command)
    {
        return await AjaxTryCatch(() => _sellerService.EditSellerInventory(command));
    }
}
    
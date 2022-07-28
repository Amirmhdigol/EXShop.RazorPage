using EXShop.RazorPage.Infrastructure;
using EXShop.RazorPage.Models.Orders;
using EXShop.RazorPage.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages;
public class ShopCartModel : BaseRazorPage
{
    private readonly IOrderService _orderService;
    public ShopCartModel(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public OrderDTO? OrderDto { get; set; }
    public async Task OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            OrderDto = await _orderService.GetCurrentOrder();
        }
        else
        {
            
        }
    }
    public async Task<IActionResult> OnPostDeleteItem(long id)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.RemoveOrderItem(new RemoveOrdertemCommand
            {
                ItemId = id
            }));
            return RedirectToPage("ShopCart");
        }
        else
        {
            return Page();
        }
    }

    public async Task<IActionResult> OnPostAddItem(long inventoryId, int count)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.AddOrderItem(new AddOrderItemCommand
            {
                UserId = User.GetUserId(),
                InventoryId = inventoryId,
                Count = count
            }));
        }
        else
        {
            return Page();
        }
    }
}
using EXShop.RazorPage.Models.Sellers;
using EXShop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.SellerPanel.Inventories;
[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly ISellerService _sellerService;
    public AddModel(ISellerService sellerService)
    {
        _sellerService = sellerService;
    }

    public long ProductId { get; set; }

    [Display(Name = "تعداد موجود")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Count { get; set; }

    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Price { get; set; }

    [Display(Name = "درصد تخفیف")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(0, 100, ErrorMessage = "درصد تخفیف نامعتبر است")]
    public int DiscountPercentage { get; set; }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPost()
    {
        var seller = await _sellerService.GetSellerByUserId();
        if (seller == null) return Redirect("/");

        var res = await _sellerService.AddSellerInventory(new AddSellerInventoryCommand
        {
            DiscountPercentage = DiscountPercentage,
            Count = Count,
            Price = Price,
            ProductId = ProductId,
            SellerId = seller.Id
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"));
    }
}
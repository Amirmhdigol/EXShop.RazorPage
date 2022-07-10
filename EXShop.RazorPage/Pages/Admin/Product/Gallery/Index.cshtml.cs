using EXShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using EXShop.RazorPage.Models.Products;
using EXShop.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Admin.Product.Gallery;
[BindProperties]
public class IndexModel : BaseRazorPage
{
    private readonly IProductService _productService;

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    public List<ProductImageDTO> Images { get; set; }

    [Display(Name = "ترتیب نمایش")]
    [Required(ErrorMessage = " {0} را وارد کنید")]
    public int Sequence { get; set; }

    [Display(Name = "عکس محصول")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile ImageFile { get; set; }

    public async Task<IActionResult> OnGet(long productId)
    {
        var product = await _productService.GetProductById(productId);
        if (product == null) return RedirectToPage("Index");

        Images = product.Images;
        return Page();
    }

    public async Task<IActionResult> OnPost(long productId)
    {
        return await AjaxTryCatch(() =>
        {
            return _productService.AddProductImage(new AddProductImageCommand
            {
                ProductId = productId,
                Sequence = Sequence,
                ImageFile = ImageFile
            });
        });
    }

    public async Task<IActionResult> OnPostDeleteItem(long productId, long id)
    {
        Sequence = 1;
        return await AjaxTryCatch(() => _productService.RemoveProductImage(new RemoveProductImageCommand
        {
            ProductId = productId,
            ImageId = id
        }), checkModelState: false);
    }
}
using EXShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using EXShop.RazorPage.Models.Products;
using EXShop.RazorPage.Services.Products;
using EXShop.RazorPage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Admin.Product;
[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly IProductService _productService;
    public EditModel(IProductService productService)
    {
        _productService = productService;
    }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(1, long.MaxValue, ErrorMessage = "دسته بندی را وارد کنید")]
    public long CategoryId { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [UIHint("ckeditor4")]
    public string Desciption { get; set; }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Slug { get; set; }

    [Display(Name = "زیردسته بندی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(1, long.MaxValue, ErrorMessage = "زیر دسته بندی را وارد کنید")]
    public long SubCategoryId { get; set; }

    [Display(Name = "زیردسته بندی دوم")]
    public long? SecondarySubCategoryId { get; set; }

    public SeoDataViewModel SeoData { get; set; }

    [Display(Name = "عکس محصول")]
    [FileImage(ErrorMessage = "عکس نامعتبر است")]
    public IFormFile? ImageFile { get; set; }

    //public Dictionary<string, string> Specifications { get; set; }
    public List<string> Keys { get; set; } = new();
    public List<string> Values { get; set; } = new();

    public async Task<IActionResult> OnGet(long productId)
    {
        var product = await _productService.GetProductById(productId);
        if (product == null) return RedirectToPage("Index");

        Title = product.Title;
        Slug = product.Slug;
        Desciption = product.Description;
        SeoData = SeoDataViewModel.MapSeoDataToViewModel(product.SeoData);
        CategoryId = product.Category.Id;
        SubCategoryId = product.SubCategory.Id;
        SecondarySubCategoryId = product.SecondrySubCategory?.Id;
        InitSpecifications(product.Specifications);
        return Page();
    }
    public void InitSpecifications(List<ProductSpecificationsDTO> specifications)
    {
        foreach (var specification in specifications)
        {
            Keys.Add(specification.Key);
            Values.Add(specification.Value);
        }
    }

    public async Task<IActionResult> OnPost(long productId)
    {
        var res = await _productService.Edit(new EditProductCommand
        {
            Title = Title,
            Slug = Slug,
            CategoryId = CategoryId,
            Description = Desciption,
            SecondrySubCategoryId = SecondarySubCategoryId,
            SeoData = SeoData.MapToSeoData(),
            ImageFile = ImageFile,
            ProductId = productId,
            SubCategoryId = SubCategoryId,
            Specifications = ConvertSpecifications()
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"));  
    }
    private Dictionary<string, string> ConvertSpecifications()
    {
        var specifications = new Dictionary<string, string>();
        Keys.RemoveAll(r => r == null || string.IsNullOrWhiteSpace(r));
        Values.RemoveAll(r => r == null || string.IsNullOrWhiteSpace(r));
        for (var i = 0; i < Keys.Count; i++)
        {
            specifications.Add(Keys[i], Values[i]);
        }
        return specifications;
    }
}


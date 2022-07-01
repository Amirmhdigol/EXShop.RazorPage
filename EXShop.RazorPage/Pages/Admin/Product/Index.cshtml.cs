using EXShop.RazorPage.Models.Products;
using EXShop.RazorPage.Services.Categories;
using EXShop.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace EXShop.RazorPage.Pages.Admin.Product;

public class IndexModel : BaseRazorFilter<ProductFilterParams>
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    public IndexModel(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public ProductFilterResult FilterResult { get; set; }
    public async Task OnGet()
    {
        FilterResult = await _productService.GetProductByFilter(FilterParams);
    }

    public async Task<IActionResult> OnGetLoadChildCategories(long parentId)
    {
        var options = "<option value='0'>انتخاب کنید</option>";
        var childs = await _categoryService.GetCategoryChilds(parentId);
        childs.ForEach(f =>
        {
            options += $"<option value='{f.Id}'>{f.Title}</option>";
        });
        return Content(options.Trim());
    }
}
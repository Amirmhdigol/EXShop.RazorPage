using EXShop.RazorPage.Models.Products;
using EXShop.RazorPage.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages;
public class SearchModel : PageModel
{
    private readonly IProductService _productService;
    public SearchModel(IProductService productService)
    {
        _productService = productService;
    }

    public ProductShopResult FilterResult { get; set; }

    public async Task OnGet(string category = "", bool? haveDiscount = null, int pageId = 1, string q = "", bool justAvailableProducts = true)
    {
        FilterResult = await _productService.GetProductsForShopByFilter(new ProductShopFilterParam
        {
            Take = 18,
            JustHasDiscount = haveDiscount,
            OnlyAvailableProducts = justAvailableProducts,
            PageId = pageId,
            Search = q,
            CategorySlug = category,
            SearchOrderBy = ProductSearchOrderBy.Latest
        });
    }
}
 
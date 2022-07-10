using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Products;

namespace EXShop.RazorPage.Services.Products;
public interface IProductService
{
    Task<ApiResult?> Create(CreateProductCommand command);
    Task<ApiResult?> Edit(EditProductCommand command);
    Task<ApiResult> AddProductImage(AddProductImageCommand command);
    Task<ApiResult> RemoveProductImage(RemoveProductImageCommand command);

    //Queries
    Task<ProductDTO?> GetProductById(long productId);
    Task<ProductFilterResult?> GetProductByFilter(ProductFilterParams filterParams);
    Task<ProductShopResult?> GetProductsForShopByFilter(ProductShopFilterParam filterParams);
    Task<ProductDTO?> GetProductBySlug(string slug);
}
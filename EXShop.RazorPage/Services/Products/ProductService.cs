using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Products;

namespace EXShop.RazorPage.Services.Products;

public class ProductService : IProductService
{
    private readonly HttpClient _client;

    public ProductService(HttpClient client)
    {
        _client = client;
    }

    public Task<ApiResult> AddProductImage(AddProductImageCommand command)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResult> Create(CreateProductCommand command)
    {
        var res = await _client.PostAsJsonAsync("product",command);
        
    }

    public Task<ApiResult> Edit(EditProductCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO?> GetProductById(long productId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO?> GetProductBySlug(string slug)
    {
        throw new NotImplementedException();
    }

    public Task<ProductShopResult> GetProductsForShopByFilter(ProductShopFilterParam filterParams)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResult> RemoveProductImage(RemoveProductImageCommand command)
    {
        throw new NotImplementedException();
    }
}
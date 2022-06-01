using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Products;
using Newtonsoft.Json;
using System.Text;

namespace EXShop.RazorPage.Services.Products;

public class ProductService : IProductService
{
    private readonly HttpClient _client;
    private const string ModuleName = "product";

    public ProductService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ApiResult?> AddProductImage(AddProductImageCommand command)
    {
        var formData = new MultipartFormDataContent
        {
            { new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName },
            { new StringContent(command.Sequence.ToString()), "Sequence" },
            { new StringContent(command.ProductId.ToString()), "ProductId" }
        };

        var result = await _client.PostAsync($"{ModuleName}/images", formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> Create(CreateProductCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Slug), "Slug");
        formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        formData.Add(new StringContent(command.Title), "Title");
        formData.Add(new StringContent(command.Description), "Description");
        formData.Add(new StringContent(command.CategoryId.ToString()), "CategoryId");
        formData.Add(new StringContent(command.SubCategoryId.ToString()), "SubCategoryId");
        formData.Add(new StringContent(command.SecondrySubCategoryId.ToString() ?? string.Empty), "SecondrySubCategoryId");
        formData.Add(new StringContent(command.SeoData.MetaTitle), "SeoData.MetaTitle");
        formData.Add(new StringContent(command.SeoData.Canonical), "SeoData.Canonical");
        formData.Add(new StringContent(command.SeoData.MetaKeyWords), "SeoData.MetaKeyWords");
        formData.Add(new StringContent(command.SeoData.MetaDescription), "SeoData.MetaDescription");
        formData.Add(new StringContent(command.SeoData.IndexPage.ToString()), "SeoData.IndexPage");
        formData.Add(new StringContent(command.SeoData.Schema), "SeoData.Schema");

        var specifications = JsonConvert.SerializeObject(command.Specifications);
        formData.Add(new StringContent(specifications, Encoding.UTF8, "application/json"), "Specifications");

        var result = await _client.PostAsync(ModuleName, formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> Edit(EditProductCommand command)
    {
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(command.Slug), "Slug");
        formData.Add(new StringContent(command.ProductId.ToString()), "ProductId");
        if (command.ImageFile != null)
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
        formData.Add(new StringContent(command.Title), "Title");
        formData.Add(new StringContent(command.Description), "Description");
        formData.Add(new StringContent(command.CategoryId.ToString()), "CategoryId");
        formData.Add(new StringContent(command.SubCategoryId.ToString()), "SubCategoryId");
        formData.Add(new StringContent(command.SecondrySubCategoryId.ToString() ?? string.Empty), "SecondrySubCategoryId");
        formData.Add(new StringContent(command.SeoData.MetaTitle), "SeoData.MetaTitle");
        formData.Add(new StringContent(command.SeoData.Canonical), "SeoData.Canonical");
        formData.Add(new StringContent(command.SeoData.MetaKeyWords), "SeoData.MetaKeyWords");
        formData.Add(new StringContent(command.SeoData.MetaDescription), "SeoData.MetaDescription");
        formData.Add(new StringContent(command.SeoData.IndexPage.ToString()), "SeoData.IndexPage");
        formData.Add(new StringContent(command.SeoData.Schema), "SeoData.Schema");

        var specifications = JsonConvert.SerializeObject(command.Specifications);
        formData.Add(new StringContent(specifications, Encoding.UTF8, "application/json"), "Specifications");

        var result = await _client.PutAsync(ModuleName, formData);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ProductFilterResult?> GetProductByFilter(ProductFilterParams filterParams)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<ProductFilterResult>>($"product?filterparams={filterParams}");
        return res?.Data;
    }

    public async Task<ProductDTO?> GetProductById(long productId)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<ProductDTO>>($"product/{productId}");
        return res?.Data;
    }

    public async Task<ProductDTO?> GetProductBySlug(string slug)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<ProductDTO>>($"product/{slug}");
        return res?.Data;
    }

    public async Task<ProductShopResult?> GetProductsForShopByFilter(ProductShopFilterParam filterParams)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<ProductShopResult>>($"product?filterparams={filterParams}");
        return res?.Data;
    }

    public async Task<ApiResult?> RemoveProductImage(RemoveProductImageCommand command)
    {
        var json = JsonConvert.SerializeObject(command);
        var message = new HttpRequestMessage(HttpMethod.Delete, $"{ModuleName}/images")
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        var result = await _client.SendAsync(message);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }
}
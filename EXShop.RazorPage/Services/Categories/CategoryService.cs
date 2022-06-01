using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Categories;

namespace EXShop.RazorPage.Services.Categories;

public class CategoryService : ICategoryService
{
    private HttpClient _client;

    public CategoryService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ApiResult?> AddChild(AddChildCategoryCommand command)
    {
        var result = await _client.PostAsJsonAsync("Category/addchild", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> CreateCategory(CreateCategoryCommand command)
    {
        var result = await _client.PostAsJsonAsync("Category", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> DeleteCategory(long categoryId)
    {
        var result = await _client.DeleteAsync($"Category/{categoryId}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> EditCategory(EditCategoryCommand command)
    {
        var result = await _client.PutAsJsonAsync("Category", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();

    }

    public async Task<List<CategoryDTO>?> GetCategories()
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<CategoryDTO>>>("category");
        return result?.Data;
    }

    public async Task<CategoryDTO?> GetCategoryById(long categoryId)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<CategoryDTO>>($"category/{categoryId}");
        return result?.Data;
    }

    public async Task<List<ChildCategoryDTO>?> GetCategoryChilds(long parentId)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<List<ChildCategoryDTO>>>($"category/getChild/{parentId}");
        return result?.Data;
    }
}
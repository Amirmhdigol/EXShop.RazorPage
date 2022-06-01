using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Categories;

namespace EXShop.RazorPage.Services.Categories;

public interface ICategoryService
{
    Task<ApiResult?> CreateCategory(CreateCategoryCommand command);
    Task<ApiResult?> EditCategory(EditCategoryCommand command);
    Task<ApiResult?> DeleteCategory(long categoryId);
    Task<ApiResult?> AddChild(AddChildCategoryCommand command); 

    Task<CategoryDTO?> GetCategoryById(long categoryId);
    Task<List<CategoryDTO>?> GetCategories();
    Task<List<ChildCategoryDTO>?> GetCategoryChilds(long parentId);
}
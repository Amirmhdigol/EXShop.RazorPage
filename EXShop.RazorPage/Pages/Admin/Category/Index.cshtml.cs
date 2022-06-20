using EXShop.RazorPage.Models.Categories;
using EXShop.RazorPage.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Admin.Category
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ICategoryService _categoryService;

        public IndexModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<CategoryDTO> Categories { get; set; }
        public async Task OnGet()
        {
            Categories = await _categoryService.GetCategories();
        }

        public async Task<IActionResult> OnPostDelete(long categoryId)
        {
            return await AjaxTryCatch(async () =>
            {
                return await _categoryService.DeleteCategory(categoryId);
            });
        }
    }
}
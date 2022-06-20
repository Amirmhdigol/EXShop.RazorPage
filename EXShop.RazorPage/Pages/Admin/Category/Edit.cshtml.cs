using EXShop.RazorPage.Models.Categories;
using EXShop.RazorPage.Services.Categories;
using EXShop.RazorPage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Admin.Category;    
[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly ICategoryService _categoryService;

    public EditModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Slug { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }
    public SeoDataViewModel? SeoData { get; set; }
    public async Task<IActionResult> OnGet(long id)
    {
        var category = await _categoryService.GetCategoryById(id);
        if (category == null)
            return RedirectToPage("Index");

        Title = category.Title;
        Slug = category.Slug;
        SeoData = SeoDataViewModel.MapSeoDataToViewModel(category.SeoData);

        return Page();
    }

    public async Task<IActionResult> OnPost(long id)
    {
        var res = await _categoryService.EditCategory(new EditCategoryCommand()
        {
            Id = id,
            Title = Title,
            SeoData = SeoData.MapToSeoData(),
            Slug = Slug
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"));
    }
}
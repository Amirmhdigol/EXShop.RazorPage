using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Categories;
using EXShop.RazorPage.Services.Categories;
using EXShop.RazorPage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Admin.Category;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly ICategoryService _categoryService;
    public AddModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Slug { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "SeoData")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public SeoDataViewModel SeoData { get; set; }
    public void OnGet()
    {

    }
    public async Task<IActionResult> OnPost(long? parentId)
    {
        if (parentId == null)
        {
            var result = await _categoryService.CreateCategory(new CreateCategoryCommand
            {
                Title = Title,
                Slug = Slug,
                SeoData = new SeoData
                {
                    MetaTitle = SeoData.MetaTitle,
                    MetaDescription = SeoData.MetaDescription,
                    Canonical = SeoData.Canonical,
                    Schema = SeoData.Schema,
                    IndexPage = (bool)SeoData.IndexPage,
                    MetaKeyWords = SeoData.MetaKeyWords,
                }
            });
            return RedirectAndShowAlert(result, RedirectToPage("Index"));
        }
        var res = await _categoryService.AddChild(new AddChildCategoryCommand
        {
            ParentId = (long)parentId,
            Title = Title,
            Slug = Slug,
            SeoData = new SeoData
            {
                MetaTitle = SeoData.MetaTitle,
                MetaDescription = SeoData.MetaDescription,
                Canonical = SeoData.Canonical,
                Schema = SeoData.Schema,
                IndexPage = (bool)SeoData.IndexPage,
                MetaKeyWords = SeoData.MetaKeyWords,
            }
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"));
    }
}
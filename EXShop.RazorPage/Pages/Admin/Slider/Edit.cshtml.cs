using EXShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using EXShop.RazorPage.Models.Sliders;
using EXShop.RazorPage.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Admin.Slider;

[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly ISliderService _sliderService;
    public EditModel(ISliderService sliderService)
    {
        _sliderService = sliderService;
    }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "لینک")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [DataType(DataType.Url)]
    public string Url { get; set; }

    [Display(Name = "عکس اسلایدر")]
    [FileImage(ErrorMessage = "عکس نامعتبر")]
    public IFormFile? ImageFile { get; set; }
    public string ImageName { get; set; }

    public async Task<IActionResult> OnGet(long id)
    {
        var slider = await _sliderService.GetSliderById(id);
        if (slider == null) return RedirectToPage("Index");

        Title = slider.Title;
        Url = slider.Link;
        ImageName = slider.ImageName;

        return Page();
    }
    public async Task<IActionResult> OnPost(long id)
    {
        var res = await _sliderService.EditSlider(new EditSliderCommand
        {
            Id = id,
            ImageFile = ImageFile,
            Title = Title,
            Link = Url
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"));
    }
}
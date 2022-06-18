using EXShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using EXShop.RazorPage.Models.Sliders;
using EXShop.RazorPage.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Admin.Slider;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly ISliderService _sliderService;
    public AddModel(ISliderService sliderService)
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
    public IFormFile ImageFile { get; set; }

    public void OnGet()
    {

    }
    public async Task<IActionResult> OnPost()
    {
        var res = await _sliderService.CreateSlider(new CreateSliderCommand
        {
            Title = Title,
            Link = Url,
            ImageFile = ImageFile
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"));
    }
}
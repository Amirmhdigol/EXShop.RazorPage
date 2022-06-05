using System.ComponentModel.DataAnnotations;
using EXShop.RazorPage.Models.Users;
using EXShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Profile;

[BindProperties]
[Authorize]
public class ChangePasswordModel : BaseRazorPage
{
    private readonly IUserService _userService;
    public ChangePasswordModel(IUserService userService)
    {
        _userService = userService;
    }

    [Display(Name = "کلمه عبور فعلی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; }

    [Display(Name = "کلمه عبور فعلی")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "تکرار کلمه عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Compare(nameof(Password), ErrorMessage = "کلمه های عبور یکسان نیستند")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
   
    
    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPost()
    {
        var result = await _userService.ChangeUserPassword(new ChangePasswordCommand()
        {
            CurrentPassword = CurrentPassword,
            Password = Password,
            ConfirmPassword = ConfirmPassword
        });
        return RedirectAndShowAlert(result,RedirectToPage("Index"));
    }
}
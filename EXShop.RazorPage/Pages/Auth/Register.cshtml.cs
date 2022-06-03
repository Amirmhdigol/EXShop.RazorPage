global using EXShop.RazorPage.Infrastructure.RazorUtil;
using EXShop.RazorPage.Models.Auth;
using EXShop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Auth;

[BindProperties]
[ValidateAntiForgeryToken]
public class RegisterModel : BaseRazorPage
{
    private readonly IAuthService _authService;

    public RegisterModel(IAuthService authService)
    {
        _authService = authService;
    }

    [DisplayName("شماره تلفن"),
     Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [DisplayName("رمز"),
    Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(5, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DisplayName("تکرار رمز"),
    Required(ErrorMessage = "{0} را وارد کنید"),
        Compare("Password", ErrorMessage = "کلمه های عبور یکسان نیستند")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }

    public void OnGet()
    {

    }
    public async Task<IActionResult> OnPost()
    {
        var result = await _authService
            .Register(new RegisterCommand() { PhoneNumber = PhoneNumber, Password = Password, ConfirmPassword = ConfirmPassword });

        return RedirectAndShowAlert(result, RedirectToPage("Login"));
    }
}
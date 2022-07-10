using EXShop.RazorPage.Models.Auth;
using EXShop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Auth;

[BindProperties]
[ValidateAntiForgeryToken]
public class LoginModel : BaseRazorPage
{
    private readonly IAuthService _authService;

    public LoginModel(IAuthService authService)
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
    public string? RedirectTo { get; set; }

    public IActionResult OnGet(string? redirectTo)
    {
        if (User.Identity.IsAuthenticated) return Redirect("/");

        if (redirectTo != null) RedirectTo = redirectTo;

        return Page();
    }
    public async Task<IActionResult> OnPost()
    {
        var res = await _authService.Login(new Models.Auth.LoginCommand { PhoneNumber = PhoneNumber, Password = Password });

        if (res.IsSuccess == false)
        {
            ModelState.AddModelError(nameof(PhoneNumber), res.MetaData.Message);
            return Page();
        }
        var token = res.Data.Token;
        var Retoken = res.Data.RefreshToken;

        HttpContext.Response.Cookies.Append("token", token,new CookieOptions
        {
            HttpOnly = true,
            Expires= DateTimeOffset.Now.AddDays(7),
        });
        HttpContext.Response.Cookies.Append("Refreshtoken", Retoken, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddDays(10),
        });

        if (!string.IsNullOrWhiteSpace(RedirectTo)) return LocalRedirect(RedirectTo);

        return Redirect("/");
    }
}
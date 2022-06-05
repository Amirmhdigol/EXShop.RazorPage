using EXShop.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Auth;

public class LogOutModel : BaseRazorPage
{
    private readonly IAuthService _service;
    public LogOutModel(IAuthService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        var res = await _service.LogOut();
        if (res.IsSuccess)
        {
            HttpContext.Response.Cookies.Delete("token");
            HttpContext.Response.Cookies.Delete("refresh-token");
        }
        return RedirectAndShowAlert(res, RedirectToPage("../Index"));
    }
}
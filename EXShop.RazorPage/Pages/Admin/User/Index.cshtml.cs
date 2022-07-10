using EXShop.RazorPage.Models.Roles;
using EXShop.RazorPage.Models.Users;
using EXShop.RazorPage.Services.Roles;
using EXShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Admin.User;
public class IndexModel : BaseRazorFilter<UserFilterParams>
{
    private readonly IUserService _userService;
    public IndexModel(IUserService userService)
    {
        _userService = userService;
    }
    public UserFilterResult FilterResult { get; set; }
    public async Task OnGet()
    {
        FilterResult = await _userService.GetUserByFilter(FilterParams);
    }

    public async Task<IActionResult> OnPostDeleteUser(long userId)
    {
        return await AjaxTryCatch(() =>
        {
            return _userService.DeleteUser(userId);
        });
    }
}
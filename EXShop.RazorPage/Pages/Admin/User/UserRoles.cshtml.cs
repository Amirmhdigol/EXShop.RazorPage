using EXShop.RazorPage.Models.Roles;
using EXShop.RazorPage.Services.Roles;
using EXShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Admin.User;
[BindProperties]
public class UserRolesModel : BaseRazorPage
{
    private readonly IUserService _userService;
    public UserRolesModel(IUserService userService)
    {
        _userService = userService;
    }

    public RoleDTO Permissions { get; set; }
    //public List<string> Permissionn { get; set; } = new();

    public async Task OnGetAsync(long userId)
    {
        var a = await _userService.GetUserRoles(userId);
        var b =  a.FirstOrDefault();
        Permissions = b;

        //var c = b.Permissions.ToList().ToString();
        //var e = b.Permissions.Count;
        //for (int i = 0; i < e; i++)
        //{
        //    var h = c[i];
        //    Permissionn.Add(h.ToString());
        //}
        //Permissionn = c.FirstOrDefault().ToString();
    }
}
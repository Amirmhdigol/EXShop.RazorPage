using EXShop.RazorPage.Models.Roles;
using EXShop.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Admin.Role;
[BindProperties]
public class IndexModel : BaseRazorPage
{
    private readonly IRoleService _roleService;
    public IndexModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public List<RoleDTO> Roles { get; set; }

    public async Task OnGet()
    {
        Roles = await _roleService.GetRoles();
    }

    //public async Task<IActionResult> OnPostDelete(long id)
    //{
    //    return await AjaxTryCatch(() =>
    //    { 
    //        _roleService.
    //    });
    //}
}
using EXShop.RazorPage.Models.Roles;
using EXShop.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Admin.Role;
[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly IRoleService _roleService;
    public EditModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public string Title { get; set; }
    public List<Permission> Permissioms { get; set; }

    public async Task<IActionResult> OnGet(long id)
    {
        var role = await _roleService.GetRoleById(id);
        if (role == null) return RedirectToPage("Index");

        Title = role.Title;
        Permissioms = role.Permissions;
        return Page();
    }

    public async Task<IActionResult> OnPost(long id, List<Permission> permissions)
    {
        var res = await _roleService.EditRole(new EditRoleCommand
        {
            Permissions = permissions,
            Id = id,
            Title = Title
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"), RedirectToPage("Edit", new { id }));
    }
}
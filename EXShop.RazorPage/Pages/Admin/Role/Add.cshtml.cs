using EXShop.RazorPage.Infrastructure.Utils;
using EXShop.RazorPage.Models.Roles;
using EXShop.RazorPage.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Admin.Role;
[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly IRoleService _roleService;

    public AddModel(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string  Title { get; set; }
    public List<Permission> Permissions { get; set; }

    public void OnGet()
    {
    }
    
    public async Task<IActionResult> OnPost(string[] permission)
    {
        var permissionModel = new List<Permission>();
        foreach (var item in permission)
        {
            permissionModel.Add(EnumUtils.ParseEnum<Permission>(item));
        }
        var res = await _roleService.CreateRole(new CreateRoleCommand
        {
            Title =Title,
            Permissions = permissionModel
        });
        return RedirectAndShowAlert(res,RedirectToPage("Index"));
    }
}
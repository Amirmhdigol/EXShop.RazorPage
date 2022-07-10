using EXShop.RazorPage.Models.Users;
using EXShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
namespace EXShop.RazorPage.Pages.Admin.User;

[BindProperties]
public class AddModel : BaseRazorPage
{
    private readonly IUserService _userService;
    public AddModel(IUserService userService)
    {
        _userService = userService;
    }
    [Display(Name = "نام")]
    public string? Name { get; set; }

    [Display(Name = "نام خانوادگی")]
    public string? Family { get; set; }

    [Display(Name = "رمز عبور")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "ایمیل")]
    public string? Email { get; set; }

    [Display(Name = "جنسیت")]
    public Gender Gender { get; set; }

    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [Display(Name = "نقش")]
    [Required(ErrorMessage = "نقش را وارد کنید")]
    public long RoleId { get; set; }

    public void OnGet() 
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var res = await _userService.CreateUser(new CreateUserCommand
        {
            Name = Name,
            Family = Family,
            Password = Password,
            Email = Email,
            Gender = Gender,
            PhoneNumber = PhoneNumber,
            RoleId = RoleId,
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"));
    }
}
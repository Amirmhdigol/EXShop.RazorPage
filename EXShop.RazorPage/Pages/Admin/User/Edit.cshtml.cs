using EXShop.RazorPage.Infrastructure.Utils.CustomValidation.IFormFile;
using EXShop.RazorPage.Models.Users;
using EXShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Pages.Admin.User;
[BindProperties]
public class EditModel : BaseRazorPage
{
    private readonly IUserService _userService;
    public EditModel(IUserService userService)
    {
        _userService = userService;
    }

    [Display(Name = "نام")]
    public string? Name { get; set; }

    [Display(Name = "نام خانودگی")]
    public string? Family { get; set; }

    [Display(Name = "ایمیل")]
    public string? Email { get; set; }

    [Display(Name = "تصویر پروفایل")]
    [FileImage(ErrorMessage = "not valid image")]
    public IFormFile? ImageFile { get; set; }

    [Display(Name = "ژنسیت")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public Gender Gender { get; set; }

    [Display(Name = "کاربر فعال است؟")]
    public bool IsActive { get; set; }

    [Display(Name = "شماره همراه")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [Display(Name = "نقش")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public long RoleId { get; set; }

    public async Task<IActionResult> OnGet(long userId)
    {
        var user = await _userService.GetUserById(userId);
        if (user == null) return RedirectToPage("Index");

        Name = user.Name;
        Family = user.Family;
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        IsActive = user.IsActive;
        Gender = user.Gender;
        RoleId = user.RoleId;
        return Page();
    }

    public async Task<IActionResult> OnPost(long userId)
    {
        var res = await _userService.EditUser(new EditUserCommand
        {
            UserId = userId,
            Name = Name,
            Family = Family,
            Avatar = ImageFile,
            Email = Email,
            IsActive = IsActive,
            Gender = Gender,
            PhoneNumber = PhoneNumber,
            RoleId = RoleId
        });
        return RedirectAndShowAlert(res, RedirectToPage("Index"));
    }
}
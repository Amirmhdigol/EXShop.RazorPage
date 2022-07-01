using EXShop.RazorPage.Models.Users;
using EXShop.RazorPage.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Admin.User;
public class IndexModel : PageModel
{
    private readonly IUserService _userService;
    public IndexModel(IUserService userService)
    {
        _userService = userService;
    }
    public List<UserDTO> Users { get; set; }
    public async void OnGet()
    {
        await _userService.GetUserByFilter(new UserFilterParams
        {
            
        });
    }
}

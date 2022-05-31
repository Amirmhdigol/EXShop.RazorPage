using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Auth;

namespace EXShop.RazorPage.Services.Auth;
public interface IAuthService
{
    Task<ApiResult<LoginResponse>?> Login(LoginCommand command);
    Task<ApiResult?> Register(RegisterCommand command);
    Task<ApiResult<LoginResponse>?> RefreshToken();
    Task<ApiResult?> LogOut();
}
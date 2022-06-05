using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Auth;
using System.Net;

namespace EXShop.RazorPage.Services.Auth;

public class AuthService : IAuthService
{
    private HttpClient _httpClient;
    private readonly IHttpContextAccessor _accessor;

    public AuthService(HttpClient httpClient, IHttpContextAccessor accessor)
    {
        _httpClient = httpClient;
        _accessor = accessor;
    }

    public async Task<ApiResult<LoginResponse>?> Login(LoginCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync("Auth/Login", command);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }

    public async Task<ApiResult?> LogOut()
    {
        try
        {
            var result = await _httpClient.DeleteAsync("Auth/LogOut");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        
        catch (Exception)
        {
            return ApiResult.Error();
        }
    }

    public async Task<ApiResult<LoginResponse>?> RefreshToken()
    {
        var refreshToken = _accessor.HttpContext.Request.Cookies["refreshToken"];
        var result = await _httpClient.PostAsync($"auth/refreshToken?refreshToken={refreshToken}", null);
        return await result.Content.ReadFromJsonAsync<ApiResult<LoginResponse>>();
    }

    public async Task<ApiResult?> Register(RegisterCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync("Auth/Register", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }
}
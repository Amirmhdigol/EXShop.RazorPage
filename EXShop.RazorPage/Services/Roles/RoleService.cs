using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Roles;

namespace EXShop.RazorPage.Services.Roles;

public class RoleService : IRoleService
{
    private readonly HttpClient _Client;
    public RoleService(HttpClient client)
    {
        _Client = client;
    }

    public async Task<ApiResult?> CreateRole(CreateRoleCommand command)
    {
        var res = await _Client.PostAsJsonAsync("role", command);
        return await res.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> EditRole(EditRoleCommand command)
    {
        var res = await _Client.PutAsJsonAsync("role", command);
        return await res.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<RoleDTO?> GetRoleById(long roleId)
    {
        var res = await _Client.GetFromJsonAsync<ApiResult<RoleDTO>>($"role/{roleId}");
        return res?.Data;
    }

    public async Task<List<RoleDTO>?> GetRoles()
    {
        var res = await _Client.GetFromJsonAsync<ApiResult<List<RoleDTO>?>>("role");
        return res?.Data;
    }
}
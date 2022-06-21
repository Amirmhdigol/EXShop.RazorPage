using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Roles;

namespace EXShop.RazorPage.Services.Roles;
public interface IRoleService
{
    //Commands
    Task<ApiResult?> CreateRole(CreateRoleCommand command);
    Task<ApiResult> EditRole(EditRoleCommand command);

    //Queries
    Task<RoleDTO?> GetRoleById(long roleId);
    Task<List<RoleDTO>> GetRoles();
}
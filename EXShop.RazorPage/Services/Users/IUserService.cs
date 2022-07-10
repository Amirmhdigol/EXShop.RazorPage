using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Roles;
using EXShop.RazorPage.Models.Users;

namespace EXShop.RazorPage.Services.Users;
public interface IUserService
{
    Task<ApiResult?> EditUser(EditUserCommand command);
    Task<ApiResult> DeleteUser(long userId);
    Task<ApiResult?> EditCurrentUser(EditUserCommand command);
    Task<ApiResult?> ChangeUserPassword(ChangePasswordCommand command);
    Task<ApiResult?> CreateUser(CreateUserCommand command);
    //Task<ApiResult> AddToken(AddUserTokenCommand command);
    //Task<ApiResult> RemoveToken(RemoveUserTokenCommand command);

    Task<UserDTO?> GetUserByPhoneNumber(string phoneNumber);
    Task<UserDTO?> GetCurrentUser();
    Task<UserDTO?> GetUserById(long userId);
    Task<List<RoleDTO?>> GetUserRoles(long userId);
    Task<LlongRoleId> GetUserRoleId(long userId);
    Task<UserFilterResult?> GetUserByFilter(UserFilterParams filterParams);
    //Task<UserTokenDTO?> GetTokenByRefreshToken(string refreshToken);
    //Task<UserTokenDTO?> GetTokenByJwtToken(string jwtToken);

}

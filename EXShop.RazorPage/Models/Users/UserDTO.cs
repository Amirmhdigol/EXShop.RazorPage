namespace EXShop.RazorPage.Models.Users;
public class UserDTO : BaseDTO
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string UserAvatar { get; set; }
    public Gender Gender { get; set; }
    public bool IsActive { get; set; }
    public string PhoneNumber { get; set; }
    public List<UserRoleDTO> UserRoles { get; set; }
}
public class UserRoleDTO
{
    public string RoleTitle { get; set; }
    public long RoleId { get; set; }
}
public class UserFilterData : BaseDTO
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string? Email { get; set; }
    public string UserAvatar { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
}
public class UserFilterParams : BaseFilterParam
{
    public string? Email { get;  set; }
    public string? PhoneNumber { get; set; }
    public long? Id { get; set; }
}
public class UserFilterResult : BaseFilter<UserFilterData, UserFilterParams>
{

}

public enum Gender
{
    Male,
    Female,
    None
}

public class UserTokenDTO : BaseDTO
{
    public long UserId { get; set; }
    public string HashedJwtToken { get; set; }
    public string HashedRefreshToken { get; set; }
    public DateTime TokenExpireDate { get; set; }
    public DateTime RefreshTokenExpireDate { get; set; }
    public string Device { get; set; }
}

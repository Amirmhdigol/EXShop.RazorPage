namespace EXShop.RazorPage.Models.Users;

public class AddUserTokenCommand
{
    public long UserId { get; set; }
    public string HashedJwtToken { get; set; }
    public string HashedRefreshToken { get; set; }
    public DateTime TokenExpireDate { get; set; }
    public DateTime RefreshTokenExpireDate { get; set; }
    public string Device { get; set; }
}

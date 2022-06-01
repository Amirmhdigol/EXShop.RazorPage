namespace EXShop.RazorPage.Models.Users;

public class ChangePasswordCommand 
{
    public long UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string Password { get; set; }
}

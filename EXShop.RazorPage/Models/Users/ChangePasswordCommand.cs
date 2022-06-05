namespace EXShop.RazorPage.Models.Users;

public class ChangePasswordCommand 
{
    public string CurrentPassword { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

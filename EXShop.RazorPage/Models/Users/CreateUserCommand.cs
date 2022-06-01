namespace EXShop.RazorPage.Models.Users;

public class CreateUserCommand
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public string PhoneNumber { get; set; }
}

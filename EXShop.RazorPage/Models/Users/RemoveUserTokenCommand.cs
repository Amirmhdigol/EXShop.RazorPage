namespace EXShop.RazorPage.Models.Users;

public class RemoveUserTokenCommand
{
    public long UserId { get; set; }
    public long TokenId { get; set; }
}
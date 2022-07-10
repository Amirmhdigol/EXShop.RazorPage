namespace EXShop.RazorPage.Models.Users;

public class EditUserCommand 
{
    public long UserId { get; set; }
    public IFormFile? Avatar { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Email { get; set; }
    public Gender Gender { get; set; }
    public bool IsActive { get; set; }
    public string PhoneNumber { get; set; }
    public long RoleId { get; set; }
}

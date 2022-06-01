namespace EXShop.RazorPage.Models.Products;

public class RemoveProductImageCommand
{
    public long ProductId { get; set; }
    public long ImageId { get; set; }
}
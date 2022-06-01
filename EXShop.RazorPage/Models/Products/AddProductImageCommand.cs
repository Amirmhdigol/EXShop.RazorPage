namespace EXShop.RazorPage.Models.Products;

public class AddProductImageCommand
{
    public IFormFile ImageFile { get; set; }
    public long ProductId { get; set; }
    public int Sequence { get; set; }
}

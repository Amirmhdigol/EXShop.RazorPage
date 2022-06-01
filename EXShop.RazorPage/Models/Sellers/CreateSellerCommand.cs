namespace EXShop.RazorPage.Models.Sellers;

public class CreateSellerCommand 
{
    public long UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
}
public class EditSellerCommand 
{
    public long UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}
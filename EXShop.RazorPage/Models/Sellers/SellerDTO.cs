namespace EXShop.RazorPage.Models.Sellers;
public class SellerDTO : BaseDTO
{
    public long UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}
public enum SellerStatus
{
    New,
    Accepted,
    Rejected,
    InActive
}
public class SellerFilterResult : BaseFilter<SellerDTO, SellerFilterParams>
{
    public long UserId { get; set; }
    public string ShopName { get; set; }
    public string NationalCode { get; set; }
    public SellerStatus Status { get; set; }
}
public class SellerFilterParams : BaseFilterParam
{
    public string NationalCode { get; set; }
    public string ShopName { get; set; }
}

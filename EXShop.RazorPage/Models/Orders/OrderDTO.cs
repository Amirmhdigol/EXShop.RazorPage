namespace EXShop.RazorPage.Models.Orders;
public class OrderDTO : BaseDTO
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItemDTO> Items { get; set; }
    public OrderDiscount? Discount { get; set; }
    public OrderAddressDTO? Address { get; set; }
    public ShippingMethod? ShippingMethod { get; set; }
    public DateTime? LastUpdate { get; set; }
}
public class OrderItemDTO : BaseDTO
{
    public string ProductTitle { get; set; }
    public string ProductSlug { get; set; }
    public string ProductImageName { get; set; }
    public string ShopName { get; set; }
    public long OrderId { get; set; }
    public long InventoryId { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int TotalPrice => Price * Count;
}
public class OrderFilterData : BaseDTO
{
    public long UserId { get; set; }
    public string UserFullName { get; set; }
    public OrderStatus Status { get; set; }
    public string? Provice { get; set; }
    public string? City { get; set; }
    public string? ShippingType { get; set; }
    public int TotalPrice { get; set; }
    public int TotalItemCount { get; set; }
}
public class OrderFilterParams : BaseFilterParam
{
    public long UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public OrderStatus? Status { get; set; }
}
public class OrderFilterResult : BaseFilter<OrderFilterData, OrderFilterParams>
{

}
public class OrderAddressDTO
{
    public long OrderId { get; set; }
    public string Provice { get; set; }
    public string City { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string PostalAddress { get; set; }
    public string PostalCode { get; set; }
    public string NationalCode { get; set; }
    public string PhoneNumber { get; set; }
}
public class OrderDiscount
{
    public string DiscountTitle { get; set; }
    public int DiscountAmount { get; set; }
}
public enum OrderStatus
{
    pennding,
    Finally,
    Shipping,
    Rejected
}
public class ShippingMethod
{
    public string ShipppingType { get; set; }
    public int ShippingCost { get; set; }
}

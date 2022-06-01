namespace EXShop.RazorPage.Models.Orders
{
    public class AddOrderItemCommand
    {
        public long InventoryId { get; set; }
        public int Count { get; set; }
        public long UserId { get; set; }
    }
}

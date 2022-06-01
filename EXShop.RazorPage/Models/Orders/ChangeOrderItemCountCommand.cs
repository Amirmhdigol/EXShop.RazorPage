namespace EXShop.RazorPage.Models.Orders
{
    public class ChangeOrderItemCountCommand
    {
        public long UserId { get; set; }
        public long ItemId { get; set; }
        public int Count { get; set; }
    }
}

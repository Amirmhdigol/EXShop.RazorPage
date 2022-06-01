namespace EXShop.RazorPage.Models.Orders
{
    public class ChechOutOrderCommand
    {
        public long UserId { get; set; }
        public string Provice { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PostalAddress { get; set; }
        public string PostalCode { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}

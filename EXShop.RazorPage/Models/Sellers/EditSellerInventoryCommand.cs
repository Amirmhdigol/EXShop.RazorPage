using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Models.Sellers;
public class EditSellerInventoryCommand
{
    public long SellerId { get; set; }
    public long InventoryId { get; set; }
    [Display(Name = "تعداد موجود")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Count { get; set; }
    [Display(Name = "قیمت")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    public int Price { get; set; }
    [Display(Name = "درصد تخفیف ")]
    [Required(ErrorMessage = "{0} را وارد کنید")]
    [Range(0,100,ErrorMessage = "درصد تخفیف نامعتبر است")]
    public int DiscountPercentage { get; set; }
}
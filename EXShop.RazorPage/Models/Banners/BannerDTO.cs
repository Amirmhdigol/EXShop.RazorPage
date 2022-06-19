namespace EXShop.RazorPage.Models.Banners;
public class BannerDTO : BaseDTO
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPosition Position { get; set; }
}
public enum BannerPosition
{
    Under_Slider,
    Right_Of_Slider
}

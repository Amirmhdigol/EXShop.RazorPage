namespace EXShop.RazorPage.Models.Banners;
public class BannerDTO : BaseDTO
{
    public string Link { get; set; }
    public string ImageName { get; set; }
    public BannerPosition Position { get; set; }
}
public enum BannerPosition
{
    Middle_Page,
    Top_Of_Slider,
    Left_Of_Slider,
    Right_Of_Special
}

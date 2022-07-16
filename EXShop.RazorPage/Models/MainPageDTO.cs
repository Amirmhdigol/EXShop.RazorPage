using EXShop.RazorPage.Models.Banners;
using EXShop.RazorPage.Models.Products;
using EXShop.RazorPage.Models.Sliders;

namespace EXShop.RazorPage.Models;
public class MainPageDTO
{
    public List<SliderDto> Sliders { get; set; }
    public List<BannerDTO> Banners { get; set; }

    public List<ProductShopDto> SpecialProducts { get; set; }
    public List<ProductShopDto> LatestProducts { get; set; }
    public List<ProductShopDto> TopVisitProducts { get; set; }
}   
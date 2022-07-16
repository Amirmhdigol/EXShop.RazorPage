using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Products;
using EXShop.RazorPage.Services.Banners;
using EXShop.RazorPage.Services.Products;
using EXShop.RazorPage.Services.Sliders;

namespace EXShop.RazorPage.Services.MainPage;

class MainPageService : IMainPageService
{
    private readonly ISliderService _sliderService;
    private readonly IBannerService _bannerService;
    private readonly IProductService _productService;
    public MainPageService(ISliderService sliderService, IBannerService bannerService, IProductService productService)
    {
        _sliderService = sliderService;
        _bannerService = bannerService;
        _productService = productService;
    }

    public async Task<MainPageDTO> GetMainPageData()
    {
        var sliders = await _sliderService.GetSliders();
        var banners = await _bannerService.GetBannersList();
        var latestProductResult = await _productService.GetProductsForShopByFilter(new ProductShopFilterParam
        {
            PageId = 1,
            Take = 8,
            SearchOrderBy = ProductSearchOrderBy.Latest,
            OnlyAvailableProducts = true
        });
        var latestProducts = latestProductResult.Data;
       
        var specialProductResult = await _productService.GetProductsForShopByFilter(new ProductShopFilterParam
        {
            PageId = 1,
            Take = 8,
            JustHasDiscount = true,
            OnlyAvailableProducts = true
        });
        var specialProducts = specialProductResult.Data;


        var topVisitProductsResult = await _productService.GetProductsForShopByFilter(new ProductShopFilterParam()
        {
            PageId = 1,
            Take = 8,
            OnlyAvailableProducts = true
        });
        var topVisitProducts = topVisitProductsResult.Data;

        return new MainPageDTO
        { 
            Sliders = sliders,
            Banners = banners,
            SpecialProducts = specialProducts,
            LatestProducts = latestProducts,
            TopVisitProducts = topVisitProducts
        };
    }
}
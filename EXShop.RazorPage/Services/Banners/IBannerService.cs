using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Banners;

namespace EXShop.RazorPage.Services.Banners;
public interface IBannerService
{
    Task<ApiResult> CreateBanner(CreateBannerCommand command);
    Task<ApiResult> EditBanner(EditBannerCommand command);
    Task<ApiResult> DeleteBanner(long bannerId);

    Task<BannerDTO?> GetBannerById(long bannerId);
    Task<List<BannerDTO>> GetBannersList();
}
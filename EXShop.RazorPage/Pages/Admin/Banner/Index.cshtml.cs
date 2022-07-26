using EXShop.RazorPage.Infrastructure;
using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Banners;
using EXShop.RazorPage.Services.Banners;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Admin.Banners;
public class IndexModel : BaseRazorPage
{
    private readonly IBannerService _bannerService;
    private readonly IRenderViewToString _renderViewToString;
    public IndexModel(IBannerService bannerService, IRenderViewToString renderViewToString)
    {
        _bannerService = bannerService;
        _renderViewToString = renderViewToString;
    }
    public List<BannerDTO> Banners { get; set; }
  
    public async Task OnGet()   
    {
        Banners = await _bannerService.GetBannersList();
    }
    
    public async Task<IActionResult> OnGetRenderAddPage()
    {
        return await AjaxTryCatch(async () =>
        {
            var view = await _renderViewToString.RenderToStringAsync("_Add", new CreateBannerCommand(), PageContext);
            return ApiResult<string>.Success(view);
        });
    }
    
    public async Task<IActionResult> OnGetRenderEditPage(long id)
    {
        return await AjaxTryCatch(async () =>
        {
            var banner = await _bannerService.GetBannerById(id);
            if (banner == null) return ApiResult<string>.Error();
            var model = new EditBannerCommand
            {
                Id = banner.Id,
                Link = banner.Link,
                Position = banner.Position
            };
            var view = await _renderViewToString.RenderToStringAsync("_Edit", model, PageContext);
            return ApiResult<string>.Success(view);
        });
    }
   
    public async Task<IActionResult> OnPostDelete(long bannerId)
    {
        return await AjaxTryCatch(async () =>
        {
            return await _bannerService.DeleteBanner(bannerId);
        });
    }
    
    public async Task<IActionResult> OnPostEditBanner(EditBannerCommand command)
    {
        return await AjaxTryCatch(async () =>
        {
            return await _bannerService.EditBanner(command);
        });
    }

    public async Task<IActionResult> OnPostCreateBanner(CreateBannerCommand command)
    {
        return await AjaxTryCatch(async () =>
        {
            return await _bannerService.CreateBanner(command);
        });
    }
}
using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Sliders;

namespace EXShop.RazorPage.Services.Sliders;
public interface ISliderService
{
    Task<ApiResult> CreateSlider(CreateSliderCommand command);
    Task<ApiResult> EditSlider(EditSliderCommand command);
    Task<ApiResult> DeleteSlider(long sliderId);

    Task<SliderDto?> GetSliderById(long sliderId);
    Task<List<SliderDto>> GetSliders();
}

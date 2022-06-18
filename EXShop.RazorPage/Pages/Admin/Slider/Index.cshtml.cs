using EXShop.RazorPage.Models.Sliders;
using EXShop.RazorPage.Services.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages.Admin.Slider
{
    public class IndexModel : BaseRazorPage
    {
        private readonly ISliderService _sliderService;

        public IndexModel(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        
        public List<SliderDto> Sliders { get; set; }      
        public async Task OnGet()
        {
            var DbSliders = await _sliderService.GetSliders();
            Sliders = DbSliders;
        }

        public async Task<IActionResult> OnPostDeleteSlider(long sliderId)
        {
            return await AjaxTryCatch(() =>
            {
                return _sliderService.DeleteSlider(sliderId);
            });
        }
    }
}

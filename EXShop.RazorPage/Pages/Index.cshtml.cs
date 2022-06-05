using EXShop.RazorPage.Models.Auth;
using EXShop.RazorPage.Services.Auth;
using EXShop.RazorPage.Services.Banners;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages
{
    
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBannerService _service;
        public IndexModel(ILogger<IndexModel> logger, IBannerService service)
        {
            _logger = logger;
            _service = service;
        }

        public async void OnGet()
        {
            //var result = await _service.GetBannersList();
            //var result = await _service.Login(new LoginCommand()
            //{
            //    Password = "1234567890",
            //    PhoneNumber = "09305312307"
            //});
        }
    }
}
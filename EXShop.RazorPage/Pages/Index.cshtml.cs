using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Auth;
using EXShop.RazorPage.Services.Auth;
using EXShop.RazorPage.Services.Banners;
using EXShop.RazorPage.Services.MainPage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;

namespace EXShop.RazorPage.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMainPageService _mainPageService;
        public IndexModel(ILogger<IndexModel> logger, IMainPageService mainPageService)
        {
            _logger = logger;
            _mainPageService = mainPageService;
        }

        public MainPageDTO MainPageData { get; set; }
        public async Task OnGet()
        {
            MainPageData = await _mainPageService.GetMainPageData();
        }
    }
}
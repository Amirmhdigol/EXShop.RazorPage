using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Auth;
using EXShop.RazorPage.Services.Auth;
using EXShop.RazorPage.Services.Banners;
using EXShop.RazorPage.Services.MainPage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace EXShop.RazorPage.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMainPageService _mainPageService;
        private readonly IMemoryCache _memoryCache;
        public IndexModel(ILogger<IndexModel> logger, IMainPageService mainPageService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _mainPageService = mainPageService;
            _memoryCache = memoryCache;
        }

        public MainPageDTO MainPageData { get; set; }
        public async Task OnGet()
        {
            MainPageData = await _memoryCache.GetOrCreateAsync("main-page", (entry) =>
            {
                entry.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(15);
                entry.SlidingExpiration = TimeSpan.FromMinutes(5);
                return _mainPageService.GetMainPageData();
            });
        }
    }
}
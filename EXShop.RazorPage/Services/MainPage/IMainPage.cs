using EXShop.RazorPage.Models;

namespace EXShop.RazorPage.Services.MainPage;
public interface IMainPageService
{
    Task<MainPageDTO> GetMainPageData();
}

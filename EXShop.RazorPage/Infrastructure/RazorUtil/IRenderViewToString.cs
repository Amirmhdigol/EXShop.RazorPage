using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Infrastructure.RazorUtil;

public interface IRenderViewToString
{
    Task<string> RenderToStringAsync(string viewName, object model, PageContext context);
}
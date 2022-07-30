using EXShop.RazorPage.Infrastructure;
using EXShop.RazorPage.Infrastructure.CookieUtil;
using EXShop.RazorPage.Models.Auth;
using EXShop.RazorPage.Models.Orders;
using EXShop.RazorPage.Services.Auth;
using EXShop.RazorPage.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EXShop.RazorPage.Pages.Auth;

[BindProperties]
[ValidateAntiForgeryToken]
public class LoginModel : BaseRazorPage
{
    private readonly IAuthService _authService;
    private readonly IOrderService _orderService;
    private readonly ShopCartCookieManager _cookieManager;

    public LoginModel(IAuthService authService, ShopCartCookieManager cookieManager, IOrderService orderService)
    {
        _authService = authService;
        _cookieManager = cookieManager;
        _orderService = orderService;
    }

    [DisplayName("شماره تلفن"),
    Required(ErrorMessage = "{0} را وارد کنید")]
    public string PhoneNumber { get; set; }

    [DisplayName("رمز"),
    Required(ErrorMessage = "{0} را وارد کنید")]
    [MinLength(5, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string? RedirectTo { get; set; }

    public IActionResult OnGet(string? redirectTo)
    {
        if (User.Identity.IsAuthenticated) return Redirect("/");

        if (redirectTo != null) RedirectTo = redirectTo;

        return Page();
    }
    public async Task<IActionResult> OnPost()
    {
        var res = await _authService.Login(new Models.Auth.LoginCommand { PhoneNumber = PhoneNumber, Password = Password });

        if (res.IsSuccess == false)
        {
            ModelState.AddModelError(nameof(PhoneNumber), res.MetaData.Message);
            return Page();
        }
        var token = res.Data.Token;
        var Retoken = res.Data.RefreshToken;

        HttpContext.Response.Cookies.Append("token", token, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddDays(7),
        });
        HttpContext.Response.Cookies.Append("Refreshtoken", Retoken, new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTimeOffset.Now.AddDays(10),
        });

        await SyncShopCart(token); //adds the cookie shopcart that added when user were not logged in

        if (!string.IsNullOrWhiteSpace(RedirectTo)) return LocalRedirect(RedirectTo);

        return Redirect("/");
    }
    public async Task SyncShopCart(string token)
    {
        var shopCart = _cookieManager.GetShopCart();
        if (shopCart == null || !shopCart.Items.Any())
            return;

        HttpContext.Request.Headers.Append("Authorization", $"Bearer {token}");
        //because we need Authorization header in HttpClientAuthorizationDelegatingHandler

        var handler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = handler.ReadJwtToken(token);
        var userId = Convert.ToInt64(jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);

        foreach (var item in shopCart.Items)
        {
            await _orderService.AddOrderItem(new AddOrderItemCommand
            {
                Count = item.Count,
                InventoryId = item.InventoryId,
                UserId = userId
            });
        }
        _cookieManager.DeleteShopCart();
    }
}
using EXShop.RazorPage.Services.Auth;
using EXShop.RazorPage.Services.Banners;
using EXShop.RazorPage.Services.Categories;
using EXShop.RazorPage.Services.Comments;
using EXShop.RazorPage.Services.Orders;
using EXShop.RazorPage.Services.Products;
using EXShop.RazorPage.Services.Roles;
using EXShop.RazorPage.Services.Sellers;
using EXShop.RazorPage.Services.Sliders;
using EXShop.RazorPage.Services.UserAddress;
using EXShop.RazorPage.Services.Users;

namespace EXShop.RazorPage.Infrastructure;
public static class RegisterServicesDI
{
    public static IServiceCollection RegisterApiServices(this IServiceCollection services)
    {
        const string baseAddress = "https://localhost:5001/api/";
        services.AddHttpClient<IAuthService, AuthService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IProductService, ProductService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IOrderService, OrderService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ISellerService, SellersService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IUserService, UserService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IRoleService, RoleService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ICommentService, CommentService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ICategoryService, CategoryService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IUserAddressService, UserAddressService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<IBannerService, BannerService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        services.AddHttpClient<ISliderService, SliderService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(baseAddress);
        });
        return services;
    }
}
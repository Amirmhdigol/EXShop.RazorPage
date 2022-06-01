using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Sellers;

namespace EXShop.RazorPage.Services.Sellers;
public interface ISellerService
{
    //Commands
    Task<ApiResult?> Create(CreateSellerCommand command);
    Task<ApiResult?> Edit(EditSellerCommand command);

    //Queries
    Task<SellerDTO?> GetSellerById(long sellerId);
    Task<SellerDTO?> GetSellerByUserId();
    Task<SellerFilterResult?> GetSellersByFilter(SellerFilterParams filterParams);
}

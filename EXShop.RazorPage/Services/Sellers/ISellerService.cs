using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Sellers;

namespace EXShop.RazorPage.Services.Sellers;
public interface ISellerService
{
    //Commands
    Task<ApiResult?> Create(CreateSellerCommand command);
    Task<ApiResult?> Edit(EditSellerCommand command);
    Task<ApiResult?> AddSellerInventory(AddSellerInventoryCommand command);
    Task<ApiResult?> EditSellerInventory(EditSellerInventoryCommand command);

    //Queries
    Task<SellerDTO?> GetSellerById(long sellerId);
    Task<SellerDTO?> GetSellerByUserId();
    Task<SellerFilterResult?> GetSellersByFilter(SellerFilterParams filterParams);
    Task<List<InventoryDTO>?> GetSellerInventories();
    Task<InventoryDTO?> GetSellerInventoryById(long inventoryId);
}

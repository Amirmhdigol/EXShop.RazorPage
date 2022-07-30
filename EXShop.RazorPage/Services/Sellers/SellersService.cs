using EXShop.RazorPage.Infrastructure;
using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Sellers;

namespace EXShop.RazorPage.Services.Sellers;

public class SellersService : ISellerService
{
    private readonly HttpClient _client;

    public SellersService(HttpClient client)
    {
        _client = client;
    }


    public async Task<ApiResult?> Create(CreateSellerCommand command)
    {
        var res = await _client.PostAsJsonAsync("seller", command);
        return await res.Content.ReadFromJsonAsync<ApiResult?>();
    }

    public async Task<ApiResult?> Edit(EditSellerCommand command)
    {
        var res = await _client.PutAsJsonAsync("seller", command);
        return await res.Content.ReadFromJsonAsync<ApiResult?>();
    }
    public async Task<ApiResult?> AddSellerInventory(AddSellerInventoryCommand command)
    {
        var res = await _client.PostAsJsonAsync("seller/addInventory", command);
        return await res.Content.ReadFromJsonAsync<ApiResult?>();
    }

    public async Task<ApiResult?> EditSellerInventory(EditSellerInventoryCommand command)
    {
        var res = await _client.PutAsJsonAsync("seller/editInventory", command);
        return await res.Content.ReadFromJsonAsync<ApiResult?>();
    }

    public async Task<SellerDTO?> GetSellerById(long sellerId)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<SellerDTO>>($"seller/{sellerId}");
        return res?.Data;
    }

    public async Task<SellerDTO?> GetSellerByUserId()
    {
        var res = await _client.GetFromJsonAsync<ApiResult<SellerDTO>>($"seller/current");
        return res?.Data;
    }

    public async Task<List<InventoryDTO>?> GetSellerInventories()
    {
        var res = await _client.GetFromJsonAsync<ApiResult<List<InventoryDTO>>>("seller/inventory");
        return res?.Data;
    }

    public async Task<InventoryDTO?> GetSellerInventoryById(long inventoryId)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<InventoryDTO>>($"seller/inventory/{inventoryId}");
        return res?.Data;
    }

    public async Task<SellerFilterResult?> GetSellersByFilter(SellerFilterParams filterParams)
    {
        var url = filterParams.GenerateBaseFilterUrl("seller") +
                          $"&NationalCode={filterParams.NationalCode}&ShopName={filterParams.ShopName}";

        var result = await _client.GetFromJsonAsync<ApiResult<SellerFilterResult>>(url);
        return result.Data;
    }

    public async Task<InventoryDTO?> GetSellerInventoryByIdForAll(long inventoryId)
    {
        var res = await _client.GetFromJsonAsync<ApiResult<InventoryDTO>>($"seller/inventory/ForAll/{inventoryId}");
        return res?.Data;
    }
}
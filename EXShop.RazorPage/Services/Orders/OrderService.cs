using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Orders;

namespace EXShop.RazorPage.Services.Orders;

public class OrderService : IOrderService
{
    private readonly HttpClient _client;
    public OrderService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ApiResult?> AddOrderItem(AddOrderItemCommand command)
    {
        var result = await _client.PostAsJsonAsync("order", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> DecreaseItemCount(ChangeOrderItemCountCommand command)
    {
        var result = await _client.PutAsJsonAsync("order/DecreaseOrderItemCount", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<OrderFilterResult?> GetFilteresOrders(OrderFilterParams filterParams)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<OrderFilterResult>>($"order?filterParams={filterParams}");
        return result?.Data;
    }

    public async Task<OrderDTO?> GetOrderById(long orderId)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<OrderDTO>>($"order/{orderId}");
        return result?.Data;
    }

    public async Task<ApiResult?> IncreaseItemCount(ChangeOrderItemCountCommand command)
    {
        var result = await _client.PutAsJsonAsync("order/IncreaseOrderItemCount", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> OrderCheckout(ChechOutOrderCommand command)
    {
        var result = await _client.PostAsJsonAsync("order/checkout", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> RemoveOrderItem(RemoveOrdertemCommand command)
    {
        var result = await _client.DeleteAsync($"order/Orderitem/{command.ItemId}");
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }
}
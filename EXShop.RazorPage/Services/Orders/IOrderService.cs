using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Orders;

namespace EXShop.RazorPage.Services.Orders;
public interface IOrderService
{
    Task<ApiResult?> AddOrderItem(AddOrderItemCommand command);
    Task<ApiResult?> OrderCheckout(ChechOutOrderCommand command);
    Task<ApiResult?> IncreaseItemCount(ChangeOrderItemCountCommand command);
    Task<ApiResult?> DecreaseItemCount(ChangeOrderItemCountCommand command);
    Task<ApiResult?> RemoveOrderItem(RemoveOrdertemCommand command);

    Task<OrderDTO?> GetOrderById(long orderId);
    Task<OrderFilterResult?> GetFilteresOrders(OrderFilterParams filterParams);
}

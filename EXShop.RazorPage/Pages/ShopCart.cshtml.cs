using EXShop.RazorPage.Infrastructure;
using EXShop.RazorPage.Infrastructure.CookieUtil;
using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Orders;
using EXShop.RazorPage.Services.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages;
public class ShopCartModel : BaseRazorPage
{
    private readonly IOrderService _orderService;
    private readonly ShopCartCookieManager _cookieManager;
    public ShopCartModel(IOrderService orderService, ShopCartCookieManager cookieManager)
    {
        _orderService = orderService;
        _cookieManager = cookieManager;
    }
    public OrderDTO? OrderDto { get; set; }
   
    public async Task OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            OrderDto = await _orderService.GetCurrentOrder();
        }
        else
        {
            OrderDto = _cookieManager.GetShopCart();
        }
    }
    
    public async Task<IActionResult> OnPostDeleteItem(long id)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.RemoveOrderItem(new RemoveOrdertemCommand
            {
                ItemId = id
            }));
        }
        else
        {
            return await AjaxTryCatch(async () =>
            {
                _cookieManager.DeleteItem(id);
                return ApiResult.Success();
            });
        }
    }

    public async Task<IActionResult> OnPostAddItem(long inventoryId, int count)
    {
        if (User.Identity.IsAuthenticated)
        {
            var currentOrder = await _orderService.GetCurrentOrder();
            if (currentOrder.Items != null)
            {
                var items = currentOrder.Items;
                var alreadyhaditem = items.FirstOrDefault(a => a.InventoryId == inventoryId);

                if (alreadyhaditem != null)
                {
                    return await AjaxTryCatch(() => _orderService.IncreaseItemCount(new ChangeOrderItemCountCommand
                    {
                        Count = 1,
                        ItemId = alreadyhaditem.Id,
                        UserId = User.GetUserId()
                    }));
                }
            }
            return await AjaxTryCatch(() => _orderService.AddOrderItem(new AddOrderItemCommand
            {
                UserId = User.GetUserId(),
                InventoryId = inventoryId,
                Count = count
            }));
        }
        else
        {
            return await AjaxTryCatch(async () => await _cookieManager.AddItem(inventoryId, count));
        }
    }

    public async Task<IActionResult> OnPostIncreaseItem(long id)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.IncreaseItemCount(new ChangeOrderItemCountCommand
            {
                Count = 1,
                ItemId = id,
                UserId = User.GetUserId()
            }));
        }
        else
        {
            return await AjaxTryCatch(async () =>
            {
                _cookieManager.Increase(id);
                return ApiResult.Success();
            });
        }
    }

    public async Task<IActionResult> OnPostDecreaseItem(long id)
    {
        if (User.Identity.IsAuthenticated)
        {
            return await AjaxTryCatch(() => _orderService.DecreaseItemCount(new ChangeOrderItemCountCommand
            {
                Count = 1,
                ItemId = id,
                UserId = User.GetUserId()
            }));
        }
        else
        {
            return await AjaxTryCatch(async () =>
            {
                _cookieManager.Decrease(id);
                return ApiResult.Success();
            });
        }
    }
}
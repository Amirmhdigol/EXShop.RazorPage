using CookieManager;
using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Orders;
using EXShop.RazorPage.Services.Products;
using EXShop.RazorPage.Services.Sellers;

namespace EXShop.RazorPage.Infrastructure.CookieUtil;
public class ShopCartCookieManager
{
    private readonly ICookieManager _cookieManager;
    private readonly ISellerService _sellerService;
    private readonly IProductService _productService;
    private const string CookieShopCartName = "shop-cart";
    public ShopCartCookieManager(ICookieManager cookieManager, ISellerService sellerService, IProductService productService)
    {
        _cookieManager = cookieManager;
        _sellerService = sellerService;
        _productService = productService;
    }
  
    public OrderDTO? GetShopCart()
    {
        return _cookieManager.Get<OrderDTO>(CookieShopCartName);
    }
    public void DeleteShopCart()
    {
        _cookieManager.Remove(CookieShopCartName);
    }
    public async Task<ApiResult> AddItem(long inventoryId, int count)
    {
        var shopCart = GetShopCart();
        var inventory = await _sellerService.GetSellerInventoryByIdForAll(inventoryId);
        if (inventory == null)
            return ApiResult.Error();

        var product = await _productService.GetProductById(inventory.ProductId);
        if (shopCart == null)
        {
            var order = new OrderDTO
            {
                Address = null,
                CreationDate = DateTime.Now,
                Discount = null,
                Id = 1,
                UserId = 1,
                UserFullName = "",
                Status = OrderStatus.Finally,
                Items = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        Price = inventory.Price,
                        Count = count,
                        ProductImageName = inventory.ProductImage,
                        ShopName = inventory.ShopName,
                        CreationDate = DateTime.Now,
                        ProductTitle = inventory.ProductTitle,
                        InventoryId = inventoryId,
                        OrderId = 1,
                        Id = GenerateId(),
                        ProductSlug = product!.Slug  // "!" means im sure that this is not null
                    }
                }
            };
            SetCookie(order);
            return ApiResult.Success();
        }
        else
        {
            if (shopCart.Items.Any(a => a.InventoryId == inventoryId))
            {
                var item = shopCart.Items.First(A => A.InventoryId == inventoryId);

                if (inventory.Count >= item.Count + count)
                    item.Count += count;
                else
                    return ApiResult.Error("تعداد موجودی فروشنده کمتر از تعداد درخواستی است");
            }
            else
            {
                var newItem = new OrderItemDTO
                {
                    Price = inventory.Price,
                    Count = count,
                    ProductImageName = inventory.ProductImage,
                    ShopName = inventory.ShopName,
                    CreationDate = DateTime.Now,
                    ProductTitle = inventory.ProductTitle,
                    InventoryId = inventoryId,
                    OrderId = 1,
                    Id = GenerateId(),
                    ProductSlug = product!.Slug  // "!" means im sure that this is not null
                };
                shopCart.Items.Add(newItem);
            }
            SetCookie(shopCart);
            return ApiResult.Success();
        }
    }
    public void Increase(long itemId)
    {
        var shopcart = GetShopCart();
        if (shopcart == null)
            return;

        var item = shopcart.Items.FirstOrDefault(a => a.Id == itemId);
        if (item == null)
            return;

        item.Count += 1;
        SetCookie(shopcart);
    }
    public void Decrease(long itemId)
    {
        var shopcart = GetShopCart();
        if (shopcart == null)
            return;

        var item = shopcart.Items.FirstOrDefault(a => a.Id == itemId);
        if (item == null || item.Count == 1)
            return;

        item.Count -= 1;
        SetCookie(shopcart);
    }
    public void DeleteItem(long itemId)
    {
        var shopcart = GetShopCart();
        if (shopcart == null)
            return;

        var item = shopcart.Items.FirstOrDefault(a => a.Id == itemId);
        if (item == null)
            return;

        shopcart.Items.Remove(item);
        SetCookie(shopcart);
    }
    private void SetCookie(OrderDTO order)
    {
        _cookieManager.Set(CookieShopCartName, order, new CookieOptions
        {
            HttpOnly = true, //check this what does
            Expires = DateTimeOffset.Now.AddDays(7),
            Secure = true
        });
    }
    private long GenerateId()
    {
        var random = new Random();
        var number = random.Next(0, 10000) * 6 ^ 2 + random.Next(6, 1000000);
        return number;
    }
}
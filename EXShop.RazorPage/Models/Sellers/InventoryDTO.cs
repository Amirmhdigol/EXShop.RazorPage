﻿namespace EXShop.RazorPage.Models.Sellers;
public class InventoryDTO : BaseDTO
{
    public long SellerId { get; set; }
    public string ShopName { get; set; }
    public long ProductId { get; set; }
    public string ProductTitle { get; set; }
    public string ProductImage { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
}
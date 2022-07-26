using EXShop.RazorPage.Models.Sellers;

namespace EXShop.RazorPage.Models.Products;
public class SingleProductDTO
{
    public ProductDTO Product { get; set; }
    public List<InventoryDTO> Inventories { get; set; }
}
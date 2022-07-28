using EXShop.RazorPage.Models.Categories;

namespace EXShop.RazorPage.Models.Products;
public class ProductDTO : BaseDTO
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Description { get; set; }
    public ProductCategoryDTO Category { get; set; }
    public ProductCategoryDTO SubCategory { get; set; }
    public ProductCategoryDTO? SecondrySubCategory { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ProductImageDTO> Images { get; set; }
    public List<ProductSpecificationsDTO> Specifications { get; set; }
}
public class ProductCategoryDTO
{
    public long Id { get; set; }
    public long? ParentId { get; set; }
    public string Title { get; set; }
    public SeoData SeoData { get; set; }
    public string Slug { get; set; }
}
public class ProductImageDTO : BaseDTO
{
    public long ProductId { get; set; }
    public string ImageName { get; set; }
    public int Sequence { get; set; }
}
public class ProductSpecificationsDTO : BaseDTO
{
    public string Key { get; set; }
    public string Value { get; set; }
}

public class ProductFilterData : BaseDTO
{
    public string Title { get; set; }
    public string ImageName { get; set; }
    public string Slug { get; set; }

}
public class ProductFilterParams : BaseFilterParam
{
    public string? Title { get; set; }
    public long? Id { get; set; }
    public string? Slug { get; set; }
}
public class ProductFilterResult : BaseFilter<ProductFilterData, ProductFilterParams>
{

}
public class ProductShopResult : BaseFilter<ProductShopDto, ProductShopFilterParam>
{
    public CategoryDTO? CategoryDto { get; set; }
}

public class ProductShopDto : BaseDTO
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public long InventoryId { get; set; }
    public int Price { get; set; }
    public int DiscountPercentage { get; set; }
    public string ImageName { get; set; }

    public int TotalPrice
    {
        get
        {
            var discount = Price * DiscountPercentage / 100;
            return Price - discount;
        }
    }
}
public class ProductShopFilterParam : BaseFilterParam
{
    public string? CategorySlug { get; set; } = "";
    public string? Search { get; set; } = "";
    public bool OnlyAvailableProducts { get; set; } = false;
    public bool? JustHasDiscount { get; set; } = false;
    public ProductSearchOrderBy SearchOrderBy { get; set; } = ProductSearchOrderBy.Cheapest;
}

public enum ProductSearchOrderBy
{
    Latest,
    Expensive,
    Cheapest,
}
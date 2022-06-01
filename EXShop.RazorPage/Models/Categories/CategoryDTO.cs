namespace EXShop.RazorPage.Models.Categories;

public class CategoryDTO : BaseDTO
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public List<ChildCategoryDTO> Childs { get; set; }
}
public class ChildCategoryDTO : BaseDTO
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public long ParentId { get; set; }
    public List<SecondaryChildCategoryDTO> Childs { get; set; }
}
public class SecondaryChildCategoryDTO : BaseDTO
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
    public long ParentId { get; set; }
}
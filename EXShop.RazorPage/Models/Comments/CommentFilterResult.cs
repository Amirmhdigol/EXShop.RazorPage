namespace EXShop.RazorPage.Models.Comments;
public class CommentFilterResult : BaseFilter<CommentDTO, CommentFilterParams>
{
}

public class CommentFilterParams : BaseFilterParam
{
    public int? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public CommentStatus? CommentStatus { get; set; }

}

public class CommentDTO : BaseDTO
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string UserFullName { get; set; }
    public string ProductTitle { get; set; }
    public string Text { get; set; }
    public int Status { get; set; }
}

public enum CommentStatus
{
    Pending,
    Accepted,
    Rejected
}
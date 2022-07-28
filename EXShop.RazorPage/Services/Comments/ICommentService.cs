using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Comments;

namespace EXShop.RazorPage.Services.Comments;
public interface ICommentService
{
    Task<ApiResult?> AddComment(AddCommentCommand command);
    Task<ApiResult?> EditComment(AddCommentCommand command);
    Task<ApiResult?> ChangeCommentStatus(long commentId, CommentStatus status);
    Task<ApiResult> DeleteComment(long commentId);

    Task<CommentDTO?> GetCommentById(long commentId);
    Task<CommentFilterResult?> GetCommentsFiltered(CommentFilterParams filterParams);
    Task<CommentFilterResult?> GetProductComments(long productId, int pageId, int take);
}
using EXShop.RazorPage.Infrastructure;
using EXShop.RazorPage.Models;
using EXShop.RazorPage.Models.Comments;

namespace EXShop.RazorPage.Services.Comments;

public class CommentService : ICommentService
{
    private readonly HttpClient _client;
    public CommentService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ApiResult?> AddComment(AddCommentCommand command)
    {
        var result = await _client.PostAsJsonAsync("comment", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }
    public async Task<ApiResult?> EditComment(AddCommentCommand command)
    {
        var result = await _client.PutAsJsonAsync("comment", command);
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<ApiResult?> ChangeCommentStatus(long commentId, CommentStatus status)
    {
        var result = await _client.PutAsJsonAsync("comment/changeStatus", new { Id = commentId , Status = status} );
        return await result.Content.ReadFromJsonAsync<ApiResult>();
    }

    public async Task<CommentDTO?> GetCommentById(long commentId)
    {
        var result = await _client.GetFromJsonAsync<ApiResult<CommentDTO>>($"comment/{commentId}");
        return result?.Data;
    }

    public async Task<CommentFilterResult?> GetCommentsFiltered(CommentFilterParams filterParams)
    {
        var url = filterParams.GenerateBaseFilterUrl("comment");
        if (filterParams.UserId != null)
            url += $"&UserId={filterParams.UserId}";

        if (filterParams.CommentStatus != null)
            url += $"&CommentStatus={filterParams.CommentStatus}";

        if (filterParams.StartDate != null)
            url += $"&StartDate{filterParams.StartDate}";

        if (filterParams.EndDate != null)
            url += $"&EndDate{filterParams.EndDate}";

        var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResult>>(url);
        return result?.Data;
    }

    public async Task<CommentFilterResult?> GetProductComments(long productId, int pageId, int take)
    {
        var url = $"Comment/productComments?pageId={pageId}&take={take}&productId={productId}";
        var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResult>>(url);
        return result?.Data;
    }
}
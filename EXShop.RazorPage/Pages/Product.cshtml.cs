using EXShop.RazorPage.Infrastructure;
using EXShop.RazorPage.Models.Comments;
using EXShop.RazorPage.Models.Products;
using EXShop.RazorPage.Models.Sellers;
using EXShop.RazorPage.Services.Comments;
using EXShop.RazorPage.Services.Products;
using EXShop.RazorPage.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EXShop.RazorPage.Pages;
public class ProductModel : BaseRazorPage
{
    private readonly IProductService _productService;
    private readonly ICommentService _commentService;
    public ProductModel(IProductService productService, ICommentService commentService)
    {
        _productService = productService;
        _commentService = commentService;
    }

    public SingleProductDTO Product { get; set; }
    public async Task<IActionResult> OnGet(string slug)
    {
        var product = await _productService.GetProductForSinglePageBySlug(slug);
        if (product == null)
            return NotFound();

        Product = product;
        return Page();
    }
    public async Task<IActionResult> OnPost(long productId, string comment, string slug)
    {
        if (!User.Identity.IsAuthenticated) return Page();
        var result = await _commentService.AddComment(new AddCommentCommand
        { 
            ProductId = productId,
            Text = comment,
            UserId = User.GetUserId()
        });
        if (result.IsSuccess == false)
        {
            ErrorAlert(result.MetaData.Message);
            return Page();
        }
        SuccessAlert("Your comment will be registered after qualification approval");
        return RedirectToPage("Product", new { slug });
    }
    public async Task<IActionResult> OnGetProductComments(long productId, int pageId = 1)
    {
        var commentResult = await _commentService.GetProductComments(productId, pageId, 12);
        return Partial("Shared/Products/_Comments", commentResult);
    }

    public async Task<IActionResult> OnPostdeleteComment(long id)
    {
        return await AjaxTryCatch(() => _commentService.DeleteComment(id));
    }
}
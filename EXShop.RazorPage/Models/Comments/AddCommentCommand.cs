﻿namespace EXShop.RazorPage.Models.Comments;
public class AddCommentCommand
{
    public string Text { get; set; }
    public long ProductId { get; set; }
    public long UserId { get; set; }
}

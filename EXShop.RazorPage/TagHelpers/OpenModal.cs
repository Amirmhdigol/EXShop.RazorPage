using Microsoft.AspNetCore.Razor.TagHelpers;

namespace EXShop.RazorPage.TagHelpers;
public class OpenModal : TagHelper
{
    public string Class { get; set; } = "btn btn-success";
    public string ModalTitle { get; set; } = "";
    public string Url { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "button";
        output.Attributes.Add("class", Class);
        output.Attributes.Add("onClick", $"OpenModal('{Url}','defaultModal','{ModalTitle}')");
        base.Process(context, output);
    }
}
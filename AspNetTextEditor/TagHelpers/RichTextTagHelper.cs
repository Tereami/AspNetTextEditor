using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetTextEditor.TagHelpers
{
    public class RichTextTagHelper : TagHelper
    {
        public string Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "div";
            output.Content.SetHtmlContent(Text);
        }
    }
}

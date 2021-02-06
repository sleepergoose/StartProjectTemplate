using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AppConfigTest.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "title")]
    public class ContentWraperTagHelper : TagHelper
    {
        public string Title { get; set; }
        public bool IncludeHeader { get; set; } = true;
        public bool IncludeFooter { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "card");
            output.Attributes.SetAttribute("style", "border: 2px solid #484848");
            output.Content.SetHtmlContent("<h3>This is parent element</h3>");

            TagBuilder title = new TagBuilder("h1");
            title.InnerHtml.Append(Title);
            title.Attributes["style"] = "display: inline-block; height: 25px; color: navy;";

            TagBuilder container = new TagBuilder("div");
            container.InnerHtml.AppendHtml(title);
            container.AddCssClass("text-center bg-info");

            if (IncludeHeader == true)
                output.PreElement.SetHtmlContent(container);
            if (IncludeFooter == true)
                output.PostElement.SetHtmlContent(container);



        }
    }
}

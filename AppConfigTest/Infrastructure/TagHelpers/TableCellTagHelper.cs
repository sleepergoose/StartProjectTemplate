using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AppConfigTest.Infrastructure.TagHelpers
{
    [HtmlTargetElement(Attributes = "wrap")]
    public class TableCellTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<b><i>");
            output.PostContent.SetHtmlContent("</i></b>");
        }
    }
}

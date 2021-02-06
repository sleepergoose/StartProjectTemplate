using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AppConfigTest.Infrastructure.TagHelpers
{
    [HtmlTargetElement("formbutton")]
    public class FormButtonTagHelper : TagHelper
    {
        public string BgColor { get; set; } = "primary";
        public string Type { get; set; } = "submit";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           // BgColor = context.AllAttributes["bg-color"].Value.ToString() ?? "primary";
           // Type = context.AllAttributes["type"].Value as string ?? "submit";

            output.TagName = "button";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("type", Type);
            output.Attributes.SetAttribute("class", $"btn btn-{BgColor}");
            string content = "";
            if (Type == "submit")
                content = "Add";
            else if (Type == "reset")
                content = "Reset";
            else if(Type == "button")
                content = "Cancel";

            output.Content.SetContent(content);
        }
    }
}

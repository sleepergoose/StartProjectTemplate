using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers; // important

namespace AppConfigTest.Infrastructure.TagHelpers
{
    [HtmlTargetElement("button", Attributes = "bs-button-*")]
    [HtmlTargetElement("a", Attributes = "bs-button-color")]
    public class ButtonTagHelper : TagHelper
    {
        public string BsButtonColor { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            /*if (string.IsNullOrEmpty(BsButtonColor) == false)*/
            output.Attributes.SetAttribute("class", $"btn btn-{BsButtonColor}");
        }
    }
}

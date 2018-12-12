using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApp.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
    }
}

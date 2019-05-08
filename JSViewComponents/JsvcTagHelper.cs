using JSViewComponents.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace JSViewComponents
{
    /// <summary>
    /// TagHelper to include JSViewComponents inside views; for example: 
    /// <example><code>
    /// &lt;jsvc component="tableComponent"&gt;&lt;/jsvc&gt;
    /// </code></example>
    /// </summary>
    [HtmlTargetElement("jsvc", Attributes = ComponentAttributeName)]
    public class JsvcTagHelper : TagHelper
    {
        private const string ComponentAttributeName = "component";
        private readonly IViewComponentHelper _viewComponentHelper;

        public JsvcTagHelper(IViewComponentHelper viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName(ComponentAttributeName)]
        public BaseViewComponent Component { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            try
            {
                ((IViewContextAware)_viewComponentHelper).Contextualize(ViewContext);
                var content = await _viewComponentHelper.InvokeAsync(typeof(BaseViewComponent), new { component = Component });
                output.TagMode = TagMode.StartTagAndEndTag;
                output.Content.SetHtmlContent(content);
            }
            catch (Exception e)
            {
                output.Content.SetHtmlContent(
                    "<p class=\"error\">EXCEPTION rendering JSViewComponent: " + Component?.ComponentFullName + "</p>" + Environment.NewLine +
                    "<!-- " + Environment.NewLine +
                    e.Message + Environment.NewLine +
                    e.StackTrace + Environment.NewLine +
                    "-->"
                );
            }
        }
    }

}

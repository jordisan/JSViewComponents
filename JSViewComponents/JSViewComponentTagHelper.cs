using JSViewComponents.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JSViewComponents
{
    [HtmlTargetElement("jsvc", Attributes = ComponentAttributeName)]
    public class JSViewComponentTagHelper : TagHelper
    {
        private const string ComponentAttributeName = "component";
        private readonly IViewComponentHelper _viewComponentHelper;

        public JSViewComponentTagHelper(IViewComponentHelper viewComponentHelper)
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
            ((IViewContextAware)_viewComponentHelper).Contextualize(ViewContext);

            var content = await _viewComponentHelper.InvokeAsync(typeof(BaseViewComponent), new { component = Component });
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(content);
        }
    }

}

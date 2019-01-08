using Microsoft.AspNetCore.Mvc;

namespace JSViewComponents.Server
{
    public class JSViewComponentController : Controller
    {
        public IActionResult RenderJSViewComponent<Tcomponent>(Tcomponent component) 
            where Tcomponent : JSViewComponents.UI.BaseViewComponent {
            return PartialView(
                JSViewComponents.UI.BaseViewComponent.GetPartialPath(component.ComponentName),
                component
            );
        }
    }
}

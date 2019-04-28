using Microsoft.AspNetCore.Mvc;

namespace JSViewComponents.Server
{
    /// <summary>
    /// Generic MVC controller for JSViewComponents
    /// </summary>
    public class JSViewComponentController : Controller
    {
        /// <summary>
        /// Return the rendered component
        /// </summary>
        /// <typeparam name="Tcomponent"></typeparam>
        /// <param name="component"></param>
        /// <returns></returns>
        public IActionResult RenderJSViewComponentContent<Tcomponent>(Tcomponent component) 
            where Tcomponent : JSViewComponents.UI.BaseViewComponent {
            return PartialView(
                JSViewComponents.UI.BaseViewComponent.GetPartialPath(component.ComponentName),
                component
            );
        }
    }
}

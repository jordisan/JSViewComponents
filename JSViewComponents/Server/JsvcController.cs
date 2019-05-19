using Microsoft.AspNetCore.Mvc;

namespace JSViewComponents.Server
{
    /// <summary>
    /// Generic MVC controller for JSViewComponents
    /// </summary>
    public class JsvcController : Controller
    {
        /// <summary>
        /// Return the rendered component
        /// </summary>
        /// <typeparam name="Tcomponent"></typeparam>
        /// <param name="component"></param>
        /// <returns></returns>
        public IActionResult RenderJSViewComponentContent<Tcomponent>(Tcomponent component) 
            where Tcomponent : JSVC.BaseViewComponent {
            return PartialView(
                JSVC.BaseViewComponent.GetPartialPath(component.ComponentName),
                component
            );
        }
    }
}

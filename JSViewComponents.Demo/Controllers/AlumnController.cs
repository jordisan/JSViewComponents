using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JSViewComponents.Demo.Models;
using JSViewComponents.Server;

namespace JSViewComponents.Demo.Controllers
{
    /// <summary>
    /// Example of a MVC controller for a given JSViewComponent
    /// </summary>
    public class AlumnController : JSViewComponentController
    {
        /// <summary>
        /// Return a rendered table component with all students
        /// </summary>
        /// <param name="sortCriteria"></param>
        /// <returns></returns>
        public IActionResult GetAll(string sortCriteria)
        {
            return RenderJSViewComponent(new JSViewComponents.UI.Table.TableViewComponent(Alumn.SampleAlumns, sortCriteria));
        }
    }
}

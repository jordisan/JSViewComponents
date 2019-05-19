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
    public class CourseController : JsvcController
    {
        /// <summary>
        /// Return a rendered table component with all courses
        /// </summary>
        /// <param name="sortCriteria"></param>
        /// <returns></returns>
        public IActionResult GetAll(string sortCriteria)
        {
            return RenderJSViewComponentContent(new JSVC.Table.TableViewComponent(null, Course.SampleCourses, sortCriteria));
        }
    }
}

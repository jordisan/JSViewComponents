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
    public class AlumnController : JSViewComponentController
    {
        public IActionResult Get(string sortCriteria)
        {
            return RenderJSViewComponent(new JSViewComponents.UI.Table.TableViewComponent(Alumn.SampleAlumns, sortCriteria));
        }
    }
}

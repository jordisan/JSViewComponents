using JSViewComponents.Components.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSViewComponents.Demo.Models
{
    /// <summary>
    /// Example of a model (class) that can be rendered using a table component
    /// </summary>
    public class Course
    {
        [JsvcPropertyAttr("Code", sortable: true)]
        public string Code { get; set; }

        [JsvcPropertyAttr("Course", sortable: true)]
        public string Title { get; set; }

        [JsvcPropertyAttr("Credits", sortable: true)]
        public int Credits { get; set; }

        public static IEnumerable<Course> SampleCourses = new Course[]
            {
                new Course
                {
                    Code="MATH",
                    Title = "Maths",
                    Credits = 32
                },
                new Course
                {
                    Code="ECON",
                    Title = "Economics",
                    Credits = 30
                },
                new Course
                {
                    Code="PHIL",
                    Title = "Philosophy",
                    Credits = 26
                },
                new Course
                {
                    Code="HIST",
                    Title = "History",
                    Credits = 16
                }
            };
    }
}

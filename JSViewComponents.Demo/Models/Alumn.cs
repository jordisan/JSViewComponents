using System;
using System.Collections.Generic;
using JSViewComponents;

namespace JSViewComponents.Demo.Models
{
    /// <summary>
    /// Example of a model (class) that can be rendered using a table component
    /// </summary>
    public class Alumn
    {
        [JsvcPropertyAttr("First name", sortable:true)]
        public string FirstName { get; set; }

        [JsvcPropertyAttr("Last name", sortable:true)]
        public string LastName { get; set; }

        [JsvcPropertyAttr("Birthdate", sortable:false)]
        public DateTime BirthDate { get; set; }

        public Dictionary<string, float> Grades { get; set; }

        public static IEnumerable<Alumn> SampleAlumns = new Alumn[]
            {
                new Alumn
                {
                    FirstName = "John",
                    LastName = "Smith",
                    BirthDate = new DateTime(1991, 1, 1),
                    Grades = new Dictionary<string, float> {
                        { "MATH", (float)7.5 },
                        { "ECON", (float)6.3 },
                        { "PHIL", (float)5.0 },
                        { "HIST", (float)3.2 }
                    }
                },
                new Alumn
                {
                    FirstName = "Boris",
                    LastName = "Spasky",
                    BirthDate = new DateTime(1992, 2, 2),
                    Grades = new Dictionary<string, float> {
                        { "MATH", (float)5.0 },
                        { "ECON", (float)5.2 },
                        { "PHIL", (float)8.0 },
                        { "HIST", (float)9.2 }
                    }
                },
                new Alumn
                {
                    FirstName = "Fulanito",
                    LastName = "De Tal",
                    BirthDate = new DateTime(1993, 3, 3),
                    Grades = new Dictionary<string, float> {
                        { "MATH", (float)3.1 },
                        { "ECON", (float)2.9 },
                        { "PHIL", (float)4.3 },
                        { "HIST", (float)4.8 }
                    }
                },
                new Alumn
                {
                    FirstName = "Li",
                    LastName = "Cheng",
                    BirthDate = new DateTime(1994, 4, 4),
                    Grades = new Dictionary<string, float> {
                        { "MATH", (float)9.1 },
                        { "ECON", (float)8.8 },
                        { "PHIL", (float)3.9 },
                        { "HIST", (float)5.6 }
                    }
                }
            };
    }
}

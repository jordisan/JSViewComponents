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

        public static IEnumerable<Alumn> SampleAlumns = new Alumn[]
            {
                new Alumn
                {
                    FirstName = "John",
                    LastName = "Smith",
                    BirthDate = new DateTime(1991, 1, 1)
                },
                new Alumn
                {
                    FirstName = "Boris",
                    LastName = "Spasky",
                    BirthDate = new DateTime(1992, 2, 2)
                },
                new Alumn
                {
                    FirstName = "Fulanito",
                    LastName = "De Tal",
                    BirthDate = new DateTime(1993, 3, 3)
                },
                new Alumn
                {
                    FirstName = "Li",
                    LastName = "Cheng",
                    BirthDate = new DateTime(1994, 4, 4)
                }
            };
    }
}

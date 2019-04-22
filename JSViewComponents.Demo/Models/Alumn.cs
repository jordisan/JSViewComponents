using JSViewComponents.UI.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSViewComponents.Demo.Models
{
    /// <summary>
    /// Example of a model (class) that can be rendered using a table component
    /// </summary>
    public class Alumn
        : UI.Table.IColumnable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public IEnumerable<Column> ToColumns()
        {
            return new Column[] {
                new Column("FirstName", "First name", this.FirstName, true),
                new Column("LastName", "Last name", this.LastName, true),
                new Column("BirthDate", "Birth date", this.BirthDate.ToShortDateString(), false)
            };
        }

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

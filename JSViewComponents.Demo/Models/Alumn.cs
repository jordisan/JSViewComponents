using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSViewComponents.Demo.Models
{
    public class Alumn
        : UI.Table.IColumnable
    {
        public string FirstName;
        public string LastName;
        public DateTime BirthDate;

        public IDictionary<string, string> ToColumns()
        {
            return new Dictionary<string, string>
            {
                {"First name", this.FirstName },
                {"Last name", this.LastName },
                {"Birth date", this.BirthDate.ToShortDateString() }
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

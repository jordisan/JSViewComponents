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
    public class Subject
        : UI.Table.IColumnable
    {
        public string Title { get; set; }
        public int Credits { get; set; }

        public IEnumerable<Column> ToColumns()
        {
            return new Column[] {
                new Column("Title", "Subject title", this.Title, true),
                new Column("Credits", "Credits", this.Credits, true)
            };
        }

        public static IEnumerable<Subject> SampleSubjects = new Subject[]
            {
                new Subject
                {
                    Title = "Maths",
                    Credits = 32
                },
                new Subject
                {
                    Title = "Economics",
                    Credits = 30
                },
                new Subject
                {
                    Title = "Philosophy",
                    Credits = 26
                },
                new Subject
                {
                    Title = "History",
                    Credits = 16
                }
            };
    }
}

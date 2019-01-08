using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JSViewComponents.UI.Table
{
    public class TableViewComponent : UI.BaseViewComponent
    {
        public IEnumerable<IColumnable> Data;
        public bool Sortable;

        public TableViewComponent(string url) : base(url)
        {}

        public TableViewComponent(IEnumerable<IColumnable> data)
        {
            this.Data = data;
        }

        public override IDictionary<string, object> GetComponentParams()
        {
            return new Dictionary<string, object> {
                { "Sortable", this.Sortable }
            };
        }
    }
}

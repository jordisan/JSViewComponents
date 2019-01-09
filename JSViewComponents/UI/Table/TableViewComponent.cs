using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace JSViewComponents.UI.Table
{
    public class TableViewComponent<Tdata>
        : UI.BaseViewComponent
        where Tdata : IColumnable
    {
        private IEnumerable<Tdata> _Data;
        /// <summary>
        /// Data to be shown as table
        /// </summary>
        public IEnumerable<Tdata> Data => String.IsNullOrEmpty(this.SortCriteria) ? 
            this._Data : 
            this._Data.ToList().AsQueryable().OrderBy(this.SortCriteria);
        protected string SortCriteria;

        /// <summary>
        /// Create table component
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sortCriteria"></param>
        /// <param name="dataUrl"></param>
        public TableViewComponent(IEnumerable<Tdata> data, string sortCriteria = null, string dataUrl = null)
            :base(dataUrl)
        {
            this._Data = data;
            this.SortCriteria = sortCriteria;          
        }
    }
}

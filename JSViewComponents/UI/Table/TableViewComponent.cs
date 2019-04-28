﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JSViewComponents.UI.Table
{
    /// <summary>
    /// Table JSViewComponent
    /// </summary>
    public class TableViewComponent 
        : UI.BaseViewComponent
    {
        private IEnumerable<IColumnable> _Data;
        /// <summary>
        /// Data to be shown as table
        /// </summary>
        public IEnumerable<IColumnable> Data {
            get
            {
                if (String.IsNullOrEmpty(SortCriteria)) return _Data;
                string sortProperty = SortCriteria.Split(' ')[0];
                string sortOrder = (SortCriteria + " ASC").Split(' ')[1];
                if (sortOrder.Equals("ASC", StringComparison.InvariantCultureIgnoreCase))
                {
                    return this._Data.OrderBy(p => p.GetType().GetProperty(sortProperty).GetValue(p, null)).ToList();
                }
                else
                {
                    return this._Data.OrderByDescending(p => p.GetType().GetProperty(sortProperty).GetValue(p, null)).ToList();
                }
            }
        }

        protected string SortCriteria;

        /// <summary>
        /// Create table component
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sortCriteria"></param>
        /// <param name="dataUrl"></param>
        public TableViewComponent(string name, IEnumerable<IColumnable> data, string sortCriteria = null, string dataUrl = null)
            :base(name, dataUrl)
        {
            this._Data = data;
            this.SortCriteria = sortCriteria;          
        }
    }
}

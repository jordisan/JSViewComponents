using System;
using System.Collections.Generic;
using System.Text;

namespace JSViewComponents.UI.Table
{
    /// <summary>
    /// Single column
    /// </summary>
    public class Column 
    {
        /// <summary>
        /// Internal name (usually property or field name)
        /// </summary>
        public string InternalName;
        /// <summary>
        /// Visible table header
        /// </summary>
        public string Header;
        /// <summary>
        /// Value to be shown;
        /// </summary>
        public object Value;
        /// <summary>
        /// If table can be sorted by this column
        /// </summary>
        public bool Sortable;

        public Column(
            string internalName,
            string header,
            object value,
            bool sortable = false
        )
        {
            this.InternalName = internalName;
            this.Header = header;
            this.Value = value;
            this.Sortable = sortable;
        }
    }

    /// <summary>
    /// Any object wich may be rendered as columns
    /// </summary>
    public interface IColumnable
    {
        /// <summary>
        /// Show object as columns
        /// </summary>
        IEnumerable<Column> ToColumns();
    }
}

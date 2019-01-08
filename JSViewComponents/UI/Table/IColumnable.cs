using System;
using System.Collections.Generic;
using System.Text;

namespace JSViewComponents.UI.Table
{
    /// <summary>
    /// Any object wich may be converted to columns
    /// </summary>
    public interface IColumnable
    {
        /// <summary>
        /// Show object as columns
        /// </summary>
        /// <returns> tuple (title, content)</returns>
        IDictionary<string, string> ToColumns();
    }
}

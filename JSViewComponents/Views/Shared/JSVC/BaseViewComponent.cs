using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JSViewComponents.Components
{
    /// <summary>
    /// Base class for any JSViewComponent
    /// </summary>
    public class BaseViewComponent : ViewComponent
    {
        public const string COMPONENTS_PATH = "JSVC/";

        /// <summary>
        /// Unique Id for this component
        /// </summary>
        public readonly string Id = System.Guid.NewGuid().ToString("N");

        /// <summary>
        /// Name for this component
        /// </summary>
        public readonly string Name;
 
        /// <summary>
        /// Server Url to get data from for this component
        /// </summary>
        public readonly Uri DataUrl;

#region CONSTRUCTORS

        public BaseViewComponent() {}
        
        /// <summary>
        /// To be used by subclasses
        /// </summary>
        /// <param name="url"></param>
        protected BaseViewComponent(string name, string dataUrl) : this(name, dataUrl==null ? null : new Uri(dataUrl))
        {}

        protected BaseViewComponent(string name, Uri dataUrl)
        {
            this.Name = name;
            this.DataUrl = dataUrl;
        }

        #endregion
        
        /// <summary>
        /// To remove generic info from type name (we don't want it to compute component name)
        /// </summary>
        /// <returns></returns>
        private string GetFullNameWithoutGenericArity()
        {
            string name = this.GetType().Name;
            int index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }

        public string ComponentFullName => this.GetFullNameWithoutGenericArity();
        public string ComponentName => this.ComponentFullName.EndsWith("ViewComponent") ?
            this.ComponentFullName.Replace("ViewComponent", String.Empty) :
            this.ComponentFullName;

        public Task<IViewComponentResult> InvokeAsync(ViewComponent component)
        {
            return Task.FromResult<IViewComponentResult>(View("~/Views/Shared/" + COMPONENTS_PATH + "Base.cshtml", component));
        }

        public string PartialPath()
        {
            return GetPartialPath(this.ComponentName);
        }

        public string NormalizeString(string str)
        {
            return GetNormalized(str);
        }
        
        /// <summary>
        /// All the components params that would be populated to HTML
        /// </summary>
        /// <returns></returns>
        public virtual IDictionary<string, object> GetComponentParams()
        {
            return new Dictionary<string, object>();
        }

#region STATIC

        internal static string GetNormalized(string str)
        {
            string asc = Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(str));    // remove non-ascii
            Regex reg = new Regex(@"[^\w\d-_]"); // remove special
            return reg.Replace(str, "-").ToLowerInvariant();
        }

        /// <summary>
        /// ToDo: public => internal
        /// </summary>
        /// <param name="componentName"></param>
        /// <returns></returns>
        public static string GetPartialPath(string componentName)
        {
            return COMPONENTS_PATH + componentName + "/" + componentName;
        }

#endregion

    }
}

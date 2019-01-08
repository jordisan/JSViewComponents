using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JSViewComponents.UI
{
    public class BaseViewComponent : ViewComponent
    {
        /// <summary>
        /// Unique Id for this component
        /// </summary>
        public readonly string Id = System.Guid.NewGuid().ToString("N");
 
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
        protected BaseViewComponent(string url) : this(new Uri(url))
        {}

        protected BaseViewComponent(Uri url)
        {
            this.DataUrl = url;
        }

        #endregion

        public string ComponentFullName => this.GetType().Name;
        public string ComponentName => this.ComponentFullName.EndsWith("ViewComponent") ?
            this.ComponentFullName.Replace("ViewComponent", String.Empty) :
            this.ComponentFullName;

        public Task<IViewComponentResult> InvokeAsync(ViewComponent component)
        {
            return Task.FromResult<IViewComponentResult>(View("~/UI/Base.cshtml", component));
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
            return "~/UI/" + componentName + "/" + componentName + ".cshtml";
        }

        #endregion

    }
}

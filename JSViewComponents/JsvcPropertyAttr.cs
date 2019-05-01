
using System.Collections.Generic;
using System.Reflection;

namespace JSViewComponents
{
    /// <summary>
    /// Attribute to define how model properties will be managed by JSViewComponents
    /// </summary>
    public class JsvcPropertyAttr : System.Attribute
    {
        public string Label;
        public bool Sortable;

        public JsvcPropertyAttr(string label, bool sortable)
        {
            this.Label = label;
            this.Sortable = sortable;
        }
    }

    public static class JsvcExtensions
    {
        /// <summary>
        /// Get properties and its attribute(s) defined for using this object in JSViewComponents
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IDictionary<PropertyInfo, IList<JsvcPropertyAttr>> GetJsvcProperties(this object obj)
        {
            Dictionary<PropertyInfo, IList<JsvcPropertyAttr>> propAttrsDict = new Dictionary<PropertyInfo, IList<JsvcPropertyAttr>>();
            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    JsvcPropertyAttr jsvcAttr = attr as JsvcPropertyAttr;
                    if (jsvcAttr != null)
                    {
                        if (! propAttrsDict.ContainsKey(prop))
                        {
                            propAttrsDict[prop] = new List<JsvcPropertyAttr>();
                        }
                        propAttrsDict[prop].Add(jsvcAttr);
                    }
                }
            }
            return propAttrsDict;
        }

    }
}

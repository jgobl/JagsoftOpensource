using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;

namespace JagsoftOpenSource.HtmlHelpers
{
    public static class ActionLinkHelpers
    {
        public static MvcHtmlString BootstrapHighlightedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, Object> htmlAttributes, string activeClass)
        {
            if (actionName.Equals(htmlHelper.ViewContext.RouteData.Values["action"].ToString(), StringComparison.OrdinalIgnoreCase)
                && controllerName.Equals(htmlHelper.ViewContext.RouteData.Values["controller"].ToString(), StringComparison.OrdinalIgnoreCase))
            {
                if (htmlAttributes == null)
                {
                    htmlAttributes = new Dictionary<string, object>();
                    htmlAttributes["class"] = activeClass;
                }
                else
                {
                    string existingClasses = htmlAttributes.ContainsKey("class") ? htmlAttributes["class"].ToString() : string.Empty;
                    htmlAttributes["class"] = string.Format("{0} {1}", existingClasses, activeClass);
                }

            }

            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
        }
    }
}

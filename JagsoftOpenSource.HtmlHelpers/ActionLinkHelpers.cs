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
        public static MvcHtmlString BootstrapHighlightedActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, Object> htmlAttributes, string activeClass, bool matchByAreaOnly = false)
        {
            if (LinkMatches(htmlHelper, actionName, controllerName, routeValues, matchByAreaOnly))
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

        private static bool LinkMatches(HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, bool matchByAreaOnly)
        {            
            string currentArea = htmlHelper.ViewContext.RouteData.DataTokens["area"] == null ? string.Empty : htmlHelper.ViewContext.RouteData.DataTokens["area"].ToString();

            if(matchByAreaOnly)
            {
                if (routeValues != null && routeValues.ContainsKey("Area"))
                {
                    return routeValues["Area"].ToString().Equals(currentArea, StringComparison.OrdinalIgnoreCase);
                }

                return string.IsNullOrWhiteSpace(currentArea);
            }
            
            if(routeValues != null && routeValues.ContainsKey("Area"))
            {               
                return (actionName.Equals(htmlHelper.ViewContext.RouteData.Values["action"].ToString(), StringComparison.OrdinalIgnoreCase)
                && controllerName.Equals(htmlHelper.ViewContext.RouteData.Values["controller"].ToString(), StringComparison.OrdinalIgnoreCase)
                && routeValues["Area"].ToString().Equals(currentArea, StringComparison.OrdinalIgnoreCase));
          
            }

            if (htmlHelper.ViewContext.RouteData.DataTokens["area"] == null)
            {
                return (actionName.Equals(htmlHelper.ViewContext.RouteData.Values["action"].ToString(), StringComparison.OrdinalIgnoreCase)
                   && controllerName.Equals(htmlHelper.ViewContext.RouteData.Values["controller"].ToString(), StringComparison.OrdinalIgnoreCase));
            }

            return false;
                        
        }
    }
}

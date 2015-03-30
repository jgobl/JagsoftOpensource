using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

namespace JagsoftOpenSource.HtmlHelpers
{
    public static class ScriptLinkHelpers
    {
        public static HtmlString ScriptLinkBundle(this HtmlHelper htmlHelper, IList<string> unbundledfiles, string bundledfile, string cachebusterKey = "")
        {
            string scripttags = string.Empty;
            CompilationSection configSection = (CompilationSection)ConfigurationManager.GetSection("system.web/compilation");

            if (configSection.Debug)
            {
                foreach (var file in unbundledfiles)
                {
                    var scripttag = new TagBuilder("script");
                    scripttag.MergeAttribute("type", "text/javascript");
                    scripttag.MergeAttribute("src", file);
                    scripttags += scripttag.ToString();
                }
            }
            else
            {
                var scripttag = new TagBuilder("script");
                scripttag.MergeAttribute("type", "text/javascript");

                if (string.IsNullOrWhiteSpace(cachebusterKey) || ConfigurationManager.AppSettings[cachebusterKey] == null)
                {
                    scripttag.MergeAttribute("src", bundledfile);
                }
                else
                {
                    scripttag.MergeAttribute("src", string.Format("{0}?v={1}", bundledfile, ConfigurationManager.AppSettings[cachebusterKey]));
                }

                scripttags = scripttag.ToString();
            }

            return new HtmlString(scripttags);
        }
    }
}

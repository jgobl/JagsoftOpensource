using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JagsoftOpenSource.FilterAttributes
{
    public class HandleAndLogErrorAttribute : HandleErrorAttribute
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(HandleAndLogErrorAttribute));

        public override void OnException(ExceptionContext filterContext)
        {
            log.Error(string.Format("Url {0} - {1}", filterContext.HttpContext.Request.Url, filterContext.Exception.ToString()));
            base.OnException(filterContext);
        }
    }
}

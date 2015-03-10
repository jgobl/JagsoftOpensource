using JagsoftOpenSource.FilterAttributes;
using System;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(
    typeof(Jagsoft.Web.App_Start.JagsoftOpenSourceFilterAttributesStartUp), "PreStart")]

namespace $rootnamespace$.App_Start {
    public static class JagsoftOpenSourceFilterAttributesStartUp {
        public static void PreStart() {
            GlobalFilters.Filters.Add(new HandleAndLogErrorAttribute());
			log4net.Config.XmlConfigurator.Configure();
        }
    }
}
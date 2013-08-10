using System;
using System.Web;
using System.Web.Mvc;

using WebMarkupMin.Mvc.ActionFilters;

namespace Radyz.Web
{
    public class FilterConfig
    {
        internal static void RegisterGlobalFilters(GlobalFilterCollection globalFilterCollection)
        {
            globalFilterCollection.Add(new MinifyHtmlAttribute());
        }
    }
}
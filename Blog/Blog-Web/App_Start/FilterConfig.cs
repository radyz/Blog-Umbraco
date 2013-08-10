using System;
using System.Web;
using System.Web.Mvc;

using WebMarkupMin.Mvc.ActionFilters;

namespace Blog_Web.App_Start
{
    public class FilterConfig
    {
        internal static void RegisterGlobalFilters(GlobalFilterCollection globalFilterCollection)
        {
            globalFilterCollection.Add(new MinifyHtmlAttribute());
        }
    }
}
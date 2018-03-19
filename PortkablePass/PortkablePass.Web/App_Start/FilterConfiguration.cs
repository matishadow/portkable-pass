using System.Web;
using System.Web.Mvc;

namespace PortkablePass.Web
{
    internal static class FilterConfiguration
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

using System.Web;
using System.Web.Mvc;

namespace AS_CLOUD_HOTEL
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
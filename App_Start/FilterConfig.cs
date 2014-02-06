using System.Web;
using System.Web.Mvc;

namespace IsmsWebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new IsmsWebApplication.Filters.InitializeSimpleMembershipAttribute());
        }
    }
}
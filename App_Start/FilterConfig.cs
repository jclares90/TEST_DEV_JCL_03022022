using System.Web;
using System.Web.Mvc;

namespace TEST_DEV_JCL_03022022
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

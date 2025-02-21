using System.Web;
using System.Web.Mvc;

namespace Nhom_10_QuanLyShopGiayTheThaoSneaker
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

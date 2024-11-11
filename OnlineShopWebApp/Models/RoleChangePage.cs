using OnlineShop.Db.Models;

namespace OnlineShopWebApp.Models
{
    public class RoleChangePage
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public List<RoleViewModel>? Roles { get; set;}
    }
}

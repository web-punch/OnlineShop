using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Введите роль")]
        public string? Name { get; set; }
    }
}

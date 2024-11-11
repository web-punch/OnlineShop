using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserViewModel
    {
        public string? Name { get; set; }


        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 25 символов")]
        public string? FirstName { get; set; }


        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длина фамилии должна быть от 2 до 25 символов")]
        public string? LastName { get; set; }


        [RegularExpression(@"^(\+7|8)\d{10}$", ErrorMessage = "Формат ввода телефона +79999999999 или 89999999999")]
        public string? Phone { get; set; }


        public string? Role {  get; set; }
    }
}

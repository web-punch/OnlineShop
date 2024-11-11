using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Введите логин")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длина логина должна быть от 2 до 25 символов")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Длина пароля от 8 до 16 символов")]
        public string? Password { get; set; }

        public bool IsRemember { get; set; }

        public string? ReturnUrl { get; set; }
    }
}

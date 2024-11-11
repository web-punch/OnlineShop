using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class PasswordChangePage
    {
        public string UserName { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        public string? CurrentPassword { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Длина пароля от 8 до 16 символов")]
        public string? NewPassword { get; set; }


        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string? ConfirmNewPassword { get; set; }

    }
}

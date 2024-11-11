using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class OrderInfoViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Не указан e-mail")]
        [EmailAddress(ErrorMessage = "Неверный формат e-mail")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Не указан телефон")]
        [RegularExpression(@"^(\+7|8)\d{10}$", ErrorMessage = "Формат ввода телефона +79999999999 или 89999999999")]
        public string? Tel { get; set; }
        [Required(ErrorMessage = "Не указан адрес")]
        public string? Address { get; set; }
        public string? Comment { get; set; }
    }
}

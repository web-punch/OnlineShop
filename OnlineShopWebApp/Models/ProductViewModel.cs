using OnlineShopWebApp.ReviewsApi.Models;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите наименование товара")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Введите цену товара")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Введите описание товара")]
        public string? Description { get; set; }
        public List<string> ImagesPaths { get; set; } = new List<string>();
        public int ActiveIndexImagePath { get; set; }

        public List<IFormFile>? UploadedFiles { get; set; }
        public List<Review>? Reviews { get; set; }
        public double Rating 
        {
            get
            {
                var result = Reviews != null && Reviews.Count > 0 ? Reviews.Average(review => review.Grade) : 0;
                return Math.Round(result, 2);
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineStore.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указанно имя товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указанно описание товара")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указанна цена товара")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Не указан путь к картинке товара")]
        public string ImgLink { get; set; }
    }
}

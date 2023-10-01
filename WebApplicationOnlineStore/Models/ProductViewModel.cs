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

        public ProductViewModel()
        {
            Id = Guid.NewGuid();
        }
        public ProductViewModel(string name, string description, decimal cost, string imgLink) : this()
        {
            Name = name;
            Description = description;
            Cost = cost;
            ImgLink = imgLink;
        }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Cost}";
        }
    }
}

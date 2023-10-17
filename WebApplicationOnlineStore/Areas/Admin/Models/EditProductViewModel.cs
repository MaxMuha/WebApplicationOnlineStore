using System.ComponentModel.DataAnnotations;
using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore.Areas.Admin.Models
{
    public class EditProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указанно имя товара")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указанно описание товара")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указанна цена товара")]
        [Range(1, 200000, ErrorMessage = "Цена должна быть от 1 до 200 000 тыс.")]
        public decimal Cost { get; set; }

        public List<string> ImagesPaths { get; set; }
        public IFormFile[] UploadedFiles { get; set; }
    }
}

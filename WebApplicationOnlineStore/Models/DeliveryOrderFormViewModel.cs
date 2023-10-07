using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineStore.Models
{
    public class DeliveryOrderFormViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Имя должно содержать от 2 до 15 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Фамилия должна содержать от 2 до 20 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан телефон")]
        [RegularExpression(@"^\+[1-9] \d{3} \d{3} \d{2} \d{2}$", ErrorMessage = "Введите валидный номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан EMAIL")]
        [EmailAddress(ErrorMessage = "Не правильно введен EMAIL")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан город")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Название города должно содержать от 2 до 15 символов")]
        public string City { get; set; }

        [Required(ErrorMessage = "Не указан регион")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Название региона должно содержать от 2 до 15 символов")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Не указан индекс")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Не указана адресс")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Адресс должен содержать от 2 до 15 символов")]
        public string Address { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineStore.Areas.Admin.Models
{
    public class ChangePassword
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}

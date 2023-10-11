using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineStore.Models
{
    public class Login
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Логин должен содержать от 2 до 15 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [PasswordPropertyText]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}

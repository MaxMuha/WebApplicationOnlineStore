using System.ComponentModel.DataAnnotations;
using WebApplicationOnlineStore.Areas.Admin.Models;

namespace WebApplicationOnlineStore.Models
{
    public class Register
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        public string? ReturnUrl { get; set; }
        public RoleViewModel Role { get; set; }
        public Register()
        {
            Id = Guid.NewGuid();
            Role = new RoleViewModel() { Name = "User" };
        }
    }
}

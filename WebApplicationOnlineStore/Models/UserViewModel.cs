using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineStore.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required(ErrorMessage = "Роль не указанна")]
        public RoleViewModel Role { get; set; }
    }
}

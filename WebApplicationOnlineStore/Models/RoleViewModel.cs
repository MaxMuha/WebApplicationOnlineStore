using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineStore.Models
{
    public class RoleViewModel
    {
        [Required]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var role = (RoleViewModel)obj;
            return Name == role.Name;    
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineStore.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
    }
}

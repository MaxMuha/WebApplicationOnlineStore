using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public class RolesRepository : IRoles
    {
        private readonly List<Role> roles = new List<Role>();

        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetByName(string name)
        {
            return roles.FirstOrDefault(role => role.Name == name);
        }

        public void Add(Role role)
        {
            roles.Add(role);
        }

        public void Remove(Role role)
        {
            roles.Remove(role);
        }
    }
}

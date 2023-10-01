using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public interface IRoles
    {
        List<Role> GetAll();
        Role TryGetByName(string name);
        void Add(Role role);
        void Remove(Role role);
    }
}

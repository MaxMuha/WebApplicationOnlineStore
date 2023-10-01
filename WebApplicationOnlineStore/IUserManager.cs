using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public interface IUserManager
    {
        void Add(UserAccount user);
        void ChangePassword(Guid id, string newPassword);
        List<UserAccount> GetAll();
        void Remove(UserAccount userAccount);
        UserAccount TryGetById(Guid id);
        UserAccount TryGetByName(string userName);
        void Update(UserAccount user);
        void UpdateRole(Guid id, Role role);
    }
}
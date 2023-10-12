using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public interface IUserManager
    {
        void Add(UserViewModel user);
        void ChangePassword(Guid id, string newPassword);
        List<UserViewModel> GetAll();
        void Remove(UserViewModel userAccount);
        UserViewModel TryGetById(Guid id);
        UserViewModel TryGetByName(string userName);
        void Update(UserViewModel user);
        void UpdateRole(Guid id, Role role);
    }
}
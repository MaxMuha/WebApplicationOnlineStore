using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public class UserManager : IUserManager
    {
        private readonly List<UserViewModel> users = new List<UserViewModel>();
        public List<UserViewModel> GetAll()
        {
            return users;
        }
        public void Add(UserViewModel user)
        {
            users.Add(user);
        }
        public UserViewModel TryGetById(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
        public UserViewModel TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
        }
        public void Update(UserViewModel user)
        {
            var existingAccount = users.FirstOrDefault(x => x.Id == user.Id);
            if (existingAccount == null)
            {
                return;
            }
            existingAccount.Name = user.Name;
        }
        public void ChangePassword(Guid id, string newPassword)
        {
            var userAccount = TryGetById(id);
            userAccount.Password = newPassword;
        }
        public void Remove(UserViewModel userAccount)
        {
            users.Remove(userAccount);
        }
        public void UpdateRole(Guid id, RoleViewModel role)
        {
            var userAccount = TryGetById(id);
            userAccount.Role = role;
        }
    }
}

using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public class UserManager : IUserManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();
        public List<UserAccount> GetAll()
        {
            return users;
        }
        public void Add(UserAccount user)
        {
            users.Add(user);
        }
        public UserAccount TryGetById(Guid id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }
        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
        }
        public void Update(UserAccount user)
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
        public void Remove(UserAccount userAccount)
        {
            users.Remove(userAccount);
        }
        public void UpdateRole(Guid id, Role role)
        {
            var userAccount = TryGetById(id);
            userAccount.Role = role;
        }
    }
}

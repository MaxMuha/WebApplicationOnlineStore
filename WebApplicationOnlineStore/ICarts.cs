using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public interface ICarts
    {
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void Remove(Product product, string userId);
        void Clear(string userId);
    }
}

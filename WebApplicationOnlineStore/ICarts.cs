using WebApplicationOnlineStore.Models;

namespace WebApplicationOnlineStore
{
    public interface ICarts
    {
        Cart TryGetByUserId(string userId);
        void Add(ProductViewModel product, string userId);
        void Remove(ProductViewModel product, string userId);
        void Clear(string userId);
    }
}

namespace OnlineShop.Db.Models
{
    public class WatchList
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; }
    }
}

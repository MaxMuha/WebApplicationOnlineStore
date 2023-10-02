namespace WebApplicationOnlineStore.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DeliveryOrderForm Form { get; set; }
        public List<CartItemViewModel> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDateTime { get; set; }
        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreateDateTime = DateTime.Now;
        }

        public decimal Total
        {
            get
            {
                return OrderItems?.Sum(i => i.Amount) ?? 0;
            }
        }
    }
}

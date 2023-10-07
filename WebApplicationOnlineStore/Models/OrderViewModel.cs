namespace WebApplicationOnlineStore.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DeliveryOrderFormViewModel Form { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public OrderStatusViewModels Status { get; set; }
        public DateTime CreateDateTime { get; set; }

        public decimal Total
        {
            get
            {
                return Items?.Sum(i => i.Amount) ?? 0;
            }
        }
    }
}

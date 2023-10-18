namespace OnlineShop.Db.Models
{
    public enum OrderStatus
    {
        //[Display(Name = "Создан")]
        Created,

        //[Display(Name = "Обработан")]
        Processed,

        //[Display(Name = "Отправлен")]
        Delivering,

        //[Display(Name = "Доставлен")]
        Delivered,

        //[Display(Name = "Отменён")]
        Canseled
    }
}
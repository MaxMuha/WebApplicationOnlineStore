using System.ComponentModel.DataAnnotations;

namespace WebApplicationOnlineStore.Models
{
    public enum OrderStatusViewModels
    {
        [Display(Name = "Создан")]
        Created,

        [Display(Name = "Обработан")]
        Processed,

        [Display(Name = "Отправлен")]
        Delivering,

        [Display(Name = "Доставлен")]
        Delivered,

        [Display(Name = "Отменён")]
        Canseled
    }
}
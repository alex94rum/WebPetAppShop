using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Db.Model
{
    public enum OrderStatus
    {
        Created,
        Processed,
        Delivering,
        Delivered,
        Canceled,
    }
}
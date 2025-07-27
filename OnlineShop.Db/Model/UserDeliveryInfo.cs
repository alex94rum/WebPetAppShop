using System;

namespace OnlineShop.Db.Model
{
    public class UserDeliveryInfo
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string Phone { get; set; }
    }
}

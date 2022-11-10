using System;

namespace TestTask.Web.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddress { get; set; }
        public int CargoWeight { get; set; }
        public DateTime PickupDate { get; set; }
    }
}

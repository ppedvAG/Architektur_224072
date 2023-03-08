namespace ppedv.SchrottyCar.Model
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual Customer? Customer { get; set; }
        public virtual Address? BillingAddress { get; set; }
        public virtual Address? DeliveryAddress { get; set; }

    }
}
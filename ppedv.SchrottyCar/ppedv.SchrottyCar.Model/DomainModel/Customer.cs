namespace ppedv.SchrottyCar.Model.DomainModel
{
    public class Customer : Entity
    {
        public string CustomerId { get; set; } = string.Empty;

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual Address? HomeAddress { get; set; }

    }
}
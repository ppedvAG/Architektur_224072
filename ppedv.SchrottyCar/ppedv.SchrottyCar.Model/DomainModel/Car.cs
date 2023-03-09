namespace ppedv.SchrottyCar.Model.DomainModel
{
    public class Car : Entity
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int KW { get; set; }
        public DateTime BuildDate { get; set; } = DateTime.Now;
        public string Color { get; set; } = string.Empty;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
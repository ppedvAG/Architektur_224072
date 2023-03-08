namespace ppedv.SchrottyCar.Model
{
    public class OrderItem : Entity
    {
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Car? Car { get; set; }
    }
}
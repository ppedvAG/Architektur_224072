namespace ppedv.SchrottyCar.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
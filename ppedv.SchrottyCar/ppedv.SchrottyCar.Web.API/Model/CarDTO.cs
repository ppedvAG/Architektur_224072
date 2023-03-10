namespace ppedv.SchrottyCar.Web.API.Model
{
    public class CarDTO
    {
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int KW { get; set; }
        public DateTime BuildDate { get; set; } = DateTime.Now;
        public string Color { get; set; } = string.Empty;

        public int Id { get; set; }
    }
}

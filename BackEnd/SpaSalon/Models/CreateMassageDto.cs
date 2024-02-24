namespace SpaSalon.Models
{
    public class CreateMassageDto
    {
        public string ServiceName { get; set; }
        public int ServiceTime { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}

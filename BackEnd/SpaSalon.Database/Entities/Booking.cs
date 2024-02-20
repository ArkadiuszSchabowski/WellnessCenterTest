using SpaSalon.Database.Enums;

namespace SpaSalon.Database.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public int ServiceTime { get; set; }
        public decimal Price { get; set; }
        public PerformerType Performer { get; set; } = PerformerType.Anyone;
        public string? Description { get; set; }
    }
}

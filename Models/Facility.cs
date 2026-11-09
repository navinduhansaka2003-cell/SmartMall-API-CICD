namespace SmartMall.API.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Link to the floor where this facility is located
        public int FloorId { get; set; }
        public Floor? Floor { get; set; }
    }
}
namespace SmartMall.API.Models
{
    public class MapNode
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double X { get; set; }
        public double Y { get; set; }

        public int FloorId { get; set; }
        public Floor? Floor { get; set; }
    }
}
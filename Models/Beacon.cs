namespace SmartMall.API.Models
{
    public class Beacon
    {
        public int Id { get; set; }
        public string MacAddress { get; set; } = string.Empty;

        public int MapNodeId { get; set; }
        public MapNode? MapNode { get; set; }
    }
}
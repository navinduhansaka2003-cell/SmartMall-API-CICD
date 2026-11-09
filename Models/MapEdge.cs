namespace SmartMall.API.Models
{
    public class MapEdge
    {
        public int Id { get; set; }
        public int StartNodeId { get; set; }
        public int EndNodeId { get; set; }
        public double Distance { get; set; }
    }
}
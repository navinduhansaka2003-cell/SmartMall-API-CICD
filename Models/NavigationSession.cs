namespace SmartMall.API.Models
{
    public class NavigationSession { 
        public int Id { get; set; }
        public string SessionId { get; set; } = string.Empty;
        public int DestinationNodeId { get; set; }
    }
}
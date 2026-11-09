namespace SmartMall.API.Models
{
    public class Promotion { 
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ShopId { get; set; }
        public Shop? Shop { get; set; } }
}
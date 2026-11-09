namespace SmartMall.API.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }

        // Navigation property for related shops
        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
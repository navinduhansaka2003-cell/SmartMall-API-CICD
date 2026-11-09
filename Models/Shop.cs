namespace SmartMall.API.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        
        public string ImageUrl { get; set; } = string.Empty;
        public string UnitNumber { get; set; } = string.Empty;

        // Foreign Keys
        public int FloorId { get; set; }
        public Floor? Floor { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        // Inside SmartMall.API.Models.Shop
        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public string HotlineNumber { get; set; } = string.Empty;
    }


}
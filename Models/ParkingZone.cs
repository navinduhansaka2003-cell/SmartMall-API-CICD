namespace SmartMall.API.Models
{
    public class ParkingZone { 
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ParkingFloorId { get; set; } 
        public ParkingFloor? ParkingFloor { get; set; } }
}
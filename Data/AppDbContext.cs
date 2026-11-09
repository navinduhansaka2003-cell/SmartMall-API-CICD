using Microsoft.EntityFrameworkCore;
using SmartMall.API.Models;

namespace SmartMall.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<EntertainmentModel> Entertainment { get; set; }//add entertainment

        public DbSet<Category> Categories { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        public DbSet<MapNode> MapNodes { get; set; }
        public DbSet<MapEdge> MapEdges { get; set; }
        public DbSet<Beacon> Beacons { get; set; }

        public DbSet<ParkingFloor> ParkingFloors { get; set; }
        public DbSet<ParkingZone> ParkingZones { get; set; }
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingSession> ParkingSessions { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<NavigationSession> NavigationSessions { get; set; }

        public DbSet<FoodDining> FoodDining { get; set; }
    }
}
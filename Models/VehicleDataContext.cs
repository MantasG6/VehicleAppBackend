using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class VehicleDataContext : DbContext
    {
        public VehicleDataContext(DbContextOptions<VehicleDataContext> options) : base(options)
        {
            
        }
        public DbSet<VehicleData> VehicleDatas { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VehicleData>()
                .HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(vd => vd.VehicleNumber);
        }
    }
}

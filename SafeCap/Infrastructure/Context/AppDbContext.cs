using SafeCap.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SafeCap.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("SC_Users");
            modelBuilder.Entity<SensorReading>().ToTable("SC_SensorReadings");
            modelBuilder.Entity<Alert>().ToTable("SC_Alerts");
        }
    }
}

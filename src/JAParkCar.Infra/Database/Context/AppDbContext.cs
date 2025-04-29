using JAParkCar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JAParkCar.Infra.Database.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarSpace> CarSpaces { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var databasePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "japarkcar.sqlite");
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }
    }
}
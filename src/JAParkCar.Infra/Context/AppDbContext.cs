using JAParkCar.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JAParkCar.Infra.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarSpace> CarSpaces { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\STUDY\\DotNet\\JAParkCar\\Database\\japarkcar.db");
        }
    }
}
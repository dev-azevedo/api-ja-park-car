using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JAParkCar.Infra.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=D:\\STUDY\\DotNet\\JAParkCar\\Database\\japarkcar.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}
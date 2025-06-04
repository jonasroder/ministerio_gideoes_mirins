//using Core.Authentication.Entities;
//using Core.Gaming.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    //public DbSet<User> User { get; set; }
    //public DbSet<Game> Games { get; set; }
    //public DbSet<GamePlatform> GamePlatforms { get; set; }
    //public DbSet<GameGenre> GameGenres { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        /* modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.ClienteConfiguration());
         modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.LivroConfiguration());
         modelBuilder.ApplyConfiguration(new Infrastructure.Configuration.PedidoConfiguration());*/
    }

}
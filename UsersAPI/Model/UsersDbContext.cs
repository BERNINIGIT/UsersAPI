using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Model
{
    public class UsersDbContext : DbContext
    {
        private static bool _created = false;
        public DbSet<User> Users { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.Migrate();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(s => s.Login);
            modelBuilder.Entity<User>().Property(s => s.UsdBalance)
                .HasColumnName("USD_balance");
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Login = "bernini",
                    Password = "B3rn1n1",
                    Role = "admin",
                    UsdBalance = 50003.4M
                },
                new User
                {
                    Login = "admin1",
                    Password = "admin1",
                    Role = "admin",
                    UsdBalance = 57703.4M
                },
                new User
                {
                    Login = "guest1",
                    Password = "g35t",
                    Role = "user",
                    UsdBalance = 105.1M
                },
                new User
                {
                    Login = "guest2",
                    Password = "g35t",
                    Role = "user",
                    UsdBalance = 105.1M
                },
                new User
                {
                    Login = "guest3",
                    Password = "g35t",
                    Role = "user",
                    UsdBalance = 105.1M
                }
            );
        }
    }
}

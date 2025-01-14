using Microsoft.EntityFrameworkCore;
using ReactorControlSystem.Repositories.Models;

namespace ReactorControlSystem.Repositories.Data
{
    public class AppDbContext : DbContext
    {
        public static readonly string connectionString = "Server=R9000P\\SQLEXPRESS; Database=Reactor; Trusted_Connection=True; TrustServerCertificate=True";

        public DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

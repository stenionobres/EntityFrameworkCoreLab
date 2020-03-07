using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts
{
    public class ExperimentsDbContext : DbContext
    {
        private const string ConnectionString = @"Server=192.168.1.14,22331;Database=Experiments;User ID=sa;Password=sqlserver.252707;
                                                  Encrypt=False;Trusted_Connection=False;Connection Timeout=3000;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}

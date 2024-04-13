using Microsoft.EntityFrameworkCore;

namespace RetoBCP.Domain
{
    public class ExchangeRateDbContext : DbContext
    {
        public ExchangeRateDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}

using FrenetCalculate.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FrenetCalculate.Data
{
    public class FreightQuoteDbContext : DbContext
    {
        public DbSet<FreightQuote> FreightQuotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string conn = "Server=localhost,1433;Database=FrenetDB;User ID=sa;Password=example_123;TrustServerCertificate=True";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn);
            }
        }
    }
}

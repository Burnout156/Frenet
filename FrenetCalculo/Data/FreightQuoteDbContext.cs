using FrenetCalculate.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FrenetCalculate.Data
{
    public class FreightQuoteDbContext : DbContext
    {
        public DbSet<FreightQuote> FreightQuotes { get; set; }
        public DbSet<TrackingEvent> TrackingEvents { get; set; }

        public FreightQuoteDbContext(DbContextOptions<FreightQuoteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeamento da tabela TrackingEvent
            modelBuilder.Entity<TrackingEvent>(entity =>
            {
                entity.ToTable("TrackingEvent");
                entity.HasKey(e => e.Id);
                // Mapeie as propriedades da classe TrackingEvent para as colunas correspondentes na tabela
                entity.Property(e => e.Id).HasColumnName("Id").IsRequired();
                entity.Property(e => e.EventDateTime).HasColumnName("EventDateTime").IsRequired();
                entity.Property(e => e.EventDescription).HasColumnName("EventDescription").IsRequired();
                entity.Property(e => e.EventLocation).HasColumnName("EventLocation").IsRequired();
                entity.Property(e => e.EventType).HasColumnName("EventType").IsRequired();
                entity.HasOne(e => e.FreightQuote)
                    .WithMany(fq => fq.TrackingEvents)
                    .HasForeignKey(e => e.FreightQuoteId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}

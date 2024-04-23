using TheRecordStore.Models;
using Microsoft.EntityFrameworkCore;

namespace TheRecordStore.Data
{
    public class RecordStoreContext : DbContext
    {
        public RecordStoreContext(DbContextOptions<RecordStoreContext> options) : base(options)
        {
        }

        public DbSet<Record> Records { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().ToTable("Record")
            .HasOne(r => r.Order)
            .WithMany(o => o.Records)
            .HasForeignKey(r => r.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}
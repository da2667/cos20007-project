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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().ToTable("Record");
        }
    }
}
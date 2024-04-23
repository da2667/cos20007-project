using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace TheRecordStore.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<RecordStoreContext>
    {
        public RecordStoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordStoreContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RecordStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new RecordStoreContext(optionsBuilder.Options);
        }
    }
}
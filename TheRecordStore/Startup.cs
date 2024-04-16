using Microsoft.EntityFrameworkCore;
using TheRecordStore.Data;
using System.Configuration;
namespace TheRecordStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            string? connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<RecordStoreContext>(options => options.UseSqlServer(connectionString));

            services.AddMvc();
        }

        public void Configure(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<RecordStoreContext>();
        }
    }
}

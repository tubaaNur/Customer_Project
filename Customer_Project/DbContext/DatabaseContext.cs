using Customer_Project.DbModel;
using Microsoft.EntityFrameworkCore;

namespace Customer_Project.Properties.Models
{

    public class DataBaseContext : DbContext
    {

        //public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PostgreSqlConnectionString");
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<CustomerEntities> CustomersEntities { get; set; }
       



    }
}
             
       
    
    

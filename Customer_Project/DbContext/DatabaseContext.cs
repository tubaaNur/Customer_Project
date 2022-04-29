using Customer_Project.DbModel;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Customer_Project.Properties.Models
{

    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PostgreSqlConnectionString");
            optionsBuilder.UseNpgsql(connectionString);
        }
        public override int SaveChanges()
        {
            CustomerDelete();
            return base.SaveChanges();
        }
        private void CustomerDelete()
        {
            var entities = ChangeTracker.Entries()
                                .Where(e => e.State == EntityState.Deleted);
            foreach (var entity in entities)
            {
                if (entity.Entity is CustomerEntities)
                {
                    entity.State = EntityState.Modified;
                    var customer = entity.Entity as CustomerEntities;
                    customer.Soft_delete = false;
                }
            }
        }
        public DbSet<CustomerEntities> customer { get; set; }

    }
}





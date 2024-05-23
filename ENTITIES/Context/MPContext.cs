using ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace ENTITIES.Context
{
    public interface IMPContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync();
    }

    public class MPContext : DbContext, IMPContext
    {
        public MPContext(DbContextOptions<MPContext> options) : base(options)
        {
        }

        //Create Tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Creating the conection to the database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //     optionsBuilder.UseSqlServer(@"Server=.;Database=ProductSystem;Trusted_Connection=True;TrustServerCertificate=True;");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=ProductMSystem;Trusted_Connection=True;TrustServerCertificate=True;",
                b => b.MigrationsAssembly("WebAPIManagingProductWithRepositoryPattern"));
        }


        /// <summary>
        /// Saving in async the changes in the database
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

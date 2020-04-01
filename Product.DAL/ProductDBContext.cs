using Microsoft.EntityFrameworkCore;

namespace Product.DAL
{
    public sealed class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options)
            : base(options)
        {
        }

        public DbSet<ProductEntity> ProductModel { get; set; }

        ////Uncomment only during migrations and database update
        ////------------------------------------------------------------
        //public ProductDBContext()
        //{

        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;database=ProductDB;user=dev;password=password");
        //}
        ////-------------------------------------------------------------
    }
}
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UnitOfWorkDemo.Core.Models;
using Microsoft.EntityFrameworkCore.Design;

namespace UnitOfWorkDemo.Infrastructure
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DbContextClass>
    {
        public DbContextClass CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContextClass>();
            optionsBuilder.UseSqlServer("Data Source=.;database=UnitOfWorkDemoDB; User Id=sa;Password=123;MultipleActiveResultSets=True;");
            return new DbContextClass(optionsBuilder.Options);
        }
    }
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog = UnitOfWorkDemoDB; User Id=sa;Password=123");
        }

        public DbSet<ProductDetails> Products { get; set; }
    }
}

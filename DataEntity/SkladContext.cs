using DataEntity.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataEntity
{
    public class SkladContext : DbContext
    {
        public DbSet<Material> Materialy => Set<Material>();
        public DbSet<MernaJednotka> MerneJednotky => Set<MernaJednotka>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog=SkladDbDemo1;" +
                    "Integrated Security=True;" +
                    "TrustServerCertificate=True").UseLazyLoadingProxies();
            }
        }
        
        
     
    }
}
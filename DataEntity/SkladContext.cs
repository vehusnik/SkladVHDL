using DataEntity.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataEntity
{
    // Tato třída představuje "vstupní bránu" do databáze.
    // Pomocí této třídy můžeš číst a zapisovat data do tabulek v databázi.
    public class SkladContext : DbContext // DbContext je základní třída pro práci s databází v Entity Framework
    {
        // Umožňuje získat, přidat, upravit nebo smazat záznamy typu Material v databázi.
        public DbSet<Material> Materialy => Set<Material>();
        public DbSet<MerneJednotky> MerneJednotky => Set<MerneJednotky>();

        // Tato metoda říká, jak se má připojit k databázi.
        // Pokud ještě není připojení nastaveno, použije zde uvedený connection string.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Kontrola, jestli už není připojení nastaveno někde jinde.
            if (!optionsBuilder.IsConfigured)
            {
                // Nastaví připojení k databázi na tvém počítači (LocalDB).
                // "SkladDbDemo1" je název databáze.
                // Integrated Security=True znamená, že se použije přihlášení do Windows.
                // TrustServerCertificate=True je kvůli bezpečnosti spojení.
                // UseLazyLoadingProxies umožňuje automaticky načítat související data až když jsou potřeba.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;" +
                    "Initial Catalog=SkladDbDemo1;" +
                    "Integrated Security=True;" +
                    "TrustServerCertificate=True").UseLazyLoadingProxies();
            }
        }

        public void Seed()
        {
            if (MerneJednotky.Any())

            {
                return; // DB has been seeded
            }

            var mJks = new MerneJednotky { Popis = "ks" };
            var mJKg = new MerneJednotky { Popis = "Kg" };
            var mjM3 = new MerneJednotky { Popis = "m3" };

            var materialSroub = new Material
            {
                Nazev = "Šroub 6x40",
                MnoDoPal = 5000,
                MnozPoj = 100,
                DatumPridani = System.DateTime.Now,
                MernaJednotka = mJks
            };
            var materialHrebik = new Material
             {
                Nazev = "Hřebík 3x50",
                MnoDoPal = 3000,
                MnozPoj = 200,
                DatumPridani = System.DateTime.Now,
                MernaJednotka = mJks
            };
        }


    }
}
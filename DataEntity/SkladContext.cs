using DataEntity.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataEntity
{
    public class SkladContext : DbContext
    {
        public DbSet<Material> Materialy { get; set; } = null!;
        public DbSet<MernaJednotka> MerneJednotky { get; set; } = null!;
        public DbSet<Paleta> Palety { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(
                        // uprav na svůj connection string (původní LocalDB / prod)
                        "Data Source=(localdb)\\MSSQLLocalDB;" +
                        "Initial Catalog=Sklad2025;" +
                        "Integrated Security=True;" +
                        "TrustServerCertificate=True")
                    .UseLazyLoadingProxies();
            }
        }

        public void Seed()
        {
            // Kontrola, zda již v DB nejsou data, aby se zabránilo duplicitám.
            if (MerneJednotky.Any())
            {
                return; // Databáze již byla naplněna.
            }

            // Vytvoření měrných jednotek
            var mjKs = new MernaJednotka { Popis = "ks" };
            var mjKg = new MernaJednotka { Popis = "kg" };
            var mjM3 = new MernaJednotka { Popis = "m3" };

            // Vytvoření materiálů s přímým odkazem na objekt měrné jednotky
            var materialSroub = new Material
            {
                Nazev = "Šroub",
                MnozPoj = 1000,
                MnozDoPal = 2000,
                Datum = DateTime.Now,
                MernaJednotka = mjKs // Přímé přiřazení objektu
            };

            var materialHrebik = new Material
            {
                Nazev = "Hřebík",
                MnozPoj = 1500,
                MnozDoPal = 1000,
                Datum = DateTime.Now,
                MernaJednotka = mjKs // Přímé přiřazení objektu
            };

            // Vytvoření palet s přímým odkazem na objekt materiálu
            var palety = new[]
            {
                new Paleta
                {
                    Stav = Enums.PaletaStav.Vyskladneno,
                    Typ = Enums.PaletaTyp.Velka,
                    Material = materialSroub, // Přímé přiřazení objektu
                	AdresaUlozeni = "M10",
                    Mnozstvi = 500
                },
                new Paleta
                {
                    Stav = Enums.PaletaStav.Vyskladneno,
                    Typ = Enums.PaletaTyp.Velka,
                    Material = materialSroub, // Přímé přiřazení objektu
                	AdresaUlozeni = "M2",
                    Mnozstvi = 750
                },
                new Paleta
                {
                    Stav = Enums.PaletaStav.Vyskladneno,
                    Typ = Enums.PaletaTyp.Velka,
                    Material = materialHrebik, // Přímé přiřazení objektu
                	AdresaUlozeni = "M2/5",
                    Mnozstvi = 1000
                }
            };

            // Přidání všech nových objektů do kontextu
            MerneJednotky.AddRange(mjKs, mjKg, mjM3);
            Materialy.AddRange(materialSroub, materialHrebik);
            Palety.AddRange(palety);

            // Jediné finální uložení všech změn do databáze
            SaveChanges();
        }
    }
}
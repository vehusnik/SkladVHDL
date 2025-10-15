using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntity.Data.Base;
using PropertyChanged;


namespace DataEntity.Data
{
    [AddINotifyPropertyChangedInterface]
    [Table("Materials")]

    // Obsahuje základní informace o materiálu, včetně množství, data přidání, komentáře a vazby na měrnou jednotku.
    public class Material : BaseModel
    {
        // Primární klíč, jednoznačně identifikuje materiál.
        // Vlastnost s get a set umožňuje čtení i zápis hodnoty zvenčí třídy.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialID { get; set; }

        // Název materiálu (max. 60 znaků, povinné).

        [Required, StringLength(60)]
        public string Nazev { get; set; } = string.Empty;

        // Pojistné množství materiálu (povinné).
        [Required, StringLength(30)]
        public int MnozPoj { get; set; }

        // Množství materiálu do palety (povinné).
        [Required, StringLength(30)]
        public int MnoDoPal { get; set; }

        // Datum a čas, kdy byl materiál přidán do systému. Výchozí hodnota je aktuální datum a čas.
        public DateTime DatumPridani { get; set; } = DateTime.Now;

        // Volitelný komentář k materiálu.
        public string? Komentar { get; set; } = string.Empty;

        // Cizí klíč na měrnou jednotku.
        public int MernaJednotkaID { get; set; }

        // Navigační vlastnost na entitu MernaJednotka, která určuje měrnou jednotku materiálu.

        [ForeignKey("MernaJednotkaID")]
        public virtual required MerneJednotky MernaJednotka { get; set; }

    }
}
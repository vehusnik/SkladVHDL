using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;


namespace DataEntity.Data
{
    [AddINotifyPropertyChangedInterface]
    [Table("Materials")]


    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaterialID { get; set; }

        [Required, StringLength(60)]
        public string Nazev { get; set; } = string.Empty;
        [Required, StringLength(30)]
        public int MnozPoj { get; set; }
        [Required, StringLength(30)]
        public int MnoDoPal { get; set; }

        public DateTime DatumPridani { get; set; } = DateTime.Now;
        public string? Komentar { get; set; } = string.Empty;

        public int MernaJednotkaID { get; set; }
        [ForeignKey("MernaJednotkaID")]
        public virtual required MernaJednotka MernaJednotka { get; set; }

    }
}
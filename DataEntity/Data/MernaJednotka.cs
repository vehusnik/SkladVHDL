using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace DataEntity.Data
{

    [Table("MerneJednotky")]
    [AddINotifyPropertyChangedInterface]
    public class MerneJednotky
        {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int MernaJednotkaID { get; set; }

            [Required, StringLength(50, ErrorMessage = "Popis maximálně na 50 znaků")]
            public string Popis { get; set; } = string.Empty;

            public virtual ObservableCollection<Material> Materials { get; set; } = null!;

    }


}

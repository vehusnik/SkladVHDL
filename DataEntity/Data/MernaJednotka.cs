using DataEntity.Data.Base;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Data
{

    [AddINotifyPropertyChangedInterface]
    [Table("MerneJednotky")]
    public class MernaJednotka : BaseModel
    {
        [Key]
        public int MernaJednotkaId { get; set; }

        [StringLength(50)]
        public string? Popis { get; set; }

        public virtual ObservableCollection<Material> Materialy { get; set; }
            = new ObservableCollection<Material>();

    }


}

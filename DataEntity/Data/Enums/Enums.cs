using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity.Data.Enums
{
    public class Enums
    {
        public enum PaletaTyp
        {
            [Description("Malá")]
            Mala = 0,
            [Description("Velká")]
            Velka = 1,
            [Description("Dělená(pro tyčový materiál")]
            Delena = 2
        }
        public enum PaletaStav
        {
            [Description("Zaskladnění")]
            Zaskladneni = 0,
            [Description("Vyskladnění")]
            Vyskladneni = 1,
            [Description("V dopravě")]
            VDoprave = 2
        }
    }
}

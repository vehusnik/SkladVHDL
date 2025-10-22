using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    public static class Enums
    {
        public enum PaletaTyp
        {
            [Description("Malá")] Mala = 0,
            [Description("Velká")] Velka = 1,
            [Description("Euro")] Euro = 2
        }

        public enum PaletaStav
        {
            [Description("Zaskladněno")] Zaskladneno = 0,
            [Description("Vyskladněno")] Vyskladneno = 1,
            [Description("V dopravě")] Doprava = 2
        }
    }
}

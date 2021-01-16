using System;
using System.Collections.Generic;

namespace NandaYudhaP_004_UASPAW.Models
{
    public partial class RekapKeuntungan
    {
        public int IdRekap { get; set; }
        public int? TotalPemasukan { get; set; }
        public int? Laba { get; set; }
        public string Bulan { get; set; }
    }
}

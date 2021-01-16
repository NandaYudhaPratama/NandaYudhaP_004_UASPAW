using System;
using System.Collections.Generic;

namespace NandaYudhaP_004_UASPAW.Models
{
    public partial class KendaraanMasukk
    {
        public int IdParkir { get; set; }
        public string NoPolisi { get; set; }
        public string JenisKendaraan { get; set; }

        public Persetujuan Persetujuan { get; set; }
    }
}

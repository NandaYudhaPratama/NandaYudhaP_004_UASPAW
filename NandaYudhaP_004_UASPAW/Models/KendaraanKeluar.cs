using System;
using System.Collections.Generic;

namespace NandaYudhaP_004_UASPAW.Models
{
    public partial class KendaraanKeluar
    {
        public int IdParkir { get; set; }
        public string NoPolisi { get; set; }
        public string Tarif { get; set; }

        public Persetujuan IdParkirNavigation { get; set; }
    }
}

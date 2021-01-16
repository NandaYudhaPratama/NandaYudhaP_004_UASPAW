using System;
using System.Collections.Generic;

namespace NandaYudhaP_004_UASPAW.Models
{
    public partial class Persetujuan
    {
        public int IdParkir { get; set; }
        public string Status { get; set; }

        public KendaraanMasukk IdParkirNavigation { get; set; }
        public KendaraanKeluar KendaraanKeluar { get; set; }
    }
}

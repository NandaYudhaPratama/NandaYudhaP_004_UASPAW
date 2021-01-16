using System;
using System.Collections.Generic;

namespace NandaYudhaP_004_UASPAW.Models
{
    public partial class TarifParkir
    {
        public int IdTarif { get; set; }
        public string JenisKendaraan { get; set; }
        public int? Harga { get; set; }
    }
}

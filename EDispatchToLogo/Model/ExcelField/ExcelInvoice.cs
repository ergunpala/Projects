using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.Model.ExcelField
{
    public class ExcelInvoice
    {
        public int Index { get; set; }
        public string CariKod { get; set; }
        public string Imei { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string TasiyiciKodu { get; set; }
        public decimal Tutar { get; set; }
        public string Durum { get; set; }
    }
}

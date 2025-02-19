using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.Model.Transfer
{
    public class InvoiceLine
    {
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public int VatRate { get; set; }
    }
}

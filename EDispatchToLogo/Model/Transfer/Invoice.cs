using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.Model.Transfer
{
    public class Invoice
    {
        public Invoice()
        {
            Lines = new List<InvoiceLine>();
        }
        public string ArpCode { get; set; }
        public DateTime FicheDate { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string ShippingCode { get; set; }
        public int AcceptInv { get; set; }
        public int ProfileID { get; set; }

        public List<InvoiceLine> Lines;
    }
}

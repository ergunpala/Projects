using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.Model.Transfer
{
    public class Dispatch
    {
        public Dispatch()
        {
            Lines = new List<DispatchLine>();
        }
        public string ArpCode { get; set; }
        public DateTime FicheDate { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string ShippingCode { get; set; }

        public List<DispatchLine> Lines;
    }
}

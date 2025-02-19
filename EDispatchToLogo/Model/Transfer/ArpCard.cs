using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.Model.Transfer
{
    public class ArpCard
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tckn { get; set; }
        public string Adress { get; set; }
        public string District { get; set; }
        public string DistrictCode { get; set; }        
        public string City { get; set; }
        public string CityCode { get; set; }
        public string PostalCode { get; set; }
        public string Telephone1 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFicheToLogo.Model
{
    public class ExcelField
    {
        public string MasterField { get; set; }
        public int MasterFieldIndex { get; set; }
        public string Field { get; set; }
        public int FieldIndex { get; set; }
    }
}

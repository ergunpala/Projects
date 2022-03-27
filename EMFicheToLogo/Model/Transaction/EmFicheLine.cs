using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFicheToLogo.Model.Transaction
{
    public class EmFicheLine
    {
        public string GL_CODE { get; set; }
        public decimal DEBIT { get; set; }
        public decimal CREDIT { get; set; }
        public int SIGN { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal TC_AMOUNT { get; set; }
    }
}

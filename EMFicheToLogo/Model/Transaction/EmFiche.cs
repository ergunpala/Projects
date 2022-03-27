using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFicheToLogo.Model.Transaction
{
    public class EmFiche
    {
        public EmFiche()
        {
            Lines = new List<EmFicheLine>();
        }
        public int TYPE { get; set; }
        public string NUMBER { get; set; }
        public DateTime DATE { get; set; }        
        public string NOTES1 { get; set; }

        public List<EmFicheLine> Lines;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFicheToLogo.Model
{
    public class ProductionSummary : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private byte Check = 0;
        private string Desc = "";

        public byte Status
        {
            get { return this.Check; }
            set
            {
                if (this.Check != value)
                {
                    this.Check = value;
                    NotifyPropertyChanged("Status");
                }
            }
        }
        public string StatusDesc
        {
            get { return this.Desc; }
            set
            {
                if (this.Desc != value)
                {
                    this.Desc = value;
                    NotifyPropertyChanged("StatusDesc");
                }
            }
        }


        public string InsuranceFirm { get; set; }
        public string Branch { get; set; }
        public string DebitCode { get; set; }
        public string CreditCode { get; set; }
        public decimal DebitTotal { get; set; }
        public decimal CreditTotal { get; set; }
        public decimal GrossTotal { get; set; }  
    }
}

using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDispatchToLogo
{
    public partial class FrmPass : Form
    {
        public FrmPass()
        {
            InitializeComponent();
        }

        private void FrmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtPass.Text))
            {
                XtraMessageBox.Show("Şifre Giriniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(txtPass.Text == "techHv@21")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Şifre Geçersiz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

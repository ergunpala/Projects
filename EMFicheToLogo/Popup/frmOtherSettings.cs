using DevExpress.XtraEditors;
using EMFicheToLogo.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMFicheToLogo.Popup
{
    public partial class frmOtherSettings : Form
    {
        public frmOtherSettings()
        {
            InitializeComponent();
        }

        private void frmOtherSettings_Load(object sender, EventArgs e)
        {
            FillOtherSett();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsCheckFields())
                return;

            OTHERSETT otherSett = new OTHERSETT()
            {
                BRANCHCLCODE = txtranchClCode.Text.Trim()
            };

            if (DataAccess.OTHERSETT_DAL.IsExists())
                DataAccess.OTHERSETT_DAL.Update(otherSett);
            else
                DataAccess.OTHERSETT_DAL.Add(otherSett);

            XtraMessageBox.Show("Kaydedildi", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmOtherSettings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }


        private void FillOtherSett()
        {
            OTHERSETT otherSett = DataAccess.OTHERSETT_DAL.Get();

            if (otherSett != null)
                txtranchClCode.Text = otherSett.BRANCHCLCODE;
        }

        private bool IsCheckFields()
        {
            erp.ClearErrors();

            if (string.IsNullOrEmpty(txtranchClCode.Text))
                erp.SetError(txtranchClCode, "Şubeler Cari Kod Giriniz.");

            return !erp.HasErrors;
        }
    }
}

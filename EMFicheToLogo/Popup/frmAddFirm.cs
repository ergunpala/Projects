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
    public partial class frmAddFirm : Form
    {
        FIRMSETT firmSett = new FIRMSETT();
        public frmAddFirm(FIRMSETT pFirmSett)
        {
            firmSett = pFirmSett;
            InitializeComponent();
        }

        private void frmAddFirm_Load(object sender, EventArgs e)
        {
            txtFirm.Text = firmSett.FIRM;
            txtCode.Text = firmSett.CODE;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsCheckFields())
                return;

            firmSett.FIRM = txtFirm.Text.Trim();
            firmSett.CODE = txtCode.Text.Trim();

            if(DataAccess.FIRMSETT_DAL.IsExists(firmSett))
            {
                XtraMessageBox.Show("Aynı Firma Mevcut", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (firmSett.ID > 0)
                DataAccess.FIRMSETT_DAL.Update(firmSett);
            else
                DataAccess.FIRMSETT_DAL.Add(firmSett);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsCheckFields()
        {
            erp.ClearErrors();

            if (string.IsNullOrEmpty(txtFirm.Text))
                erp.SetError(txtFirm, "Firma Giriniz.");

            if (string.IsNullOrEmpty(txtCode.Text))
                erp.SetError(txtCode, "Kod Giriniz.");

            return !erp.HasErrors;
        }

        private void frmAddFirm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}

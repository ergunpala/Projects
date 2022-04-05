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
    public partial class frmAddBranch : Form
    {
        BRANCHSETT branchSett = new BRANCHSETT();
        public frmAddBranch(BRANCHSETT pBranchSett)
        {
            branchSett = pBranchSett;
            InitializeComponent();
        }

        private void frmAddBranch_Load(object sender, EventArgs e)
        {
            txtBranch.Text = branchSett.BRANCH;
            txtDebitCode.Text = branchSett.DEBITCODE;
            txtCreditCode.Text = branchSett.CREDITCODE;
            txtHealthDebitCode.Text = branchSett.HEALTHDEBITCODE;
            txtHealthCreditCode.Text = branchSett.HEALTHCREDITCODE;
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

            branchSett.BRANCH = txtBranch.Text.Trim();
            branchSett.DEBITCODE = txtDebitCode.Text.Trim();
            branchSett.CREDITCODE = txtCreditCode.Text.Trim();
            branchSett.HEALTHDEBITCODE = txtHealthDebitCode.Text.Trim();
            branchSett.HEALTHCREDITCODE = txtHealthCreditCode.Text.Trim();

            if (DataAccess.BRANCHSETT_DAL.IsExists(branchSett))
            {
                XtraMessageBox.Show("Aynı Şube Mevcut", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (branchSett.ID > 0)
                DataAccess.BRANCHSETT_DAL.Update(branchSett);
            else
                DataAccess.BRANCHSETT_DAL.Add(branchSett);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsCheckFields()
        {
            erp.ClearErrors();

            if (string.IsNullOrEmpty(txtBranch.Text))
                erp.SetError(txtBranch, "Şube Giriniz.");

            if (string.IsNullOrEmpty(txtDebitCode.Text))
                erp.SetError(txtDebitCode, "Elementer Borç Kod Giriniz.");

            if (string.IsNullOrEmpty(txtCreditCode.Text))
                erp.SetError(txtCreditCode, "Elementer Alacak Kod Giriniz.");

            if (string.IsNullOrEmpty(txtHealthDebitCode.Text))
                erp.SetError(txtHealthDebitCode, "Sağlık Borç Kod Giriniz.");

            if (string.IsNullOrEmpty(txtHealthCreditCode.Text))
                erp.SetError(txtHealthCreditCode, "Sağlık Alacak Kod Giriniz.");

            return !erp.HasErrors;
        }

        private void frmAddBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}

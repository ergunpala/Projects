using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EMFicheToLogo.Model.LOGO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMFicheToLogo
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnProdSummary_Click(object sender, EventArgs e)
        {
            if (!CheckFirmSelect())
                return;

            frmProdSummary frm = new frmProdSummary();
            frm.ShowDialog();
        }

        #region MenuStrip

        private void btnFirm_Click(object sender, EventArgs e)
        {
            frmFirm frm = new frmFirm();
            frm.ShowDialog();
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            frmBranch frm = new frmBranch();
            frm.ShowDialog();
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            Popup.frmOtherSettings frm = new Popup.frmOtherSettings();
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            return;
        }

        #endregion

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (!SetSettings())
                return;

            FillFirms();
        }

        #region Methods

        private bool SetSettings()
        {
            bool result = true;
            try
            {
                Model.AppClass.SqlConnStr = Helper.Base64Helper.Base64Decode(ConfigurationManager.AppSettings["SQLCONN"]);
                Model.AppClass.SqlLogoConnStr = Helper.Base64Helper.Base64Decode(ConfigurationManager.AppSettings["SQLLOGOCONN"]);
                Model.AppClass.ObjUser = ConfigurationManager.AppSettings["OBJUSER"];
                Model.AppClass.ObjUserPass = Helper.Base64Helper.Base64Decode(ConfigurationManager.AppSettings["OBJPASS"]);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Parametreler YÜklenirken Hata Oluştu.\n" + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }


        private void FillFirms()
        {
            List<L_CAPIFIRM> firms = DataAccess.LOGO.L_CAPIFIRM_DAL.GetFirms();

            gleFirm.Properties.DataSource = firms;
            gleFirm.Properties.DisplayMember = "NAME";
            gleFirm.Properties.ValueMember = "NR";
            gleFirm.Properties.BestFitMode = BestFitMode.BestFit;
        }

        #endregion

        private void btnPosSummary_Click(object sender, EventArgs e)
        {
            if (!CheckFirmSelect())
                return;

            frmPos frm = new frmPos();
            frm.ShowDialog();
        }

        private void btnPosReturnSummary_Click(object sender, EventArgs e)
        {
            if (!CheckFirmSelect())
                return;

            frmPosReturn frm = new frmPosReturn();
            frm.ShowDialog();
        }

        private bool CheckFirmSelect()
        {
            if (gleFirm.EditValue != null)
            {
                Model.AppClass.LogoFirmNR = int.Parse(gleFirm.EditValue.ToString());
                return true;
            }

            XtraMessageBox.Show("Firma Seçiniz!", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
    }
}

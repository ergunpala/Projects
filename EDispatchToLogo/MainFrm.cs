using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using EDispatchToLogo.Model.LOGO;
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

namespace EDispatchToLogo
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (!SetSettings())
                return;

            FillFirms();
        }

        #region Methods

        private void FillFirms()
        {
            List<L_CAPIFIRM> firms = DataAccess.LOGO.L_CAPIFIRM_DAL.GetFirms();

            gleFirm.Properties.DataSource = firms;
            gleFirm.Properties.DisplayMember = "NAME";
            gleFirm.Properties.ValueMember = "NR";
            gleFirm.Properties.BestFitMode = BestFitMode.BestFit;
        }

        #endregion

        #region Specific Methods

        private bool SetSettings()
        {
            bool result = true;

            try
            {                
                Model.GlobalParam.SqlLogoConnStr = Helper.Base64Helper.Base64Decode(ConfigurationManager.AppSettings["SQLLOGOCONN"]);
                Model.GlobalParam.ObjUser = ConfigurationManager.AppSettings["OBJUSER"];
                Model.GlobalParam.ObjUserPass = Helper.Base64Helper.Base64Decode(ConfigurationManager.AppSettings["OBJPASS"]);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Parametreler YÜklenirken Hata Oluştu.\n" + ex.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }

        private bool CheckFirmSelect()
        {
            if (gleFirm.EditValue != null)
            {
                Model.GlobalParam.LogoFirmNR = int.Parse(gleFirm.EditValue.ToString());
                return true;
            }

            XtraMessageBox.Show("Firma Seçiniz!", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        #endregion

        private void btnEDispatch_Click(object sender, EventArgs e)
        {
            if (!CheckFirmSelect())
                return;

            FrmDispatch frm = new FrmDispatch(false);
            frm.ShowDialog();
        }

        private void btnEDispatchCollective_Click(object sender, EventArgs e)
        {
            if (!CheckFirmSelect())
                return;

            FrmDispatch frm = new FrmDispatch(true);
            frm.ShowDialog();
        }

        private void cmsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            return;
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (!CheckFirmSelect())
                return;

            FrmPass frmPass = new FrmPass();
            if(frmPass.ShowDialog() == DialogResult.OK)
            {
                FrmInvoice frmInvoice = new FrmInvoice();
                frmInvoice.ShowDialog();
            }
        }
    }
}

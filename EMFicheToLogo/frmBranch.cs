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

namespace EMFicheToLogo
{
    public partial class frmBranch : Form
    {
        public frmBranch()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BRANCHSETT branchSett = new BRANCHSETT()
            {
                ID = 0,
                BRANCH = "",
                DEBITCODE = "",
                CREDITCODE =""                
            };

            Popup.frmAddBranch frm = new Popup.frmAddBranch(branchSett);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                FillBranchCode();
            }
        }

        private void frmBranch_Load(object sender, EventArgs e)
        {
            FillBranchCode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gv.RowCount <= 0)
            {
                XtraMessageBox.Show("Şube Listesi Boş", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gv.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Kayıt Seçiniz", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BRANCHSETT branchSett = new BRANCHSETT()
            {
                ID = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "ID")),
                BRANCH = gv.GetRowCellValue(gv.FocusedRowHandle, "BRANCH").ToString(),
                DEBITCODE = gv.GetRowCellValue(gv.FocusedRowHandle, "DEBITCODE").ToString(),
                CREDITCODE = gv.GetRowCellValue(gv.FocusedRowHandle, "CREDITCODE").ToString()
            };

            Popup.frmAddBranch frm = new Popup.frmAddBranch(branchSett);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                int selectedRow = gv.FocusedRowHandle;
                FillBranchCode();
                gv.FocusedRowHandle = selectedRow;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (gv.RowCount <= 0)
            {
                XtraMessageBox.Show("Şube Listesi Boş", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gv.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Kayıt Seçiniz", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XtraMessageBox.Show("Kayıdı Silmek İster misiniz?", "İşlem", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                int id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "ID"));
                DataAccess.BRANCHSETT_DAL.Delete(id);
                FillBranchCode();
            }
        }
        private void FillBranchCode()
        {
            List<BRANCHSETT> branchSett = DataAccess.BRANCHSETT_DAL.GetList();

            gc.DataSource = branchSett;
            gv.BestFitColumns();
        }

        private void frmBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}

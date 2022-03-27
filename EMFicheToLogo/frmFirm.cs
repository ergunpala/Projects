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
    public partial class frmFirm : Form
    {
        public frmFirm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FIRMSETT firmSett = new FIRMSETT()
            {
                ID = 0,
                FIRM = "",
                CODE = ""
            };

            Popup.frmAddFirm frm = new Popup.frmAddFirm(firmSett);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                FillFirmsCode();
            }
        }

        private void frmFirm_Load(object sender, EventArgs e)
        {
            FillFirmsCode();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(gv.RowCount <= 0)
            {
                XtraMessageBox.Show("Firma Listesi Boş", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(gv.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Kayıt Seçiniz", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FIRMSETT firmSett = new FIRMSETT()
            {
                ID = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "ID")),
                FIRM = gv.GetRowCellValue(gv.FocusedRowHandle, "FIRM").ToString(),
                CODE = gv.GetRowCellValue(gv.FocusedRowHandle, "CODE").ToString(),
            };

            Popup.frmAddFirm frm = new Popup.frmAddFirm(firmSett);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                int selectedRow = gv.FocusedRowHandle;
                FillFirmsCode();
                gv.FocusedRowHandle = selectedRow;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gv.RowCount <= 0)
            {
                XtraMessageBox.Show("Firma Listesi Boş", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (gv.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Kayıt Seçiniz", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XtraMessageBox.Show("Kayıdı Silmek İster misiniz?","İşlem", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                int id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "ID"));
                DataAccess.FIRMSETT_DAL.Delete(id);
                FillFirmsCode();
            }
        }


        private void FillFirmsCode()
        {
            List<FIRMSETT> firmSett = DataAccess.FIRMSETT_DAL.GetList();

            gc.DataSource = firmSett;
            gv.BestFitColumns();
        }

        private void frmFirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}

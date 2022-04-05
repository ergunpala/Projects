using DevExpress.XtraEditors;
using EMFicheToLogo.Model.Complex;
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
            FirmCurrency firmCurrency = new FirmCurrency()
            {
                ID = 0,
                FIRM = "",
                CODE = "",
                CURRENCY = cmbCurrency.Text
            };

            Popup.frmAddFirm frm = new Popup.frmAddFirm(firmCurrency);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                FillFirmsCode(cmbCurrency.Text);
            }
        }

        private void frmFirm_Load(object sender, EventArgs e)
        {
            FillCurrency();
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

            FirmCurrency firmCurrency = new FirmCurrency()
            {
                ID = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "ID")),
                FIRM = gv.GetRowCellValue(gv.FocusedRowHandle, "FIRM").ToString(),
                CODE = gv.GetRowCellValue(gv.FocusedRowHandle, "CODE").ToString(),
                CURRENCY = cmbCurrency.Text
            };

            Popup.frmAddFirm frm = new Popup.frmAddFirm(firmCurrency);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                int selectedRow = gv.FocusedRowHandle;
                FillFirmsCode(cmbCurrency.Text);
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
                DataAccess.FIRMSETTCURR_DAL.Delete(id);
                FillFirmsCode(cmbCurrency.Text);
            }
        }

        private void FillCurrency()
        {
            List<CURRENCYLIST> currencyList = DataAccess.CURRENCYLIST_DAL.GetList();

            if(currencyList != null && currencyList.Count > 0)
            {
                foreach (var item in currencyList)
                    cmbCurrency.Properties.Items.Add(item.CURRENCY);
            }

            cmbCurrency.SelectedIndex = 0;

            FillFirmsCode(cmbCurrency.Text);
        }
        private void FillFirmsCode(string pCurrency)
        {
            List<FirmCurrency> firmCurrency = DataAccess.Complex.FirmCurrency_DAL.GetList(pCurrency);


            gc.DataSource = firmCurrency;
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

        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFirmsCode(cmbCurrency.Text);
        }
    }
}

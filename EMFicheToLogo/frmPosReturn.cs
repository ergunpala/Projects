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
using UnityObjects;

namespace EMFicheToLogo
{
    public partial class frmPosReturn : Form
    {
        private List<FirmCurrency> firmCurrencyList;
        private OTHERSETT otherSett;
        private List<CURRENCYLIST> currencyList;
        private Model.ListParam listParam;
        UnityApplication myApp = new UnityApplication();
        public frmPosReturn()
        {
            InitializeComponent();
        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            txtFile.EditValue = Model.AppClass.OpenExcelFile();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Control[] controls = GetControl();

            if (gc.DataSource == null)
            {
                XtraMessageBox.Show("Aktarılacak Kayıt Bulunamadı", "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (deFicheDate.EditValue == null)
            {
                XtraMessageBox.Show("Fiş Tarihi Seçiniz", "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (string.IsNullOrEmpty(txtFicheDesc.Text))
            {
                XtraMessageBox.Show("Fiş Açıklama Giriniz", "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (XtraMessageBox.Show("Kayıtları Aktarmak İster misiniz?", "BILGI", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
            {
                return;
            }

            BindingList<Model.PosSummary> insuranceItems = new BindingList<Model.PosSummary>(((BindingList<Model.PosSummary>)(gc.DataSource)).ToList());

            if (insuranceItems == null || insuranceItems.Count.Equals(0))
            {
                XtraMessageBox.Show("Aktarılacak Kayıt Bulunamadı (BindingList)", "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            if (insuranceItems.Any(f => f.Status == (int)Model.ListStatus.HasError))
            {

                XtraMessageBox.Show("Aktarılacak Kayıtlarda Hatalı Satırlar Var", "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (insuranceItems.Any(f => f.Status == (int)Model.ListStatus.TransferedToLogo))
            {

                XtraMessageBox.Show("Kayıtları Tekrar Listeleyiniz", "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if (string.IsNullOrEmpty(Model.AppClass.ObjUser) || string.IsNullOrEmpty(Model.AppClass.ObjUserPass))
            {
                XtraMessageBox.Show("Object Bilgileri Bulunamadı", "UYARI", MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                return;
            }

            if (listParam.Currency != cmbCurrency.Text)
            {
                XtraMessageBox.Show("Döviz veya Aktarım Tipi Değişti.\nLütfen Tekrar Listeleyiniz.", "UYARI", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);

                return;
            }

            Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, false, "Kayıtlar Aktarılıyor");

            string logoLoggedinError = string.Empty;

            myApp = new UnityApplication();

            if (!Model.AppClass.IsLOGOConnect(myApp, ref logoLoggedinError))
            {
                Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, true);
                XtraMessageBox.Show(Model.AppClass.LogoFirmNR + " Numaralı Firma İle LOGO ya Bağlanılamadı! \n" + logoLoggedinError, "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }


            try
            {
                string ficheDesc = txtFicheDesc.Text.Trim();

                Model.Transaction.EmFiche emFiche = new Model.Transaction.EmFiche();
                emFiche.TYPE = 4;
                emFiche.NUMBER = "~";
                emFiche.DATE = Convert.ToDateTime(deFicheDate.EditValue);
                emFiche.NOTES1 = string.Format("{0}", ficheDesc);

                foreach (var line in insuranceItems)
                {
                    Model.Transaction.EmFicheLine emfLine = new Model.Transaction.EmFicheLine();

                    if (line.DebitTotal > 0m)
                    {
                        emfLine.GL_CODE = line.DebitCode;
                        emfLine.DEBIT = line.DebitTotal;
                        emfLine.DESCRIPTION = string.Format("{0}", ficheDesc);
                        emfLine.TC_AMOUNT = line.DebitTotal;
                    }
                    else
                    {
                        emfLine.GL_CODE = line.CreditCode;
                        emfLine.CREDIT = line.CreditTotal;
                        emfLine.DESCRIPTION = string.Format("{0}", ficheDesc);
                        emfLine.TC_AMOUNT = line.CreditTotal;
                    }

                    emFiche.Lines.Add(emfLine);

                }

                Model.Transaction.Result resultTran = Transaction.Logo.EmfTrans.AddFiche(myApp, emFiche);

                if (resultTran.IsSucceed)
                {
                    insuranceItems[0].Status = (int)Model.ListStatus.TransferedToLogo;
                    insuranceItems[0].StatusDesc = string.Concat(resultTran.FicheNo, " No ile LOGO ya Aktarıldı");
                }
                else
                {
                    insuranceItems[0].Status = (int)Model.ListStatus.HasError;
                    insuranceItems[0].StatusDesc = resultTran.Desc;
                }
            }
            catch (Exception ex)
            {
                string error = string.Concat("Hata Oluştu", ex.ToString());

                insuranceItems[0].Status = (int)Model.ListStatus.HasError;
                insuranceItems[0].StatusDesc = error;
            }



            //try
            //{
            //    string ficheDesc = txtFicheDesc.Text.Trim();

            //    UnityObjects.IData lObject = myApp.NewDataObject(DataObjectType.doGLVoucher);

            //    lObject.New();
            //    lObject.DataFields.FieldByName("TYPE").Value = 4;
            //    lObject.DataFields.FieldByName("NUMBER").Value = "~";
            //    lObject.DataFields.FieldByName("DATE").Value = Convert.ToDateTime(deFicheDate.EditValue).Date.ToString("dd.MM.yyyy");
            //    //lObject.DataFields.FieldByName("DATE").Value = DateTime.Now.Date.ToString("dd.MM.yyyy");
            //    lObject.DataFields.FieldByName("DOC_DATE").Value = lObject.DataFields.FieldByName("DATE").Value;
            //    lObject.DataFields.FieldByName("NOTES1").Value = string.Format("{0}", ficheDesc);
            //    lObject.DataFields.FieldByName("CURRSEL_TOTALS").Value = "1";
            //    //lObject.DataFields.FieldByName("DIVISION").Value = ""; 

            //    ILines ILine = lObject.DataFields.FieldByName("TRANSACTIONS").Lines;

            //    foreach (var line in insuranceItems)
            //    {
            //        ILine.AppendLine();

            //        if (line.DebitTotal > 0m)
            //        {
            //            ILine[ILine.Count - 1].FieldByName("GL_CODE").Value = line.DebitCode;
            //            ILine[ILine.Count - 1].FieldByName("DEBIT").Value = Model.AppClass.GetConvertToDouble(line.DebitTotal);
            //            ILine[ILine.Count - 1].FieldByName("LINENO").Value = 1;
            //            ILine[ILine.Count - 1].FieldByName("DESCRIPTION").Value = string.Format("{0}", ficheDesc);
            //            ILine[ILine.Count - 1].FieldByName("TC_AMOUNT").Value = Model.AppClass.GetConvertToDouble(line.DebitTotal);
            //        }
            //        else
            //        {
            //            ILine[ILine.Count - 1].FieldByName("GL_CODE").Value = line.CreditCode;
            //            ILine[ILine.Count - 1].FieldByName("SIGN").Value = 1;
            //            ILine[ILine.Count - 1].FieldByName("CREDIT").Value = Model.AppClass.GetConvertToDouble(line.CreditTotal);
            //            ILine[ILine.Count - 1].FieldByName("LINENO").Value = 1;
            //            ILine[ILine.Count - 1].FieldByName("DESCRIPTION").Value = string.Format("{0}", ficheDesc);
            //            ILine[ILine.Count - 1].FieldByName("TC_AMOUNT").Value = Model.AppClass.GetConvertToDouble(line.CreditTotal);
            //        }
            //    }

            //    lObject.FillAccCodes();

            //    if (!lObject.Post())
            //    {
            //        string error = "HATA (LOGO) >> ";

            //        if (lObject.ValidateErrors.Count > 0)
            //        {
            //            for (int i = 0; i < lObject.ValidateErrors.Count; i++)
            //            {
            //                error += lObject.ValidateErrors[i].Error;
            //            }
            //        }

            //        insuranceItems[0].Status = (int)Model.ListStatus.HasError;
            //        insuranceItems[0].StatusDesc = error;
            //    }
            //    else
            //    {
            //        string error = "(LOGO) >> OK";

            //        int postedLogicalRef = Convert.ToInt32(lObject.DataFields.DBFieldByName("LOGICALREF").Value);
            //        string ficheNo = lObject.DataFields.DBFieldByName("FICHENO").Value;

            //        insuranceItems[0].Status = (int)Model.ListStatus.TransferedToLogo;
            //        insuranceItems[0].StatusDesc = string.Concat(ficheNo, " No ile LOGO ya Aktarıldı");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string error = string.Concat("Hata Oluştu", ex.ToString());

            //    insuranceItems[0].Status = (int)Model.ListStatus.HasError;
            //    insuranceItems[0].StatusDesc = error;
            //}

            Model.AppClass.LogoLobjectDisconnect(myApp);

            Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, true);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Control[] controls = GetControl();

            if (string.IsNullOrEmpty(txtFile.Text))
            {
                XtraMessageBox.Show("Excel Dosyası Seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            firmCurrencyList = DataAccess.Complex.FirmCurrency_DAL.GetList(cmbCurrency.Text);
            otherSett = DataAccess.OTHERSETT_DAL.Get();

            if (firmCurrencyList == null || firmCurrencyList.Count.Equals(0))
            {
                XtraMessageBox.Show("Firma Listesi Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (otherSett == null || string.IsNullOrEmpty(otherSett.BRANCHCLCODE))
            {
                XtraMessageBox.Show("Şube Cari Kod Parametresi Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listParam = new Model.ListParam()
            {
                Currency = cmbCurrency.Text
            };

            Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, false, "Kayıtlar Yükleniyor");

            string err = "";
            DataTable dt = Model.AppClass.GetDataTableFromExcel(txtFile.Text, ref err);

            if (!string.IsNullOrEmpty(err))
            {
                Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, true);
                MessageBox.Show("Excel i Okurken bir Hata Oluştu +\n" + err, "HATA", MessageBoxButtons.OK);
                return;
            }

            if (dt == null || dt.Rows.Count.Equals(0))
            {
                Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, true);
                XtraMessageBox.Show("Excel Satırları Bulunamadı", "BILGI", MessageBoxButtons.OK);
                return;
            }

            List<Model.PosSummary> posReturns = GetPosReturns(dt);

            List<Model.PosSummary> masterPosReturns = new List<Model.PosSummary>();

            if (posReturns != null && posReturns.Count > 0)
            {
                masterPosReturns = PrepareItems(posReturns);
            }

            gc.DataSource = new BindingList<Model.PosSummary>(masterPosReturns);
            gv.BestFitColumns();

            Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, true);
        }

        private List<Model.PosSummary> GetPosReturns(DataTable pDt)
        {
            List<Model.PosSummary> result = new List<Model.PosSummary>();

            bool firstVal = false;
            string insuranceFirm = "";
            int index = 0;

            foreach (DataRow dr in pDt.Rows)
            {
                decimal credit = 0m;

                try
                {
                    if ((dr[0] == null || string.IsNullOrEmpty(dr[0].ToString())) && !firstVal)
                        continue;

                    if (dr[5].ToString().IndexOf("Toplam:") > -1 || dr[5].ToString().IndexOf("Toplam") > -1)
                        continue;

                    if (dr[0].ToString().IndexOf("Toplam:") > -1 || dr[0].ToString().IndexOf("Toplam") > -1)
                        continue;

                    firstVal = true;

                    if (!string.IsNullOrEmpty(dr[0].ToString()))
                        insuranceFirm = dr[0].ToString();

                    if (dr[13] != null && dr[13] != DBNull.Value && !string.IsNullOrEmpty(dr[13].ToString()))
                        credit = Math.Abs(decimal.Parse(dr[13].ToString()));

                    result.Add(new Model.PosSummary()
                    {
                        InsuranceFirm = insuranceFirm,
                        CreditTotal = credit
                    });
                }
                catch (Exception ex)
                {
                    result.Add(new Model.PosSummary()
                    {
                        InsuranceFirm = insuranceFirm,
                        CreditTotal = credit,
                        Status = (int)Model.ListStatus.HasError,
                        StatusDesc = "Listeleme Hata >> (Index : " + index.ToString()
                    });
                }
            }

            return result;
        }

        private Control[] GetControl()
        {
            return new Control[]
                   {
                        pnlTop, pnlFill
                   };
        }

        private List<Model.PosSummary> PrepareItems(List<Model.PosSummary> pPosReturnInsurance)
        {
            List<Model.PosSummary> result = new List<Model.PosSummary>();

            var grpInsurance = pPosReturnInsurance.Where(f => f.CreditTotal > 0m)
                                .GroupBy(g => g.InsuranceFirm)
                                .Select(s => new
                                {
                                    InsuranceFirm = s.Key,
                                    TotalCredit = s.Sum(sm => sm.CreditTotal)
                                }).ToList();


            foreach (var insuranceItem in grpInsurance)
            {
                var firm = firmCurrencyList.FirstOrDefault(f => f.FIRM.Equals(insuranceItem.InsuranceFirm));

                if (firm == null)
                {
                    result.Add(new Model.PosSummary()
                    {
                        InsuranceFirm = insuranceItem.InsuranceFirm,
                        DebitCode = "",
                        CreditCode = "",
                        DebitCodeDefn = "",
                        CreditCodeDefn = insuranceItem.InsuranceFirm,
                        DebitTotal = 0m,
                        CreditTotal = 0m,
                        Status = (int)Model.ListStatus.HasError,
                        StatusDesc = "Firma Parametresi Bulunamadı"
                    });

                    continue;
                }

                result.Add(new Model.PosSummary()
                {
                    InsuranceFirm = insuranceItem.InsuranceFirm,
                    DebitCode = otherSett.BRANCHCLCODE,
                    CreditCode = "",
                    DebitCodeDefn = "ŞUBELER CARİ HES.",
                    CreditCodeDefn = "",
                    DebitTotal = insuranceItem.TotalCredit,
                    CreditTotal = 0m,
                    Status = (int)Model.ListStatus.ListOK,
                    StatusDesc = ""
                });

                result.Add(new Model.PosSummary()
                {
                    InsuranceFirm = insuranceItem.InsuranceFirm,
                    DebitCode = "",
                    CreditCode = firm.CODE,
                    DebitCodeDefn = "",
                    CreditCodeDefn = insuranceItem.InsuranceFirm,
                    DebitTotal = 0m,
                    CreditTotal = insuranceItem.TotalCredit,
                    Status = (int)Model.ListStatus.ListOK,
                    StatusDesc = ""
                });
            }

            return result;
        }

        private void frmPosReturn_Load(object sender, EventArgs e)
        {
            deFicheDate.EditValue = DateTime.Now.Date;
            FillCurrency();
        }

        private void FillCurrency()
        {
            currencyList = DataAccess.CURRENCYLIST_DAL.GetList();

            if (currencyList != null && currencyList.Count > 0)
            {
                foreach (var item in currencyList)
                    cmbCurrency.Properties.Items.Add(item.CURRENCY);
            }

            cmbCurrency.SelectedIndex = 0;
        }
    }
}

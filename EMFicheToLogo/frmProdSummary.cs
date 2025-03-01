﻿using DevExpress.XtraEditors;
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
    public partial class frmProdSummary : Form
    {
        private List<FirmCurrency> firmCurrencyList;
        private List<BRANCHSETT> branchSet;
        private OTHERSETT otherSett;
        private List<CURRENCYLIST> currencyList;
        private Model.ListParam listParam;
        UnityApplication myApp = new UnityApplication();
        public frmProdSummary()
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

            if(deFicheDate.EditValue == null)
            {
                XtraMessageBox.Show("Fiş Tarihi Seçiniz", "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if(string.IsNullOrEmpty(txtFicheDesc.Text))
            {
                XtraMessageBox.Show("Fiş Açıklama Giriniz", "UYARI", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            if(XtraMessageBox.Show("Kayıtları Aktarmak İster misiniz?","BILGI", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
            {
                return;
            }

            BindingList<Model.ProductionSummary> insuranceItems = new BindingList<Model.ProductionSummary>(((BindingList<Model.ProductionSummary>)(gc.DataSource)).ToList());

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

            if(listParam.Currency != cmbCurrency.Text || listParam.TransType != cmbTransType.SelectedIndex)
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

            var grpEmfFieches = insuranceItems.GroupBy(g => g.InsuranceFirm)
                                .Select(s => new
                                {
                                    InsuranceFirm = s.Key,
                                    List = s.ToList()
                                }).ToList();

            string ficheDesc = txtFicheDesc.Text.Trim();

            foreach(var fiche in grpEmfFieches)
            {
                try
                {
                    Model.Transaction.EmFiche emFiche = new Model.Transaction.EmFiche();
                    emFiche.TYPE = 4;
                    emFiche.NUMBER = "~";
                    emFiche.DATE = Convert.ToDateTime(deFicheDate.EditValue);
                    emFiche.NOTES1 = string.Format("{0} {1}", fiche.InsuranceFirm, ficheDesc);

                    foreach (var line in fiche.List)
                    {
                        Model.Transaction.EmFicheLine emfLine = new Model.Transaction.EmFicheLine();

                        if (line.DebitTotal > 0m)
                        {
                            emfLine.GL_CODE = line.DebitCode;
                            emfLine.DEBIT = line.DebitTotal;
                            emfLine.DESCRIPTION = string.Format("{0} {1}", fiche.InsuranceFirm, ficheDesc);
                            emfLine.TC_AMOUNT = line.DebitTotal;
                        }
                        else
                        {
                            emfLine.GL_CODE = line.CreditCode;
                            emfLine.CREDIT = line.CreditTotal;
                            emfLine.DESCRIPTION = string.Format("{0} {1}", fiche.InsuranceFirm, ficheDesc);
                            emfLine.TC_AMOUNT = line.CreditTotal;
                        }


                        emFiche.Lines.Add(emfLine);
                    }

                    Model.Transaction.Result resultTran = Transaction.Logo.EmfTrans.AddFiche(myApp, emFiche);

                    if(resultTran.IsSucceed)
                    {
                        fiche.List[0].Status = (int)Model.ListStatus.TransferedToLogo;
                        fiche.List[0].StatusDesc = string.Concat(resultTran.FicheNo, " No ile LOGO ya Aktarıldı");
                    }
                    else
                    {
                        fiche.List[0].Status = (int)Model.ListStatus.HasError;
                        fiche.List[0].StatusDesc = resultTran.Desc;
                    }
                }
                catch (Exception ex)
                {
                    string error = string.Concat("Hata Oluştu", ex.ToString());

                    fiche.List[0].Status = (int)Model.ListStatus.HasError;
                    fiche.List[0].StatusDesc = error;
                }



                //try
                //{
                //    UnityObjects.IData lObject = myApp.NewDataObject(DataObjectType.doGLVoucher);

                //    lObject.New();
                //    lObject.DataFields.FieldByName("TYPE").Value = 4;
                //    lObject.DataFields.FieldByName("NUMBER").Value = "~";
                //    lObject.DataFields.FieldByName("DATE").Value = Convert.ToDateTime(deFicheDate.EditValue).Date.ToString("dd.MM.yyyy");
                //    //lObject.DataFields.FieldByName("DATE").Value = DateTime.Now.Date.ToString("dd.MM.yyyy");
                //    lObject.DataFields.FieldByName("DOC_DATE").Value = lObject.DataFields.FieldByName("DATE").Value;
                //    lObject.DataFields.FieldByName("NOTES1").Value = string.Format("{0} {1}", fiche.InsuranceFirm, ficheDesc);
                //    lObject.DataFields.FieldByName("CURRSEL_TOTALS").Value = "1";
                //    //lObject.DataFields.FieldByName("DIVISION").Value = ""; 

                //    ILines ILine = lObject.DataFields.FieldByName("TRANSACTIONS").Lines;

                //    foreach(var line in fiche.List)
                //    {
                //        ILine.AppendLine();

                //        if (line.DebitTotal > 0m)
                //        {
                //            ILine[ILine.Count - 1].FieldByName("GL_CODE").Value = line.DebitCode;
                //            ILine[ILine.Count - 1].FieldByName("DEBIT").Value = Model.AppClass.GetConvertToDouble(line.DebitTotal);
                //            ILine[ILine.Count - 1].FieldByName("LINENO").Value = 1;
                //            ILine[ILine.Count - 1].FieldByName("DESCRIPTION").Value = string.Format("{0} {1}", fiche.InsuranceFirm, ficheDesc);
                //            ILine[ILine.Count - 1].FieldByName("TC_AMOUNT").Value = Model.AppClass.GetConvertToDouble(line.DebitTotal);
                //        }
                //        else
                //        {
                //            ILine[ILine.Count - 1].FieldByName("GL_CODE").Value = line.CreditCode;
                //            ILine[ILine.Count - 1].FieldByName("SIGN").Value = 1;
                //            ILine[ILine.Count - 1].FieldByName("CREDIT").Value = Model.AppClass.GetConvertToDouble(line.CreditTotal);                           
                //            ILine[ILine.Count - 1].FieldByName("LINENO").Value = 1;
                //            ILine[ILine.Count - 1].FieldByName("DESCRIPTION").Value = string.Format("{0} {1}", fiche.InsuranceFirm, ficheDesc);
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

                //        fiche.List[0].Status = (int)Model.ListStatus.HasError;
                //        fiche.List[0].StatusDesc = error;
                //    }
                //    else
                //    {
                //        string error = "(LOGO) >> OK";

                //        int postedLogicalRef = Convert.ToInt32(lObject.DataFields.DBFieldByName("LOGICALREF").Value);
                //        string ficheNo = lObject.DataFields.DBFieldByName("FICHENO").Value;

                //        fiche.List[0].Status = (int)Model.ListStatus.TransferedToLogo;
                //        fiche.List[0].StatusDesc = string.Concat(ficheNo, " No ile LOGO ya Aktarıldı");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    string error = string.Concat("Hata Oluştu", ex.ToString());

                //    fiche.List[0].Status = (int)Model.ListStatus.HasError;
                //    fiche.List[0].StatusDesc = error;
                //}
            }

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
            branchSet = DataAccess.BRANCHSETT_DAL.GetList();
            otherSett = DataAccess.OTHERSETT_DAL.Get();

            if(firmCurrencyList == null || firmCurrencyList.Count.Equals(0))
            {
                XtraMessageBox.Show("Firma Listesi Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (branchSet == null || branchSet.Count.Equals(0))
            {
                XtraMessageBox.Show("Şube Listesi Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (otherSett == null || string.IsNullOrEmpty(otherSett.BRANCHCLCODE))
            {
                XtraMessageBox.Show("Şube Cari Kod Parametresi Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            listParam = new Model.ListParam()
            {
                Currency = cmbCurrency.Text,
                TransType = cmbTransType.SelectedIndex
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

            if(dt.Rows.Count <= 5)
            {
                Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, true);
                XtraMessageBox.Show("Excel Dosyası Geçersiz", "BILGI", MessageBoxButtons.OK);
                return;
            }

            List<Model.ProductionSummary> prodInsurances = GetProductionSummaries(dt);

            List<Model.ProductionSummary> masterInsuranceList = new List<Model.ProductionSummary>();

            if(prodInsurances != null && prodInsurances.Count > 0)
            {
                masterInsuranceList = PrepareItems(prodInsurances);
            }
            else
            {
                Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, true);
                XtraMessageBox.Show("Excel Satırları Model Bind Edilemedi", "BILGI", MessageBoxButtons.OK);
                return;
            }

            gc.DataSource = new BindingList<Model.ProductionSummary>(masterInsuranceList);
            gv.BestFitColumns();

            Model.AppClass.EnablePanelAndWaitingForm(ssm, controls, true);
        }

        private List<Model.ProductionSummary> GetProductionSummaries(DataTable pDt)
        {
            List<Model.ProductionSummary> result = new List<Model.ProductionSummary>();

            bool firstVal = false;
            string insuranceFirm = "";
            int index = 0;


            #region values Variables

            Model.ExcelField currencyField = new Model.ExcelField()
            {
                MasterField = "",
                Field = "Para Birimi"
            };
            Model.ExcelField creditField = new Model.ExcelField()
            {
                MasterField = "Normal",
                Field = "Komisyon (TL)"
            };
            Model.ExcelField debitField = new Model.ExcelField() {
                MasterField = "İptal",
                Field = "Komisyon (TL)"
            };
            Model.ExcelField grossTotalField = new Model.ExcelField()
            {
                MasterField = "Genel Toplam",
                Field = "Brüt (TL)"
            };

            //int creditColIndex = 19;
            //int debitColIndex = 21;
            //int grossTotalColIndex = 24;


            #endregion

            string selectedCurrency = cmbCurrency.Text;
            bool isForeignCurr = false;

            if (selectedCurrency != "TL")
                isForeignCurr = true;


            DataRow drField = pDt.Rows[4];            
            for (int i = 0; i < pDt.Columns.Count; i++)
            {
                if(!string.IsNullOrEmpty(drField[i].ToString()) && drField[i].ToString().Trim() == creditField.MasterField)
                    creditField.MasterFieldIndex = i;

                if (!string.IsNullOrEmpty(drField[i].ToString()) && drField[i].ToString().Trim() == debitField.MasterField)
                    debitField.MasterFieldIndex = i;

                if (!string.IsNullOrEmpty(drField[i].ToString()) && drField[i].ToString().Trim() == grossTotalField.MasterField)
                    grossTotalField.MasterFieldIndex = i;
            }

            drField = pDt.Rows[5];
            for (int i = 0; i < pDt.Columns.Count; i++)
            {
                if (isForeignCurr && drField[i] != null && !string.IsNullOrEmpty(drField[i].ToString()) && drField[i].ToString().Trim() == currencyField.Field)
                {
                    currencyField.FieldIndex = i;
                    break;
                }
            }

            drField = pDt.Rows[6];
            for (int i = creditField.MasterFieldIndex; i < pDt.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(drField[i].ToString()) && drField[i].ToString().Trim() == creditField.Field)
                {
                    creditField.FieldIndex = i;
                    break;
                }                    
            }

            for (int i = debitField.MasterFieldIndex; i < pDt.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(drField[i].ToString()) && drField[i].ToString().Trim() == debitField.Field)
                {
                    debitField.FieldIndex = i;
                    break;
                }
            }

            for (int i = grossTotalField.MasterFieldIndex; i < pDt.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(drField[i].ToString()) && drField[i].ToString().Trim() == grossTotalField.Field)
                {
                    grossTotalField.FieldIndex = i;
                    break;
                }
            }


            if(debitField.MasterFieldIndex > 0 && debitField.FieldIndex == creditField.FieldIndex)
            {
                creditField.FieldIndex = 0;
                debitField.FieldIndex = 0;
            }

            if(grossTotalField.MasterFieldIndex > 0 && grossTotalField.FieldIndex == debitField.FieldIndex)
            {
                grossTotalField.FieldIndex = 0;
                debitField.FieldIndex = 0;
            }


            string lineCurreny = "";

            foreach (DataRow dr in pDt.Rows)
            {
                index++;

                if ((dr[0] == null || string.IsNullOrEmpty(dr[0].ToString())) && !firstVal)
                    continue;

                if (dr[0].ToString().IndexOf("Toplam:") > -1 || dr[0].ToString().IndexOf("Toplam") > -1)
                    continue;

                            

                //if(isForeignCurr)
                //{
                //    creditColIndex = 21;
                //    debitColIndex = 25;
                //    grossTotalColIndex = 31;
                //}


                firstVal = true;

                if (!string.IsNullOrEmpty(dr[0].ToString()))
                    insuranceFirm = dr[0].ToString();
                
                decimal credit = 0m;
                decimal debit = 0m;
                decimal grossTotal = 0m;
                
                try
                {
                    if (creditField.FieldIndex > 0 && dr[creditField.FieldIndex] != null && dr[creditField.FieldIndex] != DBNull.Value && !string.IsNullOrEmpty(dr[creditField.FieldIndex].ToString()))
                        credit = Math.Abs(decimal.Parse(dr[creditField.FieldIndex].ToString()));

                    if (debitField.FieldIndex > 0 && dr[debitField.FieldIndex] != null && dr[debitField.FieldIndex] != DBNull.Value && !string.IsNullOrEmpty(dr[debitField.FieldIndex].ToString()))
                        debit = Math.Abs(decimal.Parse(dr[debitField.FieldIndex].ToString()));

                    if (grossTotalField.FieldIndex > 0 && dr[grossTotalField.FieldIndex] != null && dr[grossTotalField.FieldIndex] != DBNull.Value && !string.IsNullOrEmpty(dr[grossTotalField.FieldIndex].ToString()))
                        grossTotal = Math.Abs(decimal.Parse(dr[grossTotalField.FieldIndex].ToString()));

                    if (currencyField.FieldIndex > 0)
                        lineCurreny = dr[currencyField.FieldIndex].ToString();

                    byte lineStatus = 0;
                    string lineDesc = "";

                    if (!isForeignCurr && currencyList.Where(f => f.CURRENCY != "TL").ToList().Any(f => f.CURRENCY.Equals(lineCurreny)))
                    {
                        lineStatus = (int)Model.ListStatus.HasError;
                        lineDesc = "Listeleme Hata >> (Index : " + index.ToString() + ") Döviz Seçim TL Ancak Excel Satırlarında Farklı Döviz Tipleri Mevcut ";
                    }
                    else if (isForeignCurr && lineCurreny != selectedCurrency)
                    {
                        lineStatus = (int)Model.ListStatus.HasError;
                        lineDesc = "Listeleme Hata >> (Index : " + index.ToString() + ") Döviz Seçimi ile Excel Satırlarındaki Döviz Tipi Farklı  ";
                    }

                    result.Add(new Model.ProductionSummary()
                    {
                        InsuranceFirm = insuranceFirm,
                        Branch = dr[7].ToString(),
                        DebitTotal = debit,
                        CreditTotal = credit,
                        GrossTotal = grossTotal,
                        Status = lineStatus,
                        StatusDesc = lineDesc
                    });
                }
                catch (Exception ex)
                {
                    result.Add(new Model.ProductionSummary()
                    {
                        InsuranceFirm = insuranceFirm,
                        Branch = dr[7].ToString(),
                        DebitTotal = debit,
                        CreditTotal = credit,
                        GrossTotal = grossTotal,
                        Status = (int)Model.ListStatus.HasError,
                        StatusDesc = "Listeleme Hata >> (Index : " + index.ToString() + ") " + ex.Message
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

        private List<Model.ProductionSummary> PrepareItems(List<Model.ProductionSummary> pProdInsurances)
        {
            List<Model.ProductionSummary> result = new List<Model.ProductionSummary>();

            var grpInsurance = pProdInsurances.Where(f=> f.CreditTotal > 0m || f.DebitTotal > 0m)
                                .GroupBy(g => g.InsuranceFirm)
                                .Select(s => new
                                {
                                    InsuranceFirm = s.Key,
                                    TotalDebit = s.Sum(sm => sm.DebitTotal),
                                    TotalCredit = s.Sum(sm => sm.CreditTotal),
                                    GrossTotal = s.Sum(sm => sm.GrossTotal),
                                    LineList = s.ToList()
                                }).ToList();
       

            foreach(var insuranceItem in grpInsurance)
            {
                var firmHasError = insuranceItem.LineList.Where(f => f.Status == (int)Model.ListStatus.HasError).Select(s => s.StatusDesc ).ToList();

                if(firmHasError != null && firmHasError.Count > 0)
                {
                    result.Add(new Model.ProductionSummary()
                    {
                        InsuranceFirm = insuranceItem.InsuranceFirm,
                        Branch = "",
                        DebitCode = "",
                        CreditCode = "",
                        DebitTotal = 0m,
                        CreditTotal = 0m,
                        Status = (int)Model.ListStatus.HasError,
                        StatusDesc = string.Join("", firmHasError.ToArray())
                    });

                    continue;
                }


                var firm = firmCurrencyList.FirstOrDefault(f => f.FIRM.Equals(insuranceItem.InsuranceFirm));

                if(firm == null)
                {
                    foreach(var firmItem in insuranceItem.LineList)
                    {
                        result.Add(new Model.ProductionSummary()
                        {
                            InsuranceFirm = insuranceItem.InsuranceFirm,
                            Branch = "",
                            DebitCode = "",
                            CreditCode = "",
                            DebitTotal = 0m,
                            CreditTotal = 0m,
                            Status = (int)Model.ListStatus.HasError,
                            StatusDesc = "Firma Parametresi Bulunamadı"
                        });
                    }

                    continue;
                }

                var creditList = insuranceItem.LineList.Where(f => f.CreditTotal > 0m).ToList();

                foreach(var creditItem in creditList)
                {
                    var branch = branchSet.FirstOrDefault(f => f.BRANCH.Equals(creditItem.Branch));

                    if (branch == null)
                    {
                        result.Add(new Model.ProductionSummary()
                        {
                            InsuranceFirm = insuranceItem.InsuranceFirm,
                            Branch = creditItem.Branch,
                            DebitCode = "",
                            CreditCode = "",
                            DebitTotal = 0m,
                            CreditTotal = 0m,
                            Status = (int)Model.ListStatus.HasError,
                            StatusDesc = "Şube Parametresi Bulunamadı"
                        });

                        continue;
                    }


                    result.Add(new Model.ProductionSummary()
                    {
                        InsuranceFirm = insuranceItem.InsuranceFirm,
                        Branch = creditItem.Branch,
                        DebitCode = "",
                        CreditCode = cmbTransType.SelectedIndex.Equals(0) ? branch.CREDITCODE : branch.HEALTHCREDITCODE,
                        DebitTotal = 0m,
                        CreditTotal = creditItem.CreditTotal,
                        Status = (int)Model.ListStatus.ListOK,
                        StatusDesc = ""
                    });
                }

                var debitList = insuranceItem.LineList.Where(f => f.DebitTotal > 0m).ToList();

                foreach (var debitItem in debitList)
                {
                    var branch = branchSet.FirstOrDefault(f => f.BRANCH.Equals(debitItem.Branch));

                    if (branch == null)
                    {
                        result.Add(new Model.ProductionSummary()
                        {
                            InsuranceFirm = insuranceItem.InsuranceFirm,
                            Branch = debitItem.Branch,
                            DebitCode = "",
                            CreditCode = "",
                            DebitTotal = 0m,
                            CreditTotal = 0m,
                            Status = (int)Model.ListStatus.HasError,
                            StatusDesc = "Şube Parametresi Bulunamadı"
                        });

                        continue;
                    }


                    result.Add(new Model.ProductionSummary()
                    {
                        InsuranceFirm = insuranceItem.InsuranceFirm,
                        Branch = debitItem.Branch,
                        DebitCode = cmbTransType.SelectedIndex.Equals(0) ? branch.DEBITCODE : branch.HEALTHDEBITCODE,
                        CreditCode = "",
                        DebitTotal = debitItem.DebitTotal,
                        CreditTotal = 0m,
                        Status = (int)Model.ListStatus.ListOK,
                        StatusDesc = ""
                    });
                }

                if(insuranceItem.GrossTotal > 0m)
                {
                    result.Add(new Model.ProductionSummary()
                    {
                        InsuranceFirm = insuranceItem.InsuranceFirm,
                        Branch = "ŞUBELER CARİ HES.",
                        DebitCode = otherSett.BRANCHCLCODE,
                        CreditCode = "",
                        DebitTotal = insuranceItem.GrossTotal,
                        CreditTotal = 0m,
                        Status = (int)Model.ListStatus.ListOK,
                        StatusDesc = ""
                    });
                }


                decimal creditTotal = insuranceItem.TotalCredit;
                decimal debitTotal = insuranceItem.TotalDebit + insuranceItem.GrossTotal;
                decimal diff = creditTotal - debitTotal;

                if(diff != 0m)
                {
                    result.Add(new Model.ProductionSummary()
                    {
                        InsuranceFirm = insuranceItem.InsuranceFirm,
                        Branch = insuranceItem.InsuranceFirm,
                        DebitCode = (diff < 0m ? "" : firm.CODE),
                        CreditCode = (diff < 0m ? firm.CODE : ""),
                        DebitTotal = (diff < 0m ? 0m : Math.Abs(diff)),
                        CreditTotal = (diff < 0m ? Math.Abs(diff) : 0m),
                        Status = (int)Model.ListStatus.ListOK,
                        StatusDesc = ""
                    });
                }

            }

            return result;                      
        }

        private void frmProdSummary_Load(object sender, EventArgs e)
        {
            deFicheDate.EditValue = DateTime.Now.Date;
            FillCurrency();
            cmbTransType.SelectedIndex = 0;
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

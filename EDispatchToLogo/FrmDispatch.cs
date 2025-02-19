using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityObjects;

namespace EDispatchToLogo
{
    public partial class FrmDispatch : Form
    {
        private bool isBatchTrans = false;
        UnityApplication myApp = new UnityApplication();
        private List<Model.LOGO.L_CITY> cityList = new List<Model.LOGO.L_CITY>();
        private List<Model.LOGO.L_TOWN> townList = new List<Model.LOGO.L_TOWN>();
        private List<Model.DispatchResult> dispatchTableResult = new List<Model.DispatchResult>();
        public FrmDispatch(bool pIsBatchTrans)
        {
            InitializeComponent();
            isBatchTrans = pIsBatchTrans;
        }

        private void FrmDispatch_Load(object sender, EventArgs e)
        {
            SetTitleForm();
        }

        #region Methods

        private void SetTitleForm()
        {
            this.Text = isBatchTrans ? "[Toplu İrsaliye Aktarımı]" : "[İrsaliye Aktarımı]";
        }

        #endregion

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            txtFile.EditValue = Helper.Common.OpenExcelFile();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            Control[] controls = GetControl();

            if (string.IsNullOrEmpty(txtFile.Text))
            {
                XtraMessageBox.Show("Excel Dosyası Seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Helper.Common.EnablePanelAndWaitingForm(ssm, controls, false, "Kayıtlar Aktarılıyor...");

            Model.LOGO.L_COUNTRY country = DataAccess.LOGO.L_COUNTRY_DAL.GetCountry("TR");

            if(country == null)
            {
                XtraMessageBox.Show("LOGO Ülke Bilgisi Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cityList = DataAccess.LOGO.L_CITY_DAL.GetCityList(country.COUNTRYNR);
            if (cityList == null)
            {
                XtraMessageBox.Show("LOGO Şehirler Bilgisi Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            townList = DataAccess.LOGO.L_TOWN_DAL.GetTownList(country.COUNTRYNR);
            if (townList == null)
            {
                XtraMessageBox.Show("LOGO İlçeler Bilgisi Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dispatchTableResult = new List<Model.DispatchResult>();

            if (!isBatchTrans)
            {
                List<Model.ExcelField.ExcelDispatch> excelItems = ExcelDispatch(txtFile.Text);

                if (excelItems == null || excelItems.Count.Equals(0))
                {
                    Helper.Common.EnablePanelAndWaitingForm(ssm, controls, true);
                    XtraMessageBox.Show("Excel Verileri Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }                

                string logoLoggedinError = string.Empty;
                myApp = new UnityApplication();

                if (!Helper.Common.IsLOGOConnect(myApp, ref logoLoggedinError))
                {
                    Helper.Common.EnablePanelAndWaitingForm(ssm, controls, true);
                    XtraMessageBox.Show(Model.GlobalParam.LogoFirmNR + " Numaralı Firma İle LOGO ya Bağlanılamadı! \n" + logoLoggedinError, "UYARI", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                TransfertoLogo(excelItems, txtFile.Text);
            }
            else
            {
                List<Model.ExcelField.ExcelBatchDispatch> excelItems = ExcelBatchDispatch(txtFile.Text);

                if (excelItems == null || excelItems.Count.Equals(0))
                {
                    Helper.Common.EnablePanelAndWaitingForm(ssm, controls, true);
                    XtraMessageBox.Show("Excel Verileri Bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }                

                string logoLoggedinError = string.Empty;
                myApp = new UnityApplication();

                if (!Helper.Common.IsLOGOConnect(myApp, ref logoLoggedinError))
                {
                    Helper.Common.EnablePanelAndWaitingForm(ssm, controls, true);
                    XtraMessageBox.Show(Model.GlobalParam.LogoFirmNR + " Numaralı Firma İle LOGO ya Bağlanılamadı! \n" + logoLoggedinError, "UYARI", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                TransferBatchtoLogo(excelItems, txtFile.Text);
            }

            gc.DataSource = dispatchTableResult;
            gv.BestFitColumns();

            Helper.Common.LogoLobjectDisconnect(myApp);

            Helper.Common.EnablePanelAndWaitingForm(ssm, controls, true);

            XtraMessageBox.Show("Aktarım İşlemi Tamamlanmıştır.\n Excel Dosyasını Kontrol Ediniz", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<Model.ExcelField.ExcelDispatch> ExcelDispatch(string pFilePath)
        {
            List<Model.ExcelField.ExcelDispatch> result = new List<Model.ExcelField.ExcelDispatch>();

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(pFilePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets[1];

            int nRow = 2;
            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2 != null)
            {
                result.Add(new Model.ExcelField.ExcelDispatch()
                {
                    Index = nRow,
                    Imei = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2.ToString(),
                    Marka = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 2]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 2]).Value2.ToString(),
                    Model = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 3]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 3]).Value2.ToString(),
                    MusteriAdi = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 4]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 4]).Value2.ToString(),
                    MusteriSoyad = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 5]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 5]).Value2.ToString(),
                    Tckn = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 6]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 6]).Value2.ToString(),
                    Adres = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 7]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 7]).Value2.ToString(),
                    Ilce = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 8]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 8]).Value2.ToString(),
                    Il = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 9]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 9]).Value2.ToString(),
                    PostaKodu = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 10]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 10]).Value2.ToString(),
                    TasiyiciKodu = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 11]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 11]).Value2.ToString(),
                    TelNo = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 12]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 12]).Value2.ToString(),
                    Csmr = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 13]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 13]).Value2.ToString(),
                    Durum =""
                });

                nRow++;
            }

            app.Quit();
            workBook = null;
            workSheet = null;
            app = null;

            return result;
        }

        private List<Model.ExcelField.ExcelBatchDispatch> ExcelBatchDispatch(string pFilePath)
        {
            List<Model.ExcelField.ExcelBatchDispatch> result = new List<Model.ExcelField.ExcelBatchDispatch>();

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(pFilePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets[1];

            int nRow = 2;
            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2 != null)
            {
                result.Add(new Model.ExcelField.ExcelBatchDispatch()
                {
                    Index = nRow,
                    CariKod = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2.ToString(),
                    Imei = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 2]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 2]).Value2.ToString(),
                    Marka = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 3]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 3]).Value2.ToString(),
                    Model = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 4]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 4]).Value2.ToString(),
                    TasiyiciKodu = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 5]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 5]).Value2.ToString(),
                    Durum = ""
                });

                nRow++;
            }

            app.Quit();
            workBook = null;
            workSheet = null;
            app = null;

            return result;
        }
        
        private void TransfertoLogo(List<Model.ExcelField.ExcelDispatch> pExcelItems, string pPath)
        {
            using (SqlConnection conn = new SqlConnection(Model.GlobalParam.SqlLogoConnStr))
            {
                conn.Open();

                foreach (var item in pExcelItems)
                {
                    string arpCode = DataAccess.LOGO.LG_CLCARD_DAL.GetClCode(string.Format("Z.{0}", item.Tckn), Model.GlobalParam.LogoFirmNR, conn);

                    Model.Transfer.Dispatch dispatch = new Model.Transfer.Dispatch()
                    {
                        //ArpCode = string.Format("Z.{0}", item.Tckn),
                        ArpCode = arpCode,
                        FicheDate = DateTime.Now,
                        Description1 = "Taşıma amaçlıdır. Fatura edilmeyecektir.",
                        Description2 = item.Csmr,
                        ShippingCode = item.TasiyiciKodu,
                        Lines = new List<Model.Transfer.DispatchLine>()
                        {
                            new Model.Transfer.DispatchLine()
                            {
                                ItemCode = string.Format("Z.{0}", item.Imei),
                                Description = string.Format("{0} {1} {2}", item.Imei, item.Marka, item.Model),
                                Quantity = 1,
                                Amount = 1,
                                VatRate = 18
                            }
                        }
                    };

                    if (!DataAccess.LOGO.LG_ITEMS_DAL.IsExists(dispatch.Lines[0].ItemCode, Model.GlobalParam.LogoFirmNR, conn))
                    {
                        Model.Transfer.Item itemTran = new Model.Transfer.Item()
                        {
                            Code = dispatch.Lines[0].ItemCode,
                            Definition = string.Format("{0} {1}", item.Marka, item.Model),
                            SpeCode = item.Marka
                        };

                        Model.Transfer.TransferResult transResult = Transaction.Logo.Item.Add(myApp, itemTran);

                        if(!transResult.IsSucceed)
                        {
                            item.Durum = "Malzeme Oluşturulamadı : " + transResult.Msg;

                            dispatchTableResult.Add(new Model.DispatchResult()
                            {
                                Code = dispatch.Lines[0].ItemCode,
                                StatusDesc = item.Durum,
                                Status = 1
                            });

                            continue;
                        }
                        else
                        {
                            dispatchTableResult.Add(new Model.DispatchResult()
                            {
                                Code = dispatch.Lines[0].ItemCode,
                                StatusDesc = "OK >> Malzeme Kartı Oluşturuldu",
                                Status = 2
                            });
                        }
                    }

                    var arpCity = cityList.FirstOrDefault(f => f.NAME.ToLower().Equals(item.Il.ToLower(), StringComparison.CurrentCultureIgnoreCase)
                                                                || f.NAME.ToUpper().Equals(item.Il.ToUpper(), StringComparison.CurrentCultureIgnoreCase));

                    if (arpCity == null)
                    {
                        item.Durum = string.Format("{0} İl Bilgisi Logo da Bulunamadı", item.Il);

                        dispatchTableResult.Add(new Model.DispatchResult()
                        {
                            Code = dispatch.ArpCode,
                            StatusDesc = item.Durum,
                            Status = 1
                        });

                        continue;
                    }

                    var arpTown = townList.FirstOrDefault(f => f.CTYREF == arpCity.LOGICALREF &&
                                                                (f.NAME.ToLower().Equals(item.Ilce.ToLower(), StringComparison.CurrentCultureIgnoreCase)
                                                                    || f.NAME.ToUpper().Equals(item.Ilce.ToUpper(), StringComparison.CurrentCultureIgnoreCase)));

                    if (arpTown == null)
                    {
                        item.Durum = string.Format("{0} İlçe Bilgisi Logo da Bulunamadı", item.Ilce);

                        dispatchTableResult.Add(new Model.DispatchResult()
                        {
                            Code = dispatch.ArpCode,
                            StatusDesc = item.Durum,
                            Status = 1
                        });

                        continue;
                    }

                    Model.Transfer.ArpCard arpTran = new Model.Transfer.ArpCard()
                    {
                        Code = dispatch.ArpCode,
                        Name = item.MusteriAdi,
                        Surname = item.MusteriSoyad,
                        Tckn = item.Tckn,
                        Adress = item.Adres,
                        District = arpTown.NAME,
                        DistrictCode = arpTown.CODE,
                        City = arpCity.NAME,
                        CityCode = arpCity.CODE,
                        PostalCode = item.PostaKodu,
                        Telephone1 = item.TelNo
                    };

                    Model.Transfer.TransferResult transResultArp = Transaction.Logo.ClCard.Add(myApp, arpTran);

                    if (!transResultArp.IsSucceed)
                    {
                        item.Durum = "Cari Kart Oluşturulamadı : " + transResultArp.Msg;

                        dispatchTableResult.Add(new Model.DispatchResult()
                        {
                            Code = dispatch.ArpCode,
                            StatusDesc = item.Durum,
                            Status = 1
                        });

                        continue;
                    }
                    else
                    {
                        dispatchTableResult.Add(new Model.DispatchResult()
                        {
                            Code = dispatch.ArpCode,
                            StatusDesc = "OK >> Cari Kartı Oluşturuldu",
                            Status = 2
                        });
                    }


                    #region eski

                    //if(!DataAccess.LOGO.LG_CLCARD_DAL.IsExists(dispatch.ArpCode, Model.GlobalParam.LogoFirmNR, conn))
                    //{
                    //    var arpCity = cityList.FirstOrDefault(f => f.NAME.ToLower().Equals(item.Il.ToLower(), StringComparison.CurrentCultureIgnoreCase) 
                    //                                            || f.NAME.ToUpper().Equals(item.Il.ToUpper(), StringComparison.CurrentCultureIgnoreCase));

                    //    if(arpCity == null)
                    //    {
                    //        item.Durum = string.Format("{0} İl Bilgisi Logo da Bulunamadı", item.Il);

                    //        dispatchTableResult.Add(new Model.DispatchResult()
                    //        {
                    //            Code = dispatch.ArpCode,
                    //            StatusDesc = item.Durum,
                    //            Status = 1
                    //        });

                    //        continue;
                    //    }

                    //    var arpTown = townList.FirstOrDefault(f => f.CTYREF == arpCity.LOGICALREF &&
                    //                                                (f.NAME.ToLower().Equals(item.Ilce.ToLower(), StringComparison.CurrentCultureIgnoreCase)
                    //                                                    || f.NAME.ToUpper().Equals(item.Ilce.ToUpper(), StringComparison.CurrentCultureIgnoreCase)));

                    //    if (arpTown == null)
                    //    {
                    //        item.Durum = string.Format("{0} İlçe Bilgisi Logo da Bulunamadı", item.Ilce);

                    //        dispatchTableResult.Add(new Model.DispatchResult()
                    //        {
                    //            Code = dispatch.ArpCode,
                    //            StatusDesc = item.Durum,
                    //            Status = 1
                    //        });

                    //        continue;
                    //    }

                    //    Model.Transfer.ArpCard arpTran = new Model.Transfer.ArpCard()
                    //    {
                    //        Code = dispatch.ArpCode,
                    //        Name = item.MusteriAdi,
                    //        Surname = item.MusteriSoyad,
                    //        Tckn = item.Tckn,
                    //        Adress = item.Adres,
                    //        District = arpTown.NAME,
                    //        DistrictCode = arpTown.CODE,
                    //        City = arpCity.NAME,
                    //        CityCode = arpCity.CODE,
                    //        PostalCode = item.PostaKodu,
                    //        Telephone1 = item.TelNo
                    //    };

                    //    Model.Transfer.TransferResult transResult = Transaction.Logo.ClCard.Add(myApp, arpTran);

                    //    if (!transResult.IsSucceed)
                    //    {
                    //        item.Durum = "Cari Kart Oluşturulamadı : " + transResult.Msg;

                    //        dispatchTableResult.Add(new Model.DispatchResult()
                    //        {
                    //            Code = dispatch.ArpCode,
                    //            StatusDesc = item.Durum,
                    //            Status = 1
                    //        });

                    //        continue;
                    //    }
                    //    else
                    //    {
                    //        dispatchTableResult.Add(new Model.DispatchResult()
                    //        {
                    //            Code = dispatch.ArpCode,
                    //            StatusDesc = "OK >> Cari Kartı Oluşturuldu",
                    //            Status = 2
                    //        });
                    //    }
                    //}

                    #endregion

                    Model.Transfer.TransferResult dispatchResult = Transaction.Logo.Dispatch.Add(myApp, dispatch);

                    if (!dispatchResult.IsSucceed)
                    {
                        item.Durum = "Fiş Oluşturulamadı : " + dispatchResult.Msg;

                        dispatchTableResult.Add(new Model.DispatchResult()
                        {
                            Code = "",
                            StatusDesc = item.Durum,
                            Status = 1
                        });

                        continue;
                    }
                    else
                    {
                        item.Durum = "Fiş No : " + dispatchResult.Msg;

                        dispatchTableResult.Add(new Model.DispatchResult()
                        {
                            Code = "",
                            StatusDesc = "OK >> " + item.Durum,
                            Status = 2
                        });
                    }
                }

                conn.Close();
            }

            SetExcelFile(pExcelItems, pPath);
        }

        private void TransferBatchtoLogo(List<Model.ExcelField.ExcelBatchDispatch> pExcelBatchItems, string pPath)
        {
            var grpItems = pExcelBatchItems.GroupBy(g => g.CariKod).Select(s => new
            {
                CariKod = s.Key,
                List = s.ToList()
            }).ToList();

            using (SqlConnection conn = new SqlConnection(Model.GlobalParam.SqlLogoConnStr))
            {
                conn.Open();

                foreach (var item in grpItems)
                {
                    Model.Transfer.Dispatch dispatch = new Model.Transfer.Dispatch()
                    {
                        ArpCode = item.CariKod,
                        FicheDate = DateTime.Now,
                        Description1 = "Taşıma amaçlıdır. Fatura edilmeyecektir.",
                        Description2 = "",
                        ShippingCode = item.List[0].TasiyiciKodu,
                    };

                    List<Model.Transfer.DispatchLine> lineList = new List<Model.Transfer.DispatchLine>();

                    foreach (var lineItem in item.List)
                    {
                        string itemCode = string.Format("Z.{0}", lineItem.Imei);

                        if (!DataAccess.LOGO.LG_ITEMS_DAL.IsExists(itemCode, Model.GlobalParam.LogoFirmNR, conn))
                        {
                            Model.Transfer.Item itemTran = new Model.Transfer.Item()
                            {
                                Code = itemCode,
                                Definition = string.Format("{0} {1}", lineItem.Marka, lineItem.Model),
                                SpeCode = lineItem.Marka
                            };

                            Model.Transfer.TransferResult transResult = Transaction.Logo.Item.Add(myApp, itemTran);

                            if (!transResult.IsSucceed)
                            {
                                lineItem.Durum = "Malzeme Oluşturulamadı : " + transResult.Msg;

                                dispatchTableResult.Add(new Model.DispatchResult()
                                {
                                    Code = dispatch.Lines[0].ItemCode,
                                    StatusDesc = lineItem.Durum,
                                    Status = 1
                                });

                                continue;
                            }
                            else
                            {
                                dispatchTableResult.Add(new Model.DispatchResult()
                                {
                                    Code = dispatch.Lines[0].ItemCode,
                                    StatusDesc = "OK >> Malzeme Kartı Oluşturuldu",
                                    Status = 2
                                });
                            }
                        }

                        Model.Transfer.DispatchLine dispatchLine = new Model.Transfer.DispatchLine()
                        {
                            ItemCode = itemCode,
                            Description = string.Format("{0} {1} {2}", lineItem.Imei, lineItem.Marka, lineItem.Model),
                            Quantity = 1,
                            Amount = 1,
                            VatRate = 18
                        };

                        lineList.Add(dispatchLine);
                    }


                    dispatch.Lines = lineList;
                    

                    Model.Transfer.TransferResult dispatchResult = Transaction.Logo.Dispatch.Add(myApp, dispatch);

                    if (!dispatchResult.IsSucceed)
                    {
                        item.List[0].Durum = "Fiş Oluşturulamadı : " + dispatchResult.Msg;

                        dispatchTableResult.Add(new Model.DispatchResult()
                        {
                            Code = "",
                            StatusDesc = item.List[0].Durum,
                            Status = 1
                        });

                        continue;
                    }
                    else
                    {
                        item.List[0].Durum = "Fiş No : " + dispatchResult.Msg;

                        dispatchTableResult.Add(new Model.DispatchResult()
                        {
                            Code = "",
                            StatusDesc = "OK >> " + item.List[0].Durum,
                            Status = 2
                        });
                    }
                }

                conn.Close();
            }

            SetBatchExcelFile(pExcelBatchItems, pPath);
        }
        
        private void SetExcelFile(List<Model.ExcelField.ExcelDispatch> pExcelItems, string pPath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(pPath, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets[1];

            foreach (var item in pExcelItems)
            {
                try
                {
                    ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[item.Index, 14]).Value2 = item.Durum;                    
                }
                catch
                {
                }
            }


            workBook.Save();
            app.Quit();
            workBook = null;
            workSheet = null;
            app = null;
        }

        private void SetBatchExcelFile(List<Model.ExcelField.ExcelBatchDispatch> pExcelBatchItems, string pPath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(pPath, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets[1];

            foreach (var item in pExcelBatchItems)
            {
                try
                {
                    ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[item.Index, 6]).Value2 = item.Durum;
                }
                catch
                {
                }
            }


            workBook.Save();
            app.Quit();
            workBook = null;
            workSheet = null;
            app = null;
        }

        #region Specific Methods

        private Control[] GetControl()
        {
            return new Control[]
                   {
                        pnlTop, pnlFill
                   };
        }
        
        #endregion
    }
}

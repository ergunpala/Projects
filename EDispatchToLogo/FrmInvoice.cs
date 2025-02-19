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
    public partial class FrmInvoice : Form
    {        
        UnityApplication myApp = new UnityApplication();        
        private List<Model.InvoiceResult> invoiceTableResult = new List<Model.InvoiceResult>();
        public FrmInvoice()
        {
            InitializeComponent();            
        }

        private void FrmInvoice_Load(object sender, EventArgs e)
        {            
        }

        #region Methods

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
            

            invoiceTableResult = new List<Model.InvoiceResult>();

            List<Model.ExcelField.ExcelInvoice> excelItems = ExcelInvoice(txtFile.Text);

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

            TransferBatchInvoicetoLogo(excelItems, txtFile.Text);

            gc.DataSource = invoiceTableResult;
            gv.BestFitColumns();

            Helper.Common.LogoLobjectDisconnect(myApp);

            Helper.Common.EnablePanelAndWaitingForm(ssm, controls, true);

            XtraMessageBox.Show("Aktarım İşlemi Tamamlanmıştır.\n Excel Dosyasını Kontrol Ediniz", "BILGI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

        private List<Model.ExcelField.ExcelInvoice> ExcelInvoice(string pFilePath)
        {
            List<Model.ExcelField.ExcelInvoice> result = new List<Model.ExcelField.ExcelInvoice>();

            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(pFilePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets[1];

            int nRow = 2;
            while (((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2 != null)
            {
                result.Add(new Model.ExcelField.ExcelInvoice()
                {
                    Index = nRow,
                    CariKod = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 1]).Value2.ToString(),
                    Imei = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 2]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 2]).Value2.ToString(),
                    Marka = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 3]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 3]).Value2.ToString(),
                    Model = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 4]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 4]).Value2.ToString(),
                    TasiyiciKodu = ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 5]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 5]).Value2.ToString(),
                    Tutar = decimal.Parse(((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 6]).Value2 == null ? "" : ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[nRow, 6]).Value2.ToString()),
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

        private void TransferBatchInvoicetoLogo(List<Model.ExcelField.ExcelInvoice> pExcelInvoice, string pPath)
        {
            var grpItems = pExcelInvoice.GroupBy(g => g.CariKod).Select(s => new
            {
                CariKod = s.Key,
                List = s.ToList()
            }).ToList();

            using (SqlConnection conn = new SqlConnection(Model.GlobalParam.SqlLogoConnStr))
            {
                conn.Open();

                foreach (var item in grpItems)
                {
                    Model.Transfer.Invoice invoice = new Model.Transfer.Invoice()
                    {
                        ArpCode = item.CariKod,
                        FicheDate = DateTime.Now,
                        Description1 = "",
                        Description2 = "",
                        ShippingCode = item.List[0].TasiyiciKodu                        
                    };

                    Model.LOGO.L_CLCARD clCard = DataAccess.LOGO.LG_CLCARD_DAL.GetForInvoice(invoice.ArpCode, Model.GlobalParam.LogoFirmNR, conn);
                    
                    if(clCard == null)
                    {
                        invoiceTableResult.Add(new Model.InvoiceResult()
                        {
                            Code = invoice.ArpCode,
                            StatusDesc = "Cari Bulunamadı",
                            Status = 1
                        });

                        item.List[0].Durum = "Cari Bulunamadı";

                        continue;
                    }

                    invoice.AcceptInv = clCard.ACCEPTEINV;
                    invoice.ProfileID = clCard.PROFILEID;


                    List<Model.Transfer.InvoiceLine> lineList = new List<Model.Transfer.InvoiceLine>();

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

                                invoiceTableResult.Add(new Model.InvoiceResult()
                                {
                                    Code = invoice.Lines[0].ItemCode,
                                    StatusDesc = lineItem.Durum,
                                    Status = 1
                                });

                                continue;
                            }
                            else
                            {
                                invoiceTableResult.Add(new Model.InvoiceResult()
                                {
                                    Code = invoice.Lines[0].ItemCode,
                                    StatusDesc = "OK >> Malzeme Kartı Oluşturuldu",
                                    Status = 2
                                });
                            }
                        }

                        Model.Transfer.InvoiceLine invoiceLine = new Model.Transfer.InvoiceLine()
                        {
                            ItemCode = itemCode,
                            Description = string.Format("{0} {1} {2}", lineItem.Imei, lineItem.Marka, lineItem.Model),
                            Quantity = 1,
                            UnitPrice = Convert.ToDouble(lineItem.Tutar),
                            VatRate = 18
                        };

                        lineList.Add(invoiceLine);
                    }


                    invoice.Lines = lineList;


                    Model.Transfer.TransferResult invoiceResult = Transaction.Logo.Invoice.Add(myApp, invoice);

                    if (!invoiceResult.IsSucceed)
                    {
                        item.List[0].Durum = "Fiş Oluşturulamadı : " + invoiceResult.Msg;

                        invoiceTableResult.Add(new Model.InvoiceResult()
                        {
                            Code = "",
                            StatusDesc = item.List[0].Durum,
                            Status = 1
                        });

                        continue;
                    }
                    else
                    {
                        item.List[0].Durum = "Fiş No : " + invoiceResult.Msg;

                        invoiceTableResult.Add(new Model.InvoiceResult()
                        {
                            Code = "",
                            StatusDesc = "OK >> " + item.List[0].Durum,
                            Status = 2
                        });
                    }
                }

                conn.Close();
            }

            SetBatchExcelFile(pExcelInvoice, pPath);
        }        

        private void SetBatchExcelFile(List<Model.ExcelField.ExcelInvoice> pExcelInvoice, string pPath)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook = app.Workbooks.Open(pPath, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets[1];

            foreach (var item in pExcelInvoice)
            {
                try
                {
                    ((Microsoft.Office.Interop.Excel.Range)workSheet.Cells[item.Index, 7]).Value2 = item.Durum;
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

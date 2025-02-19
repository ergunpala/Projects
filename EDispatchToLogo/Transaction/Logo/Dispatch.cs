using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityObjects;

namespace EDispatchToLogo.Transaction.Logo
{
    public static class Dispatch
    {
        public static Model.Transfer.TransferResult Add(UnityApplication pMyApp, Model.Transfer.Dispatch pDispatch)
        {
            Model.Transfer.TransferResult result = new Model.Transfer.TransferResult()
            {
                IsSucceed = false,
                Msg = ""
            };

            UnityObjects.IData lObject = pMyApp.NewDataObject(DataObjectType.doSalesDispatch);

            lObject.New();
            lObject.DataFields.FieldByName("TYPE").Value = 8;
            lObject.DataFields.FieldByName("NUMBER").Value = "~";
            lObject.DataFields.FieldByName("DATE").Value = pDispatch.FicheDate;
            lObject.DataFields.FieldByName("TIME").Value = 270276609;
            lObject.DataFields.FieldByName("ARP_CODE").Value = pDispatch.ArpCode;
            lObject.DataFields.FieldByName("NOTES1").Value = pDispatch.Description1;
            lObject.DataFields.FieldByName("NOTES2").Value = pDispatch.Description2;
            lObject.DataFields.FieldByName("SHIPPING_AGENT").Value = pDispatch.ShippingCode;
            lObject.DataFields.FieldByName("CURRSEL_TOTALS").Value = 1;

            ILines ILine = lObject.DataFields.FieldByName("TRANSACTIONS").Lines;

            foreach (var line in pDispatch.Lines)
            {
                ILine.AppendLine();
                ILine[ILine.Count - 1].FieldByName("TYPE").Value = 0;
                ILine[ILine.Count - 1].FieldByName("MASTER_CODE").Value = line.ItemCode;
                ILine[ILine.Count - 1].FieldByName("QUANTITY").Value = Helper.Common.GetConvertToDouble(line.Quantity);
                ILine[ILine.Count - 1].FieldByName("PRICE").Value = Helper.Common.GetConvertToDouble(line.Amount);
                ILine[ILine.Count - 1].FieldByName("TOTAL").Value = Helper.Common.GetConvertToDouble(line.Amount);
                ILine[ILine.Count - 1].FieldByName("DESCRIPTION").Value = line.Description;
                ILine[ILine.Count - 1].FieldByName("UNIT_CODE").Value = "05";
                ILine[ILine.Count - 1].FieldByName("UNIT_CONV1").Value = 1;
                ILine[ILine.Count - 1].FieldByName("UNIT_CONV2").Value = 1;
                ILine[ILine.Count - 1].FieldByName("VAT_RATE").Value = Helper.Common.GetConvertToDouble(line.VatRate);
                ILine[ILine.Count - 1].FieldByName("VAT_BASE").Value = Helper.Common.GetConvertToDouble(line.Amount);
                ILine[ILine.Count - 1].FieldByName("TOTAL_NET").Value = Helper.Common.GetConvertToDouble(line.Amount);
                ILine[ILine.Count - 1].FieldByName("MULTI_ADD_TAX").Value = 0;
                ILine[ILine.Count - 1].FieldByName("EDT_CURR").Value = 20;
                ILine[ILine.Count - 1].FieldByName("UNIT_GLOBAL_CODE").Value = "NIU";
                ILine[ILine.Count - 1].FieldByName("EDTCURR_GLOBAL_CODE").Value = "EUR";
            }

            lObject.DataFields.FieldByName("DEDUCTIONPART1").Value = 2;
            lObject.DataFields.FieldByName("DEDUCTIONPART2").Value = 3;
            lObject.DataFields.FieldByName("AFFECT_RISK").Value = 0;
            lObject.DataFields.FieldByName("DISP_STATUS").Value = 1;
            lObject.DataFields.FieldByName("SHIP_DATE").Value = pDispatch.FicheDate;
            lObject.DataFields.FieldByName("SHIP_TIME").Value = 270276609;
            lObject.DataFields.FieldByName("DOC_DATE").Value = pDispatch.FicheDate;
            lObject.DataFields.FieldByName("DOC_TIME").Value = 270276608;
            lObject.DataFields.FieldByName("EDESPATCH").Value = 1;
            lObject.DataFields.FieldByName("EINVOICE").Value = 2;
            lObject.DataFields.FieldByName("EARCHIVEDETR_SENDMOD").Value = 1;
            lObject.DataFields.FieldByName("EARCHIVEDETR_INTPAYMENTTYPE").Value = 4;
            //lObject.DataFields.FieldByName("EDESPATCH_PROFILEID").Value = 2;
            //lObject.DataFields.FieldByName("EDESPATCH_STATUS").Value = 22;
            //lObject.DataFields.FieldByName("EINVOICE").Value = 1;
            //lObject.DataFields.FieldByName("EINVOICE_PROFILEID").Value = 2;

            lObject.FillAccCodes();

            if (!lObject.Post())
            {
                string error = "HATA (LOGO) >> ";

                if (lObject.ValidateErrors.Count > 0)
                {
                    for (int i = 0; i < lObject.ValidateErrors.Count; i++)
                    {
                        error += lObject.ValidateErrors[i].Error;
                    }
                }

                result.IsSucceed = false;
                result.Msg = error;
            }
            else
            {
                string ficheNo = lObject.DataFields.DBFieldByName("FICHENO").Value;


                result.IsSucceed = true;
                result.Msg = ficheNo;
            }

            return result;
        }
    }
}

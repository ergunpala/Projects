using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityObjects;

namespace EMFicheToLogo.Transaction.Logo
{
    public static class EmfTrans
    {
        public static Model.Transaction.Result AddFiche(UnityApplication pMyApp, Model.Transaction.EmFiche pEmFiche)
        {
            Model.Transaction.Result result = new Model.Transaction.Result();

            UnityObjects.IData lObject = pMyApp.NewDataObject(DataObjectType.doGLVoucher);

            lObject.New();
            lObject.DataFields.FieldByName("TYPE").Value = 4;
            lObject.DataFields.FieldByName("NUMBER").Value = "~";
            lObject.DataFields.FieldByName("DATE").Value = pEmFiche.DATE.Date.ToString("dd.MM.yyyy");            
            lObject.DataFields.FieldByName("DOC_DATE").Value = lObject.DataFields.FieldByName("DATE").Value;
            lObject.DataFields.FieldByName("NOTES1").Value = pEmFiche.NOTES1;
            lObject.DataFields.FieldByName("CURRSEL_TOTALS").Value = "1";            

            ILines ILine = lObject.DataFields.FieldByName("TRANSACTIONS").Lines;

            foreach (var line in pEmFiche.Lines)
            {
                ILine.AppendLine();

                if (line.DEBIT > 0m)
                {
                    ILine[ILine.Count - 1].FieldByName("GL_CODE").Value = line.GL_CODE;
                    ILine[ILine.Count - 1].FieldByName("DEBIT").Value = Model.AppClass.GetConvertToDouble(line.DEBIT);
                    ILine[ILine.Count - 1].FieldByName("LINENO").Value = 1;
                    ILine[ILine.Count - 1].FieldByName("DESCRIPTION").Value = line.DESCRIPTION;
                    ILine[ILine.Count - 1].FieldByName("TC_AMOUNT").Value = Model.AppClass.GetConvertToDouble(line.DEBIT);
                }
                else
                {
                    ILine[ILine.Count - 1].FieldByName("GL_CODE").Value = line.GL_CODE;
                    ILine[ILine.Count - 1].FieldByName("SIGN").Value = 1;
                    ILine[ILine.Count - 1].FieldByName("CREDIT").Value = Model.AppClass.GetConvertToDouble(line.CREDIT);
                    ILine[ILine.Count - 1].FieldByName("LINENO").Value = 1;
                    ILine[ILine.Count - 1].FieldByName("DESCRIPTION").Value = line.DESCRIPTION;
                    ILine[ILine.Count - 1].FieldByName("TC_AMOUNT").Value = Model.AppClass.GetConvertToDouble(line.CREDIT);
                }
            }

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
                result.Desc = error;                
            }
            else
            {
                string error = "(LOGO) >> OK";

                int postedLogicalRef = Convert.ToInt32(lObject.DataFields.DBFieldByName("LOGICALREF").Value);
                string ficheNo = lObject.DataFields.DBFieldByName("FICHENO").Value;

                result.IsSucceed = true;
                result.FicheNo = ficheNo;
            }

            return result;
        }
    }
}

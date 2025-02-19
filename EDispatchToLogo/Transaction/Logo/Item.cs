using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityObjects;

namespace EDispatchToLogo.Transaction.Logo
{
    public static class Item
    {
        public static Model.Transfer.TransferResult Add(UnityApplication pMyApp, Model.Transfer.Item pItem)
        {
            Model.Transfer.TransferResult result = new Model.Transfer.TransferResult()
            {
                IsSucceed = false,
                Msg = ""
            };

            UnityObjects.IData lObject = pMyApp.NewDataObject(DataObjectType.doMaterial);

            lObject.New();
            lObject.DataFields.FieldByName("CARD_TYPE").Value = 1;
            lObject.DataFields.FieldByName("CODE").Value = pItem.Code;
            lObject.DataFields.FieldByName("NAME").Value = pItem.Definition;
            lObject.DataFields.FieldByName("AUXIL_CODE").Value = pItem.SpeCode;
            lObject.DataFields.FieldByName("USEF_PURCHASING").Value = 1;
            lObject.DataFields.FieldByName("USEF_SALES").Value = 1;
            lObject.DataFields.FieldByName("USEF_MM").Value = 1;
            lObject.DataFields.FieldByName("VAT").Value = 18;
            lObject.DataFields.FieldByName("UNITSET_CODE").Value = "05";


            ILines ILine = lObject.DataFields.FieldByName("WH_PARAMS").Lines;

            ILine.AppendLine();
            ILine[ILine.Count - 1].FieldByName("WH_NUMBER").Value = 0;
            ILine[ILine.Count - 1].FieldByName("BACKORDER_FLAG").Value = 0;


            //for (int i = 1; i <= 8; i++)
            //{
            //    ILine.AppendLine();
            //    ILine[ILine.Count - 1].FieldByName("WH_NUMBER").Value = i;
            //    ILine[ILine.Count - 1].FieldByName("BACKORDER_FLAG").Value = 2;
            //}

            ILines ILineUnits = lObject.DataFields.FieldByName("UNITS").Lines;
            ILineUnits.AppendLine();
            ILineUnits[ILineUnits.Count - 1].FieldByName("UNIT_CODE").Value = "05";
            ILineUnits[ILineUnits.Count - 1].FieldByName("USEF_MTRLCLASS").Value = 1;
            ILineUnits[ILineUnits.Count - 1].FieldByName("USEF_PURCHCLAS").Value = 1;
            ILineUnits[ILineUnits.Count - 1].FieldByName("USEF_SALESCLAS").Value = 1;
            ILineUnits[ILineUnits.Count - 1].FieldByName("CONV_FACT1").Value = 1;
            ILineUnits[ILineUnits.Count - 1].FieldByName("CONV_FACT2").Value = 1;


            int[] infoTypes = new int[]
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,95,96,99,135,136,137,143,162,172,199
            };


            ILines ILineGLLinks = lObject.DataFields.FieldByName("GL_LINKS").Lines;

            foreach(var infoType in infoTypes)
            {
                ILineGLLinks.AppendLine();
                ILineGLLinks[ILineGLLinks.Count - 1].FieldByName("INFO_TYPE").Value = infoType;
            }           

            lObject.DataFields.FieldByName("MULTI_ADD_TAX").Value = 0;
            lObject.DataFields.FieldByName("PACKET").Value = 0;
            lObject.DataFields.FieldByName("SELVAT").Value = 18;
            lObject.DataFields.FieldByName("RETURNVAT").Value = 18;
            lObject.DataFields.FieldByName("SELPRVAT").Value = 18;
            lObject.DataFields.FieldByName("RETURNPRVAT").Value = 18;
            lObject.DataFields.FieldByName("SALE_DEDUCTION_PART1").Value = 2;
            lObject.DataFields.FieldByName("SALE_DEDUCTION_PART2").Value = 3;
            lObject.DataFields.FieldByName("PURCH_DEDUCTION_PART1").Value = 2;
            lObject.DataFields.FieldByName("PURCH_DEDUCTION_PART2").Value = 3;

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
                result.IsSucceed = true;
                result.Msg = "";
            }

            return result;
        }
    }
}

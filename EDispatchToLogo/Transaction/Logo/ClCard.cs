using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityObjects;

namespace EDispatchToLogo.Transaction.Logo
{
    public static class ClCard
    {
        public static Model.Transfer.TransferResult Add(UnityApplication pMyApp, Model.Transfer.ArpCard pArpCard)
        {
            Model.Transfer.TransferResult result = new Model.Transfer.TransferResult()
            {
                IsSucceed = false,
                Msg = ""
            };

            UnityObjects.IData lObject = pMyApp.NewDataObject(DataObjectType.doAccountsRP);

            lObject.New();
            lObject.DataFields.FieldByName("ACCOUNT_TYPE").Value = 3;
            lObject.DataFields.FieldByName("CODE").Value = pArpCard.Code;
            lObject.DataFields.FieldByName("TITLE").Value = string.Format("{0} {1}", pArpCard.Name, pArpCard.Surname);
            lObject.DataFields.FieldByName("ADDRESS1").Value = pArpCard.Adress;
            lObject.DataFields.FieldByName("TOWN_CODE").Value = pArpCard.DistrictCode;
            lObject.DataFields.FieldByName("TOWN").Value = pArpCard.District;
            lObject.DataFields.FieldByName("CITY_CODE").Value = pArpCard.CityCode;
            lObject.DataFields.FieldByName("CITY").Value = pArpCard.City;
            lObject.DataFields.FieldByName("COUNTRY_CODE").Value = "TR";
            lObject.DataFields.FieldByName("TELEPHONE1").Value = pArpCard.Telephone1;
            lObject.DataFields.FieldByName("POSTAL_CODE").Value = pArpCard.PostalCode;
            lObject.DataFields.FieldByName("CREDIT_TYPE").Value = 1;
            lObject.DataFields.FieldByName("RISKFACT_CHQ").Value = 1;
            lObject.DataFields.FieldByName("RISKFACT_PROMNT").Value = 1;
            lObject.DataFields.FieldByName("CL_ORD_FREQ").Value = 1;
            lObject.DataFields.FieldByName("INVOICE_PRNT_CNT").Value = 1;
            lObject.DataFields.FieldByName("PURCHBRWS").Value = 1;
            lObject.DataFields.FieldByName("SALESBRWS").Value = 1;
            lObject.DataFields.FieldByName("IMPBRWS").Value = 1;
            lObject.DataFields.FieldByName("EXPBRWS").Value = 1;
            lObject.DataFields.FieldByName("FINBRWS").Value = 1;
            lObject.DataFields.FieldByName("COLLATRLRISK_TYPE").Value = 1;
            lObject.DataFields.FieldByName("PERSCOMPANY").Value = 1;
            lObject.DataFields.FieldByName("TCKNO").Value = pArpCard.Tckn;
            lObject.DataFields.FieldByName("PROFILE_ID").Value = 2;
            lObject.DataFields.FieldByName("NAME").Value = pArpCard.Name;
            lObject.DataFields.FieldByName("SURNAME").Value = pArpCard.Surname;
            lObject.DataFields.FieldByName("PROFILEID_DESP").Value = 1;

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
                result.Msg = pArpCard.Code;
            }

            return result;
        }
    }
}

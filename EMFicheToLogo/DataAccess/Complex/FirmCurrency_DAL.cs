using EMFicheToLogo.Model.Complex;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFicheToLogo.DataAccess.Complex
{
    public static class FirmCurrency_DAL
    {
        public static List<FirmCurrency> GetList(string pCurrency)
        {
            List<FirmCurrency> result = new List<FirmCurrency>();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                FS.ID,
	                                FS.FIRM,
	                                ISNULL(FSC.CODE,'') AS CODE
                                FROM FIRMSETT FS (NOLOCK)
                                LEFT JOIN FIRMSETTCURR FSC (NOLOCK) ON FS.ID = FSC.FIRMSETTID	
	                                AND FSC.CURRENCY = @CURRENCY
                                ORDER BY FS.FIRM
                                ";
                    SqlParameter prmCURRENCY = new SqlParameter("@CURRENCY", SqlDbType.VarChar, 5);
                    prmCURRENCY.Value = pCurrency;

                    cmd.Parameters.Add(prmCURRENCY);


                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                conn.Close();
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.AsEnumerable().Select(s => new FirmCurrency
                {
                    ID = int.Parse(s["ID"].ToString()),
                    FIRM = s["FIRM"].ToString(),
                    CODE = s["CODE"].ToString()
                }).ToList();
            }

            return result;
        }
    }
}

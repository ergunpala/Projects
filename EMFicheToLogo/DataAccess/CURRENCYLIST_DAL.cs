using EMFicheToLogo.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EMFicheToLogo.DataAccess
{
    public static class CURRENCYLIST_DAL
    {
        public static List<CURRENCYLIST> GetList()
        {
            List<CURRENCYLIST> result = new List<CURRENCYLIST>();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                CL.ID,
                                    CL.CURRENCY,
                                    CL.ORDR
                                FROM CURRENCYLIST CL (NOLOCK)       
                                ORDER BY CL.ORDR
                                ";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                conn.Close();
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.AsEnumerable().Select(s => new CURRENCYLIST
                {
                    ID = int.Parse(s["ID"].ToString()),
                    CURRENCY = s["CURRENCY"].ToString(),
                    ORDR = int.Parse(s["ORDR"].ToString())
                }).ToList();
            }

            return result;
        }
    }
}

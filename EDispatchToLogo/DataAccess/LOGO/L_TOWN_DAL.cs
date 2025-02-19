using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.DataAccess.LOGO
{
    public static class L_TOWN_DAL
    {
        public static List<Model.LOGO.L_TOWN> GetTownList(int pCountry)
        {
            List<Model.LOGO.L_TOWN> result = new List<Model.LOGO.L_TOWN>();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.GlobalParam.SqlLogoConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT 
	                                TW.CTYREF,
	                                TW.CODE,
	                                TW.NAME	                                
                                FROM L_TOWN (NOLOCK) TW
                                WHERE TW.CNTRNR = @COUNTRY                                
                                ";

                    SqlParameter prmCOUNTRY = new SqlParameter("@COUNTRY", SqlDbType.Int);
                    prmCOUNTRY.Value = pCountry;

                    cmd.Parameters.Add(prmCOUNTRY);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                conn.Close();
            }


            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.AsEnumerable().Select(s => new Model.LOGO.L_TOWN
                {
                    CTYREF = int.Parse(s["CTYREF"].ToString()),
                    CODE = s["CODE"].ToString(),
                    NAME = s["NAME"].ToString()
                }).ToList();
            }

            return result;
        }
    }
}

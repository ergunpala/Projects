using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.DataAccess.LOGO
{
    public static class L_COUNTRY_DAL
    {
        public static Model.LOGO.L_COUNTRY GetCountry(string pCode)
        {
            Model.LOGO.L_COUNTRY result = null;

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.GlobalParam.SqlLogoConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT 
	                                TOP 1 
	                                CTR.COUNTRYNR,
	                                CTR.CODE,
	                                CTR.NAME	                                
                                FROM L_COUNTRY (NOLOCK) CTR
                                WHERE CTR.CODE = @CODE
                                ";

                    SqlParameter prmCODE = new SqlParameter("@CODE", SqlDbType.VarChar, 12);
                    prmCODE.Value = pCode;

                    cmd.Parameters.Add(prmCODE);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                conn.Close();
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                result = new Model.LOGO.L_COUNTRY()
                {
                    COUNTRYNR = Int32.Parse(dr["COUNTRYNR"].ToString()),
                    CODE = dr["CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),
                };
            }

            return result;
        }
    }
}

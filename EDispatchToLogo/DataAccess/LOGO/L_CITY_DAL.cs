using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.DataAccess.LOGO
{
    public static class L_CITY_DAL
    {
        public static List<Model.LOGO.L_CITY> GetCityList(int pCountry)
        {
            List<Model.LOGO.L_CITY> result = new List<Model.LOGO.L_CITY>();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.GlobalParam.SqlLogoConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                CTY.LOGICALREF,
	                                CTY.CODE,
	                                CTY.NAME
                                FROM L_CITY (NOLOCK) CTY
                                WHERE CTY.COUNTRY = @COUNTRY
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
                result = dt.AsEnumerable().Select(s => new Model.LOGO.L_CITY
                {
                    LOGICALREF = int.Parse(s["LOGICALREF"].ToString()),
                    CODE = s["CODE"].ToString(),
                    NAME = s["NAME"].ToString()
                }).ToList();
            }

            return result;
        }
    }
}

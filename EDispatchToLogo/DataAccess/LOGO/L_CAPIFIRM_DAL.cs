using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.DataAccess.LOGO
{
    public static class L_CAPIFIRM_DAL
    {
        public static List<Model.LOGO.L_CAPIFIRM> GetFirms()
        {
            List<Model.LOGO.L_CAPIFIRM> result = new List<Model.LOGO.L_CAPIFIRM>();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.GlobalParam.SqlLogoConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT NR, NAME FROM L_CAPIFIRM ORDER BY NR";

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                conn.Close();
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.AsEnumerable().Select(s => new Model.LOGO.L_CAPIFIRM
                {
                    NR = int.Parse(s["NR"].ToString()),
                    NAME = s["NAME"].ToString()
                }).ToList();
            }

            return result;
        }
    }
}

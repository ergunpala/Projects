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
    public static class OTHERSETT_DAL
    {
        public static OTHERSETT Get()
        {
            OTHERSETT result = new OTHERSETT();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                TOP 1 ID,
	                                BRANCHCLCODE
                                FROM OTHERSETT OS (NOLOCK)                                
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
                DataRow dr = dt.Rows[0];

                result = new OTHERSETT()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    BRANCHCLCODE = dr["BRANCHCLCODE"].ToString()                    
                };
            }

            return result;
        }

        public static void Add(OTHERSETT pOtherSett)
        {
            string query = @"INSERT INTO OTHERSETT VALUES(@BRANCHCLCODE)";

            SqlParameter prmBRANCHCLCODE = new SqlParameter("@BRANCHCLCODE", SqlDbType.VarChar, 50);
            prmBRANCHCLCODE.Value = pOtherSett.BRANCHCLCODE;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmBRANCHCLCODE
            };

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;

                    cmd.Parameters.AddRange(sqlParams);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public static void Update(OTHERSETT pOtherSett)
        {
            string query = @"UPDATE OTHERSETT SET BRANCHCLCODE = @BRANCHCLCODE";

            SqlParameter prmBRANCHCLCODE = new SqlParameter("@BRANCHCLCODE", SqlDbType.VarChar, 50);
            prmBRANCHCLCODE.Value = pOtherSett.BRANCHCLCODE;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmBRANCHCLCODE
            };

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;

                    cmd.Parameters.AddRange(sqlParams);

                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public static bool IsExists()
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                TOP 1 ID
                                FROM OTHERSETT OS (NOLOCK)                                
                                ";

                    object oVal = cmd.ExecuteScalar();

                    if (oVal != DBNull.Value && oVal != null && !string.IsNullOrEmpty(oVal.ToString()))
                        result = true;
                }

                conn.Close();
            }

            return result;
        }
    }
}

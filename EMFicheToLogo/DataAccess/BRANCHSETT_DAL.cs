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
    public static class BRANCHSETT_DAL
    {
        public static List<BRANCHSETT> GetList()
        {
            List<BRANCHSETT> result = new List<BRANCHSETT>();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                ID,
	                                BRANCH,
	                                DEBITCODE,
	                                CREDITCODE
                                FROM BRANCHSETT BS (NOLOCK)
                                ORDER BY BS.BRANCH
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
                result = dt.AsEnumerable().Select(s => new BRANCHSETT
                {
                    ID = int.Parse(s["ID"].ToString()),
                    BRANCH = s["BRANCH"].ToString(),
                    DEBITCODE = s["DEBITCODE"].ToString(),
                    CREDITCODE = s["CREDITCODE"].ToString()
                }).ToList();
            }

            return result;
        }

        public static BRANCHSETT Get(int pID)
        {
            BRANCHSETT result = new BRANCHSETT();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                TOP 1 ID,
	                                BRANCH,
	                                DEBITCODE,
	                                CREDITCODE
                                FROM BRANCHSETT BS (NOLOCK)
                                WHERE ID = @ID
                                ";

                    SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int);
                    prmID.Value = pID;

                    cmd.Parameters.Add(prmID);

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

                result = new BRANCHSETT()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    BRANCH = dr["BRANCH"].ToString(),
                    DEBITCODE = dr["DEBITCODE"].ToString(),
                    CREDITCODE = dr["CREDITCODE"].ToString()
                };
            }

            return result;
        }

        public static void Add(BRANCHSETT pBranchSett)
        {
            string query = @"INSERT INTO BRANCHSETT VALUES(@BRANCH, @DEBITCODE, @CREDITCODE)";

            SqlParameter prmBRANCH = new SqlParameter("@BRANCH", SqlDbType.VarChar, 50);
            prmBRANCH.Value = pBranchSett.BRANCH;

            SqlParameter prmDEBITCODE = new SqlParameter("@DEBITCODE", SqlDbType.VarChar, 50);
            prmDEBITCODE.Value = pBranchSett.DEBITCODE;

            SqlParameter prmCREDITCODE = new SqlParameter("@CREDITCODE", SqlDbType.VarChar, 50);
            prmCREDITCODE.Value = pBranchSett.CREDITCODE;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmBRANCH, prmDEBITCODE, prmCREDITCODE
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

        public static void Update(BRANCHSETT pBranchSett)
        {
            string query = @"UPDATE BRANCHSETT SET BRANCH = @BRANCH, DEBITCODE = @DEBITCODE, CREDITCODE = @CREDITCODE WHERE ID = @ID";

            SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int);
            prmID.Value = pBranchSett.ID;

            SqlParameter prmBRANCH = new SqlParameter("@BRANCH", SqlDbType.VarChar, 50);
            prmBRANCH.Value = pBranchSett.BRANCH;

            SqlParameter prmDEBITCODE = new SqlParameter("@DEBITCODE", SqlDbType.VarChar, 50);
            prmDEBITCODE.Value = pBranchSett.DEBITCODE;

            SqlParameter prmCREDITCODE = new SqlParameter("@CREDITCODE", SqlDbType.VarChar, 50);
            prmCREDITCODE.Value = pBranchSett.CREDITCODE;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmID, prmBRANCH, prmDEBITCODE, prmCREDITCODE
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

        public static void Delete(int pID)
        {
            string query = @"DELETE BRANCHSETT WHERE ID = @ID";

            SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int);
            prmID.Value = pID;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmID
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

        public static bool IsExists(BRANCHSETT pBranchSett)
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
                                FROM BRANCHSETT BS (NOLOCK)
                                WHERE BRANCH = @BRANCH
                                    AND ID <> @ID
                                ";

                    SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int);
                    prmID.Value = pBranchSett.ID;

                    SqlParameter prmBRANCH = new SqlParameter("@BRANCH", SqlDbType.VarChar, 50);
                    prmBRANCH.Value = pBranchSett.BRANCH;

                    cmd.Parameters.Add(prmID);
                    cmd.Parameters.Add(prmBRANCH);

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

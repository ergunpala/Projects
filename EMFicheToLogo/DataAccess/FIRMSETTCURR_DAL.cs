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
    public static class FIRMSETTCURR_DAL
    {
        public static void Add(FIRMSETTCURR pFirmSettCurr)
        {
            string query = @"INSERT INTO FIRMSETTCURR VALUES(@FIRMSETTID, @CURRENCY, @CODE)";

            SqlParameter prmFIRMSETTID = new SqlParameter("@FIRMSETTID", SqlDbType.Int);
            prmFIRMSETTID.Value = pFirmSettCurr.FIRMSETTID;

            SqlParameter prmCURRENCY = new SqlParameter("@CURRENCY", SqlDbType.VarChar, 5);
            prmCURRENCY.Value = pFirmSettCurr.CURRENCY;

            SqlParameter prmCODE = new SqlParameter("@CODE", SqlDbType.VarChar, 50);
            prmCODE.Value = pFirmSettCurr.CODE;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmFIRMSETTID, prmCURRENCY, prmCODE
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

        public static void Update(FIRMSETTCURR pFirmSettCurr)
        {
            string query = @"UPDATE FIRMSETTCURR SET CODE = @CODE  WHERE FIRMSETTID = @FIRMSETTID";

            SqlParameter prmFIRMSETTID = new SqlParameter("@FIRMSETTID", SqlDbType.Int);
            prmFIRMSETTID.Value = pFirmSettCurr.FIRMSETTID;

            SqlParameter prmCODE = new SqlParameter("@CODE", SqlDbType.VarChar, 50);
            prmCODE.Value = pFirmSettCurr.CODE;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmFIRMSETTID, prmCODE
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

        public static void Delete(int pFirmSettID)
        {
            string query = @"DELETE FIRMSETTCURR WHERE FIRMSETTID = @FIRMSETTID";

            SqlParameter prmFIRMSETTID = new SqlParameter("@FIRMSETTID", SqlDbType.Int);
            prmFIRMSETTID.Value = pFirmSettID;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmFIRMSETTID
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

        public static bool IsExists(FIRMSETTCURR pFirmSettCurr)
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
                                FROM FIRMSETTCURR FS (NOLOCK)
                                WHERE FIRMSETTID = @FIRMSETTID
                                    AND CURRENCY = @CURRENCY
                                ";

                    SqlParameter prmFIRMSETTID = new SqlParameter("@FIRMSETTID", SqlDbType.Int);
                    prmFIRMSETTID.Value = pFirmSettCurr.FIRMSETTID;

                    SqlParameter prmCURRENCY = new SqlParameter("@CURRENCY", SqlDbType.VarChar, 5);
                    prmCURRENCY.Value = pFirmSettCurr.CURRENCY;

                    SqlParameter[] sqlParams = new SqlParameter[]
                    {
                        prmFIRMSETTID, prmCURRENCY
                    };

                    cmd.Parameters.AddRange(sqlParams);

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

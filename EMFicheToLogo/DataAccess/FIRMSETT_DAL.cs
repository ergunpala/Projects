﻿using EMFicheToLogo.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMFicheToLogo.DataAccess
{
    public static class FIRMSETT_DAL
    {
        public static List<FIRMSETT> GetList()
        {
            List<FIRMSETT> result = new List<FIRMSETT>();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                ID,
	                                FIRM
                                FROM FIRMSETT FS (NOLOCK)
                                ORDER BY FS.FIRM
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
                result = dt.AsEnumerable().Select(s => new FIRMSETT
                {
                    ID = int.Parse(s["ID"].ToString()),
                    FIRM = s["FIRM"].ToString()
                }).ToList();
            }

            return result;
        }

        public static FIRMSETT Get(int pID)
        {
            FIRMSETT result = new FIRMSETT();

            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT
	                                TOP 1 ID,
	                                FIRM
                                FROM FIRMSETT FS (NOLOCK)
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

                result = new FIRMSETT()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    FIRM = dr["FIRM"].ToString()
                };
            }

            return result;
        }

        public static int Add(FIRMSETT pFirmSett)
        {
            int result = 0;

            string query = @"INSERT INTO FIRMSETT VALUES(@FIRM) SELECT SCOPE_IDENTITY();";

            SqlParameter prmFIRM = new SqlParameter("@FIRM", SqlDbType.VarChar, 50);
            prmFIRM.Value = pFirmSett.FIRM;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmFIRM
            };

            using (SqlConnection conn = new SqlConnection(Model.AppClass.SqlConnStr))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;

                    cmd.Parameters.AddRange(sqlParams);

                    object oVal = cmd.ExecuteScalar();

                    if(oVal != null && oVal != DBNull.Value && !string.IsNullOrEmpty(oVal.ToString()))
                    {
                        result = Int32.Parse(oVal.ToString());
                    }
                }

                conn.Close();
            }

            return result;
        }

        public static void Update(FIRMSETT pFirmSett)
        {
            string query = @"UPDATE FIRMSETT SET FIRM = @FIRM WHERE ID = @ID";

            SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int);
            prmID.Value = pFirmSett.ID;

            SqlParameter prmFIRM = new SqlParameter("@FIRM", SqlDbType.VarChar, 50);
            prmFIRM.Value = pFirmSett.FIRM;

            SqlParameter[] sqlParams = new SqlParameter[]
            {
                prmID, prmFIRM
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
            string query = @"DELETE FIRMSETT WHERE ID = @ID";

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

        public static bool IsExists(FIRMSETT pFirmSett)
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
                                FROM FIRMSETT FS (NOLOCK)
                                WHERE FIRM = @FIRM
                                    AND ID <> @ID
                                ";

                    SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int);
                    prmID.Value = pFirmSett.ID;

                    SqlParameter prmFIRM = new SqlParameter("@FIRM", SqlDbType.VarChar, 50);
                    prmFIRM.Value = pFirmSett.FIRM;

                    cmd.Parameters.Add(prmID);
                    cmd.Parameters.Add(prmFIRM);

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

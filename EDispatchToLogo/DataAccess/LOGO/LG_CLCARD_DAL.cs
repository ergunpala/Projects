using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.DataAccess.LOGO
{
    public class LG_CLCARD_DAL
    {
        //public static bool IsExists(string pCode, int pFirmNR, SqlConnection pConn)
        //{
        //    bool result = false;

        //    string query = @"
        //            SELECT
	       //             TOP 1 CL.LOGICALREF
        //            FROM LG_" + pFirmNR.ToString().PadLeft(3, '0') + @"_CLCARD (NOLOCK) CL
        //            WHERE CL.CODE = @CODE 
        //            ";

        //    SqlParameter prmCODE = new SqlParameter("@CODE", System.Data.SqlDbType.VarChar, 16);
        //    prmCODE.Value = pCode;

        //    using (SqlCommand cmd = pConn.CreateCommand())
        //    {
        //        cmd.CommandText = query;
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.Parameters.Add(prmCODE);

        //        object oVal = cmd.ExecuteScalar();

        //        if (oVal != DBNull.Value && oVal != null && !string.IsNullOrEmpty(oVal.ToString()))
        //            result = true;
        //    }

        //    return result;
        //}

        public static string GetClCode(string pCode, int pFirmNR, SqlConnection pConn)
        {
            string result = "";

            try
            {
                string query = @"
                    SELECT
	                    TOP 1 CL.CODE
                    FROM LG_" + pFirmNR.ToString().PadLeft(3, '0') + @"_CLCARD (NOLOCK) CL
                    WHERE CL.CODE LIKE '" + pCode + @".%'
                    ORDER BY CL.CODE DESC
                    ";

                using (SqlCommand cmd = pConn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    object oVal = cmd.ExecuteScalar();                    

                    if (oVal != DBNull.Value && oVal != null && !string.IsNullOrEmpty(oVal.ToString()))
                    {
                        string[] codeArr = oVal.ToString().Split('.');
                        result = string.Format("{0}.{1}", pCode, ((Int32.Parse(codeArr[codeArr.Length - 1]) + 1).ToString().PadLeft(2, '0')));
                    }
                    else
                        result = string.Format("{0}.{1}", pCode, "01");
                }
            }
            catch 
            {
                result = string.Format("{0}.{1}", pCode, "01");

                //DateTime dn = DateTime.Now;

                //result = string.Format("{0}.{1}{2}{3}{4}", pCode, dn.Day.ToString(), dn.Hour.ToString(), dn.Minute.ToString(), dn.Second.ToString());
            }         

            return result;
        }

        public static Model.LOGO.L_CLCARD GetForInvoice(string pCode, int pFirmNR, SqlConnection pConn)
        {
            Model.LOGO.L_CLCARD result = null;

            DataTable dt = new DataTable();

            string tlb = string.Format("LG_{0}_CLCARD", pFirmNR.ToString().PadLeft(3, '0'));

            string query = @"
                    SELECT	                    
                        ISNULL(CL.PROFILEID,0) AS PROFILEID,
                        ISNULL(CL.ACCEPTEINV,0) AS ACCEPTEINV			
                    FROM " + tlb + @" CL
                    WHERE CL.CODE = @CODE
            ";

            SqlParameter prmCode = new SqlParameter("@CODE", SqlDbType.VarChar, 50);
            prmCode.Value = pCode;

            using (SqlCommand cmd = pConn.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Add(prmCode);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            if(dt != null && dt.Rows.Count > 0)
            {
                result = new Model.LOGO.L_CLCARD()
                {
                    PROFILEID = Int32.Parse(dt.Rows[0]["PROFILEID"].ToString()),
                    ACCEPTEINV = Int32.Parse(dt.Rows[0]["ACCEPTEINV"].ToString())
                };
            }

            return result;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.DataAccess.LOGO
{
    public static class LG_ITEMS_DAL
    {
        public static bool IsExists(string pCode, int pFirmNR, SqlConnection pConn)
        {
            bool result = false;

            string query = @"
                    SELECT
	                    TOP 1 ITM.LOGICALREF
                    FROM LG_" + pFirmNR.ToString().PadLeft(3, '0') + @"_ITEMS (NOLOCK) ITM
                    WHERE ITM.CODE = @CODE 
                    ";

            SqlParameter prmCODE = new SqlParameter("@CODE", System.Data.SqlDbType.VarChar, 24);
            prmCODE.Value = pCode;

            using (SqlCommand cmd = pConn.CreateCommand())
            {
                cmd.CommandText = query;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Add(prmCODE);

                object oVal = cmd.ExecuteScalar();

                if (oVal != DBNull.Value && oVal != null && !string.IsNullOrEmpty(oVal.ToString()))
                    result = true;
            }

            return result;
        }
    }
}

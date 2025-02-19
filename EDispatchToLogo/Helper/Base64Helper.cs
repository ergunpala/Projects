using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDispatchToLogo.Helper
{
    public class Base64Helper
    {
        public static string Base64Decode(string pEncodedText)
        {
            var byteText = System.Convert.FromBase64String(pEncodedText);
            return System.Text.Encoding.UTF8.GetString(byteText);
        }
        public static string Base64Encode(byte[] pPlainText)
        {
            return System.Convert.ToBase64String(pPlainText);
        }
    }
}

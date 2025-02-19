using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnityObjects;

namespace EDispatchToLogo.Helper
{
    public static class Common
    {
        public static string OpenExcelFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel File|*.xls;*.xlsx;*.xlsm";
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                if (!ofd.Filter.Equals(string.Empty))
                    return ofd.FileName;
            }
            return "";
        }

        public static void EnablePanelAndWaitingForm(DevExpress.XtraSplashScreen.SplashScreenManager pSmm, Control[] pControl, bool pIsEnable, string pMessage = "")
        {
            EnablePanel(pControl, pIsEnable);
            ShowWaitingPanel(pSmm, pIsEnable, pMessage);
        }

        private static void EnablePanel(Control[] pControl, bool pIsEnable)
        {
            foreach (var control in pControl)
                if (control is DevExpress.XtraEditors.PanelControl)
                    control.Enabled = pIsEnable;
        }

        private static void ShowWaitingPanel(DevExpress.XtraSplashScreen.SplashScreenManager pSmm, bool pIsShow, string pMessage)
        {
            if (!pIsShow && !pSmm.IsSplashFormVisible)
            {
                pSmm.ShowWaitForm();
                pSmm.SetWaitFormDescription(pMessage);
            }
            else if (pSmm.IsSplashFormVisible)
                pSmm.CloseWaitForm();
        }

        public static bool IsLOGOConnect(UnityApplication pMyApp, ref string pErrorStr)
        {
            bool result = true;

            //pMyApp = new UnityApplication();
            pMyApp.Login(Model.GlobalParam.ObjUser, Model.GlobalParam.ObjUserPass, Model.GlobalParam.LogoFirmNR, 0);

            if (!pMyApp.LoggedIn)
            {
                result = false;

                pErrorStr = (pMyApp.GetLastErrorString() ?? "");

                pMyApp.Disconnect();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pMyApp);
                pMyApp = null;
            }

            return result;
        }

        public static void LogoLobjectDisconnect(UnityApplication pMyApp)
        {
            if (pMyApp != null)
            {
                pMyApp.Disconnect();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pMyApp);
                pMyApp = null;
            }
        }

        public static double GetConvertToDouble(object value)
        {
            if (value == null || value == DBNull.Value || string.IsNullOrEmpty(value.ToString()))
                return 0;

            string valueStr = value.ToString().Replace(',', '.').Trim();

            double rVal = 0;

            double.TryParse(valueStr, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("en-US"), out rVal);

            return rVal;
        }
    }
}

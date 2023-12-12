using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BaiCK_QuanLyVatLieuXayDung
{
    static class Program
    {
        internal static DangNhap dangNhap;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dangNhap = new DangNhap();
            Application.Run(dangNhap);

        }
    }
}

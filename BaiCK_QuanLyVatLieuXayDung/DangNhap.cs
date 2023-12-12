using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
namespace BaiCK_QuanLyVatLieuXayDung
{
    public partial class DangNhap : Form
    {
        private const string _employeePath = "nhanvien.xml";
        private readonly XDocument _xDocument = XDocument.Load(_employeePath);
        public DangNhap()
        {
            InitializeComponent();
        }
        private void KiemTraDangNhap(object sender, EventArgs e)
        {
            string username = TB_ten.Text;
            string password = TB_mk.Text;
            XElement xElement = _xDocument.Root.Elements().Where(x => x.Attribute("MaNV").Value.Equals(username) && x.Attribute("MatKhau").Value.Equals(password)).FirstOrDefault();
            if (xElement == null)
                MessageBox.Show("Sai thông tin đăng nhập!");
            else
            {
                MessageBox.Show("Welcome!");
                Session.Username = username;
                new Panel().Show();
                Hide();
            }
        }

        private void cbHienMk_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbHienMk.Checked)
                TB_mk.PasswordChar = char.MinValue;
            else
                TB_mk.PasswordChar = '*';
        }
    }
}

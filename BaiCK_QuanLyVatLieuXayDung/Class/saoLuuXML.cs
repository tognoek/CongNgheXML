using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BaiCK_QuanLyVatLieuXayDung.Class
{
    class saoLuuXML
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TognOek;Initial Catalog=XML_Quanlythietbixaydung;Integrated Security=True");

        public void RestoreData()
        {
            RestoreData("tbNhanVien", "NhanVien", "nhanvien");
            RestoreData("tbDanhMuc", "DanhMuc", "danhmuc");
            RestoreData("tbVatTu", "SanPham", "sanpham");
            RestoreData("tbLichSuTT", "LichSu", "lichsu");
        }
        public void RestoreData(String tableName, String Root, String XMLFile)
        {
            string query = $"SELECT * FROM {tableName} for xml auto";
            try
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = query;
                string xml = command.ExecuteScalar().ToString();
                xml = xml.Replace(tableName, Root);
                xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><" + Root + "List>" + xml + "</" + Root + "List>";
                FileStream xmlFile = File.Open(XMLFile + ".xml", FileMode.Truncate);
                StreamWriter streamWriter = new StreamWriter(xmlFile);
                streamWriter.Write(xml);
                streamWriter.Flush();
                streamWriter.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}

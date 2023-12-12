using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BaiCK_QuanLyVatLieuXayDung.Class
{
    class saoLuuSQL
    {
        SqlConnection conn = new SqlConnection(@"Data Source=TognOek;Initial Catalog=XML_Quanlythietbixaydung;Integrated Security=True");

        public void BackUpData()
        {
            ClearTables();

            BackUpData("nhanvien", "tbNhanVien", "NhanVien");
            BackUpData("danhmuc", "tbDanhMuc", "DanhMuc");
            BackUpData("sanpham", "tbVatTu", "SanPham");
            BackUpData("lichsu", "tbLichSuTT", "LichSu");
        }

        String toString(XElement elm)
        {
            String result = "";
            foreach (XAttribute x in elm.Attributes())
            {
                if (x == elm.LastAttribute)
                    result += "N'" + x.Value + "'";
                else
                {
                    result += "N'" + x.Value + "',";
                }
            }
            return "(" + result + "),\n";
        }

        private void ClearTables()
        {
            conn.Open();
            SqlCommand command;
            string[] tables = { "tbLichSuTT", "tbVatTu", "tbDanhMuc", "tbNhanVien" };

            foreach (var table in tables)
            {
                string query = "DELETE FROM " + table;
                command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void BackUpData(String XMLFileName, String tableNameSql, String nutGoc)
        {
            XDocument XDoc = XDocument.Load(XMLFileName + ".xml");
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                foreach (XElement x in XDoc.Descendants(nutGoc))
                {
                    string query = "INSERT INTO " + tableNameSql + " VALUES" + toString(x);
                    SqlCommand command = new SqlCommand(query.Substring(0, query.Length - 2), conn, transaction);
                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace BaiCK_QuanLyVatLieuXayDung
{
    public partial class LichSuDatHang : Form
    {
        public LichSuDatHang()
        {
            InitializeComponent();
        }
        String pathLichSu = "lichsu.xml";
        XDocument xDocument;
        void TaoHeaderGrid(String header, String width)
        {
            String[] hd = header.Split(',');
            String[] wd = width.Split(',');
            for (int i = 0; i < dgvLichSuDatHang.ColumnCount; i++)
            {
                dgvLichSuDatHang.Columns[i].HeaderText = hd[i];
                dgvLichSuDatHang.Columns[i].Width = int.Parse(wd[i]);
            }
        }
        void KhoiTao()
        {
            xDocument = XDocument.Load(pathLichSu);
            var sinhvien = from XElement e in xDocument.Descendants("LichSu")
                           select new
                           {
                               MaHD = e.Attribute("MaHD").Value,
                               MaNV = e.Attribute("MaNV").Value,
                               ThanhTien = (double)e.Attribute("ThanhTien"),
                               NgayThanhToan = ((DateTime)e.Attribute("NgayThanhToan")).ToString("yyyy-MM-dd"),
                           };
            dgvLichSuDatHang.DataSource = sinhvien.ToList();
            String hd = "Mã HĐ,Mã NV,Tổng tiền,Ngày Thanh Toán";
            String wd = "120, 120, 150, 150";
            TaoHeaderGrid(hd, wd);
        }
        private void LichSuDatHang_Load(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            string Name = "Hoá Đơn";
            int index = dgvLichSuDatHang.SelectedCells[0].RowIndex;
            XElement nhanVienElement = XDocument.Load("nhanvien.xml").Root.Elements().Where(x => x.Attribute("MaNV").Value.Equals(dgvLichSuDatHang.Rows[index].Cells[1].Value)).First();
            StringBuilder stringBuilder = new StringBuilder("<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>" + Name + "</title><style>table,th,tr,td{border:1px solid black;}h1,th,td,p{font-family: 'Segoe UI',Tahoma,Geneva,Verdana,sans-serif;}th,td{padding:5px 50px;text-align:center;}</style></head><body><h1>" + Name + "</h1>");
            double priceTotal = (double)dgvLichSuDatHang.Rows[index].Cells[2].Value;
            stringBuilder.Append($"<p>Mã hóa đơn: {dgvLichSuDatHang.Rows[index].Cells[0].Value}</p>");
            stringBuilder.Append($"<p>Nhân viên thực hiện: {nhanVienElement.Attribute("TenNV").Value}</p>");
            stringBuilder.Append($"<p>Tổng: {priceTotal}</p>");
            stringBuilder.Append($"<p>Ngày Thanh Toán: {dgvLichSuDatHang.Rows[index].Cells[3].Value}</p>");
            stringBuilder.Append("<p>Cám ơn quý khách!</p>");
            stringBuilder.Append("</body></html>");

            Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất HTML";
            saveFileDialog.Filter = "File HTML|*.html";
            saveFileDialog.FileName = "HoaDon.html";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK && (stream = saveFileDialog.OpenFile()) != null)
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(stringBuilder.ToString());
                writer.Flush();
                writer.Close();
                Process.Start("explorer.exe", saveFileDialog.FileName);
            }
        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            XDocument xoa = XDocument.Load(pathLichSu);
            int i = dgvLichSuDatHang.CurrentRow.Index;
            String id = dgvLichSuDatHang.Rows[i].Cells[0].Value.ToString();
            XElement deleteDanhMuc = xoa.Descendants("LichSu").Where(c => c.Attribute("MaHD").Value.Equals(id)).FirstOrDefault();
            if (deleteDanhMuc != null)
            {
                deleteDanhMuc.Remove();
                xoa.Save(pathLichSu);
            }
            LichSuDatHang_Load(sender, e);
        }

    }
}

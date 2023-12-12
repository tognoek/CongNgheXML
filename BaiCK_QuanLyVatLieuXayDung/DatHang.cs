using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BaiCK_QuanLyVatLieuXayDung
{
    public partial class DatHang : Form
    {
        private readonly List<GioHang> gioHangs = new List<GioHang>();
        public DatHang()
        {
            InitializeComponent();
            txtNhanVienThucHien.Text = Session.Username;
        }
        String pathSanPham = "sanpham.xml";
        String pathLichSu = "lichsu.xml";
        XDocument xDocument;
        void TaoHeaderGrid(String header, String width)
        {
            String[] hd = header.Split(',');
            String[] wd = width.Split(',');
            for (int i = 0; i < dgvVatTudh.ColumnCount; i++)
            {
                dgvVatTudh.Columns[i].HeaderText = hd[i];
                dgvVatTudh.Columns[i].Width = int.Parse(wd[i]);
            }
        }
        void TaoHeaderGridTwo()
        {

            String header = "Mã SP,Tên SP,Số lượng,Giá cả";
            String width = "70, 120, 100, 100,";
            String[] hd = header.Split(',');
            String[] wd = width.Split(',');
            for (int i = 0; i < dgvHoaDon.ColumnCount; i++)
            {
                dgvHoaDon.Columns[i].HeaderText = hd[i];
                dgvHoaDon.Columns[i].Width = int.Parse(wd[i]);
            }
        }
        void KhoiTao()
        {
            xDocument = XDocument.Load(pathSanPham);
            var sinhvien = from XElement e in xDocument.Descendants("SanPham")
                           select new
                           {
                               MaSP = e.Attribute("MaSP").Value,
                               TenSP = e.Attribute("TenSP").Value,
                               NgaySX = ((DateTime)e.Attribute("NgaySX")).ToString("dd/MM/yyyy"),
                               SoLuong = e.Attribute("SoLg").Value,
                               GiaCa = (double)e.Attribute("GiaCa"),
                               MaDM = e.Attribute("MaDM").Value
                           };
            dgvVatTudh.DataSource = sinhvien.ToList();
            String hd = "Mã SP,Tên SP,Ngày SX,Số lượng,Giá cả,Mã DM";
            String wd = "100, 120, 150, 120, 120, 100";
            TaoHeaderGrid(hd, wd);
        }


        private void DatHang_Load(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void dgvVatTudh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvVatTudh.SelectedCells[0].RowIndex;
            textBox2.Text = dgvVatTudh.Rows[index].Cells[1].Value.ToString();
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            int index = dgvVatTudh.SelectedCells[0].RowIndex;
            string maSP = dgvVatTudh.Rows[index].Cells[0].Value.ToString();
            string tenSP = dgvVatTudh.Rows[index].Cells[1].Value.ToString();
            int soLuong = int.Parse(textBox1.Text);
            double giaCa = (double)dgvVatTudh.Rows[index].Cells[4].Value;
            GioHang gioHang = new GioHang(maSP, tenSP, soLuong, giaCa);
            gioHangs.Add(gioHang);
            dgvHoaDon.DataSource = null;
            dgvHoaDon.DataSource = gioHangs;
            TaoHeaderGridTwo();
            TongTienLabel.Text = gioHangs.Sum(hd => hd.SoLuong * hd.GiaCa) + " VND";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            XDocument themMoi = XDocument.Load(pathLichSu);
            XElement lastItem = themMoi.Descendants("LichSu").LastOrDefault();
            XElement newNhanVien = new XElement("LichSu",
            new XAttribute("MaHD", MaHoaDonTextBox.Text),
            new XAttribute("MaNV", txtNhanVienThucHien.Text),
            new XAttribute("ThanhTien", TongTienLabel.Text.Substring(0, TongTienLabel.Text.Length - 4)),
            new XAttribute("NgayThanhToan", DateTime.Now.ToString("yyyy-MM-dd")));
            themMoi.Element("LichSuList").Add(newNhanVien);
            themMoi.Save(pathLichSu);
            MessageBox.Show("Thanh toán thành công");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string id = txtMaSPTK.Text;
            for (int i = 0; i < dgvVatTudh.Rows.Count; ++i)
                if (dgvVatTudh.Rows[i].Cells[0].Value.ToString().Equals(id))
                {
                    dgvVatTudh.CurrentCell.Selected = false;
                    dgvVatTudh.Rows[i].Selected = true;
                    dgvVatTudh.Rows[i].Cells[0].Selected = true;
                    return;
                }
            MessageBox.Show(this, "Không tìm thấy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            int index = dgvHoaDon.SelectedCells[0].RowIndex;
            gioHangs.RemoveAt(index);
            dgvHoaDon.DataSource = null;
            dgvHoaDon.DataSource = gioHangs;
            TaoHeaderGridTwo();
            TongTienLabel.Text = gioHangs.Sum(hd => hd.SoLuong * hd.GiaCa) + " VND";
        }

    }

    public class GioHang
    {
        public string MaSP { get; }
        public string TenSP { get; }
        public int SoLuong { get; }
        public double GiaCa { get; }

        public GioHang(string maSP, string tenSP, int soLuong, double giaCa)
        {
            MaSP = maSP;
            TenSP = tenSP;
            SoLuong = soLuong;
            GiaCa = giaCa;
        }
        public override string ToString() => MaSP;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
namespace BaiCK_QuanLyVatLieuXayDung
{
    public partial class QuanLyNhanVien : Form
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        public class GioiTinhCb
        {
            public string ID { get; set; }
            public string Ten { get; set; }

            public override string ToString()
            {
                return Ten;
            }
        }
        String pathNhanVien = "nhanvien.xml";
        XDocument xDocument;

        void TaoHeaderGrid(String header, String width)
        {
            String[] hd = header.Split(',');
            String[] wd = width.Split(',');
            for (int i = 0; i < dgvNhanVien.ColumnCount; i++)
            {
                dgvNhanVien.Columns[i].HeaderText = hd[i];
                dgvNhanVien.Columns[i].Width = int.Parse(wd[i]);
            }
        }
        void KhoiTao()
        {
            xDocument = XDocument.Load(pathNhanVien);
            var sinhvien = from XElement e in xDocument.Descendants("NhanVien")
                           select new
                           {
                               MaNV = e.Attribute("MaNV").Value,
                               HoTen = e.Attribute("TenNV").Value,
                               DiaChi = e.Attribute("DiaChi").Value,
                               SoDienThoai = e.Attribute("SDT").Value,
                               Email = e.Attribute("Email").Value,
                               GioiTinh = e.Attribute("GioiTinh").Value,
                               MatKhau = e.Attribute("MatKhau").Value
                           };
            dgvNhanVien.DataSource = sinhvien.ToList();
            String hd = "Mã NV,Họ và Tên,Địa chỉ,Số Điện Thoại,Email,Giới Tính,Mật Khẩu";
            String wd = "90,140,130,130,120,120,100";
            TaoHeaderGrid(hd, wd);
        }
        private void Format(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                int gioiTinhValue = int.Parse(e.Value.ToString());
                e.Value = gioiTinhValue == 0 ? "Nam" : "Nữ";
                e.FormattingApplied = true;
            }
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e) => CellClick(sender, e, null);

        private void CellClick(object sender, DataGridViewCellEventArgs e, int? index = null)
        {
            int i = index ?? dgvNhanVien.CurrentRow.Index;
            txtMaNV.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            txtEmail.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            cbGioiTinh.SelectedValue = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
            txtMatKhau.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

                XDocument themMoi = XDocument.Load(pathNhanVien);
                XElement lastItem = themMoi.Descendants("NhanVien").LastOrDefault();
                XElement newNhanVien = new XElement("NhanVien",
                new XAttribute("MaNV", txtMaNV.Text),
                new XAttribute("TenNV", txtTenNV.Text),
                new XAttribute("DiaChi", txtDiaChi.Text),
                new XAttribute("SDT", txtSDT.Text),
                new XAttribute("Email", txtEmail.Text),
                new XAttribute("GioiTinh", cbGioiTinh.SelectedValue.ToString()),
                new XAttribute("MatKhau", txtMatKhau.Text)
                );
                themMoi.Element("NhanVienList").Add(newNhanVien);
                themMoi.Save(pathNhanVien);
                QuanLyNhanVien_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            XDocument sua = XDocument.Load(pathNhanVien);
            int i = dgvNhanVien.CurrentRow.Index;
            String id = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            XElement updayeSinhVien = sua.Descendants("NhanVien").Where(c => c.Attribute("MaNV").Value.Equals(id)).FirstOrDefault();
            updayeSinhVien.Attribute("TenNV").Value = txtTenNV.Text;
            updayeSinhVien.Attribute("DiaChi").Value = txtDiaChi.Text;
            updayeSinhVien.Attribute("SDT").Value = txtSDT.Text;
            updayeSinhVien.Attribute("Email").Value = txtEmail.Text;
            updayeSinhVien.Attribute("GioiTinh").Value = cbGioiTinh.SelectedValue.ToString();
            updayeSinhVien.Attribute("MatKhau").Value = txtMatKhau.Text;
            sua.Save(pathNhanVien);
            QuanLyNhanVien_Load(sender, e);

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XDocument xoa = XDocument.Load(pathNhanVien);
            int i = dgvNhanVien.CurrentRow.Index;
            String id = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            XElement deleteSinhVien = xoa.Descendants("NhanVien").Where(c => c.Attribute("MaNV").Value.Equals(id)).FirstOrDefault();
            if (deleteSinhVien != null)
            {
                deleteSinhVien.Remove();
                xoa.Save(pathNhanVien);
            }
            QuanLyNhanVien_Load(sender, e);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            cbGioiTinh.SelectedValue = "0";
            txtMatKhau.Text = "";
            txtFind.Text = "";
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            List<GioiTinhCb> danhSachGt = new List<GioiTinhCb>
            {
                new GioiTinhCb { ID = "0", Ten = "Nam" },
                new GioiTinhCb { ID = "1", Ten = "Nữ" }
            };

            cbGioiTinh.DisplayMember = "Ten";
            cbGioiTinh.ValueMember = "ID";
            cbGioiTinh.DataSource = danhSachGt;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            cbGioiTinh.SelectedValue = "0";
            txtMatKhau.Text = "";
            KhoiTao();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string id = txtFind.Text;
            for (int i = 0; i < dgvNhanVien.Rows.Count; ++i)
                if (dgvNhanVien.Rows[i].Cells[0].Value.ToString().Equals(id))
                {
                    dgvNhanVien.CurrentCell.Selected = false;
                    dgvNhanVien.Rows[i].Selected = true;
                    dgvNhanVien.Rows[i].Cells[0].Selected = true;
                    CellClick(null, null, i);
                    return;
                }
            MessageBox.Show(this, "Không tìm thấy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
    }
}
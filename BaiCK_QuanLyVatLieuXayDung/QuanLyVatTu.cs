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
using System.Xml.Linq;

namespace BaiCK_QuanLyVatLieuXayDung
{
    public partial class QuanLyVatTu : Form
    {
        public QuanLyVatTu()
        {
            InitializeComponent();
            
        }

        public class DanhMucCb
        {
            public string ID { get; set; }
            public string Ten { get; set; }

            public override string ToString()
            {
                return Ten;
            }
        }
        String pathSanPham = "sanpham.xml";
        String pathDanhMuc = "danhmuc.xml";
        XDocument xDocument;
        void TaoHeaderGrid(String header, String width)
        {
            String[] hd = header.Split(',');
            String[] wd = width.Split(',');
            for (int i = 0; i < dgvVatTu.ColumnCount; i++)
            {
                dgvVatTu.Columns[i].HeaderText = hd[i];
                dgvVatTu.Columns[i].Width = int.Parse(wd[i]);
            }
            CB1.Items.Clear();
            CB2.Items.Clear();
            CB1.Items.AddRange(hd);
            CB2.Items.AddRange(hd);
            CB1.SelectedIndex = 0;
            CB2.SelectedIndex = 0;
        }
        void KhoiTao()
        {
            xDocument = XDocument.Load(pathSanPham);
            var sinhvien = from XElement e in xDocument.Descendants("SanPham")
                           select new
                           {
                               MaSP = e.Attribute("MaSP").Value,
                               TenSP = e.Attribute("TenSP").Value,
                               NgaySX = ((DateTime) e.Attribute("NgaySX")).ToString("dd/MM/yyyy"),
                               SoLuong = e.Attribute("SoLg").Value,
                               GiaCa = e.Attribute("GiaCa").Value,
                               MaDM = e.Attribute("MaDM").Value
                           };
            dgvVatTu.DataSource = sinhvien.ToList();
            String hd = "Mã SP,Tên SP,Ngày SX,Số lượng,Giá cả,Tên DM";
            String wd = "100, 120, 150, 120, 120, 100";
            TaoHeaderGrid(hd, wd);
        }

        private void Format(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null)
            {
                xDocument = XDocument.Load(pathDanhMuc);
                XElement elm = xDocument.Descendants("DanhMuc").Where(c => c.Attribute("MaDM").Value.Equals(e.Value.ToString())).FirstOrDefault();
                e.Value = elm.Attribute("TenDM").Value.ToString();
                e.FormattingApplied = true;
            }

        }

        private void CellClick(object sender, DataGridViewCellEventArgs e) => CellClick(sender, e, null);

        private void CellClick(object sender, DataGridViewCellEventArgs e, int? index = null)
        {
            int i = index ?? dgvVatTu.CurrentRow.Index;
            txtMaSP.Text = dgvVatTu.Rows[i].Cells[0].Value.ToString();
            txtTenSP.Text = dgvVatTu.Rows[i].Cells[1].Value.ToString();
            dateNgaySX.Text = dgvVatTu.Rows[i].Cells[2].Value.ToString();
            txtSoLuong.Text = dgvVatTu.Rows[i].Cells[3].Value.ToString();
            txtGiaCa.Text = dgvVatTu.Rows[i].Cells[4].Value.ToString();
            cbDanhMuc.SelectedValue = dgvVatTu.Rows[i].Cells[5].Value.ToString();
        }

       
        private void QuanLyVatTu_Load(object sender, EventArgs e)
        {
            List<DanhMucCb> danhSach = new List<DanhMucCb>();
            xDocument = XDocument.Load(pathDanhMuc);
            var danhmucElements = xDocument.Descendants("DanhMuc");

            foreach (var danhmucElement in danhmucElements)
            {
                DanhMucCb danhmuc = new DanhMucCb
                {
                    ID = danhmucElement.Attribute("MaDM").Value,
                    Ten = danhmucElement.Attribute("TenDM").Value
                };

                danhSach.Add(danhmuc);
            }
            cbDanhMuc.DisplayMember = "Ten";
            cbDanhMuc.ValueMember = "ID";
            cbDanhMuc.DataSource = danhSach;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dateNgaySX.Text = "";
            txtSoLuong.Text = "";
            txtGiaCa.Text = "";
            cbDanhMuc.SelectedValue = "0";
            KhoiTao();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XDocument themMoi = XDocument.Load(pathSanPham);
            XElement lastItem = themMoi.Descendants("SanPham").LastOrDefault();
            XElement newSanPham = new XElement("SanPham",
                new XAttribute("MaSP", txtMaSP.Text),
                new XAttribute("TenSP", txtTenSP.Text),
                new XAttribute("NgaySX", dateNgaySX.Value),
                new XAttribute("SoLg", txtSoLuong.Text),
                new XAttribute("GiaCa", txtGiaCa.Text),
                new XAttribute("MaDM", cbDanhMuc.SelectedValue.ToString()));
            themMoi.Element("SanPhamList").Add(newSanPham);
            themMoi.Save(pathSanPham);
            QuanLyVatTu_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XDocument sua = XDocument.Load(pathSanPham);
            int i = dgvVatTu.CurrentRow.Index;
            String id = dgvVatTu.Rows[i].Cells[0].Value.ToString();
            XElement updayeSinhVien = sua.Descendants("SanPham").Where(c => c.Attribute("MaSP").Value.Equals(id)).FirstOrDefault();
            updayeSinhVien.Attribute("TenSP").Value = txtTenSP.Text;
            updayeSinhVien.SetAttributeValue("NgaySX", dateNgaySX.Value);
            updayeSinhVien.Attribute("SoLg").Value = txtSoLuong.Text;
            updayeSinhVien.Attribute("GiaCa").Value = txtGiaCa.Text;
            updayeSinhVien.Attribute("MaDM").Value = cbDanhMuc.SelectedValue.ToString();
            sua.Save(pathSanPham);
            QuanLyVatTu_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XDocument xoa = XDocument.Load(pathSanPham);
            int i = dgvVatTu.CurrentRow.Index;
            String id = dgvVatTu.Rows[i].Cells[0].Value.ToString();
            XElement deleteSinhVien = xoa.Descendants("SanPham").Where(c => c.Attribute("MaSP").Value.Equals(id)).FirstOrDefault();
            if (deleteSinhVien != null)
            {
                deleteSinhVien.Remove();
                xoa.Save(pathSanPham);
            }
            QuanLyVatTu_Load(sender, e);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dateNgaySX.Text = "";
            txtSoLuong.Text = "";
            txtGiaCa.Text = "";
            cbDanhMuc.SelectedValue = "0";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int comboBoxIndex1 = CB1.SelectedIndex, comboBoxIndex2 = CB2.SelectedIndex;
            for (int i = 0; i < dgvVatTu.SelectedCells.Count; ++i)
                dgvVatTu.SelectedCells[i].Selected = false;
            for (int i = 0; i < dgvVatTu.SelectedRows.Count; ++i)
                dgvVatTu.SelectedRows[i].Selected = false;

            for (int i = 0; i < dgvVatTu.Rows.Count; ++i)
            {
                string searchValue1 = dgvVatTu.Rows[i].Cells[comboBoxIndex1].Value.ToString(),
                    searchValue2 = dgvVatTu.Rows[i].Cells[comboBoxIndex2].Value.ToString();
                if ((RBT1.Checked && (searchValue1.Equals(TB1.Text) || searchValue2.Equals(TB2.Text))) || (searchValue1.Equals(TB1.Text) && searchValue2.Equals(TB2.Text)))
                    dgvVatTu.Rows[i].Cells[0].Selected = true;
            }
        }
    }
}

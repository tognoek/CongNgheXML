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
    public partial class DanhMucThietBi : Form
    {
        public DanhMucThietBi()
        {
            InitializeComponent();
        }

        String pathDanhMuc = "danhmuc.xml";
        XDocument xDocument;
        void TaoHeaderGrid(String header, String width)
        {
            String[] hd = header.Split(',');
            String[] wd = width.Split(',');
            for (int i = 0; i < dgvDanhMuc.ColumnCount; i++)
            {
                dgvDanhMuc.Columns[i].HeaderText = hd[i];
                dgvDanhMuc.Columns[i].Width = int.Parse(wd[i]);
            }
        }
        void KhoiTao()
        {
            xDocument = XDocument.Load(pathDanhMuc);
            var DanhMuc = from XElement e in xDocument.Descendants("DanhMuc")
                        select new
                        {
                            MaDM = e.Attribute("MaDM")?.Value,
                            TenDM = e.Attribute("TenDM")?.Value
                        };
            dgvDanhMuc.DataSource = DanhMuc.ToList();
            String hd = "Mã Danh Mục,Tên Danh Mục";
            String wd = "150,215";
            TaoHeaderGrid(hd, wd);
        }

        private void dataGridView_phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvDanhMuc.CurrentRow.Index;
            txtMaDanhMuc.Text = dgvDanhMuc.Rows[i].Cells[0].Value.ToString();
            txtTenDanhMuc.Text = dgvDanhMuc.Rows[i].Cells[1].Value.ToString();
        }

        private void DanhMucThietBi_Load(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            XDocument themMoi = XDocument.Load(pathDanhMuc);
            XElement lastItem = themMoi.Descendants("DanhMuc").LastOrDefault();
            XElement newDanhMuc = new XElement("DanhMuc",
                new XAttribute("MaDM", txtMaDanhMuc.Text),
                new XAttribute("TenDM", txtTenDanhMuc.Text));
            themMoi.Element("DanhMucList").Add(newDanhMuc);
            themMoi.Save(pathDanhMuc);
            DanhMucThietBi_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            XDocument sua = XDocument.Load(pathDanhMuc);
            int i = dgvDanhMuc.CurrentRow.Index;
            String id = dgvDanhMuc.Rows[i].Cells[0].Value.ToString();
            XElement updatePhong = sua.Descendants("DanhMuc").Where(c => c.Attribute("MaDM").Value.Equals(id)).FirstOrDefault();
            updatePhong.Attribute("MaDM").Value = txtMaDanhMuc.Text;
            updatePhong.Attribute("TenDM").Value = txtTenDanhMuc.Text;
            sua.Save(pathDanhMuc);
            DanhMucThietBi_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XDocument xoa = XDocument.Load(pathDanhMuc);
            int i = dgvDanhMuc.CurrentRow.Index;
            String id = dgvDanhMuc.Rows[i].Cells[0].Value.ToString();
            XElement deleteDanhMuc = xoa.Descendants("DanhMuc").Where(c => c.Attribute("MaDM").Value.Equals(id)).FirstOrDefault();
            if (deleteDanhMuc != null)
            {
                deleteDanhMuc.Remove();
                xoa.Save(pathDanhMuc);
            }
            txtMaDanhMuc.Text = "";
            txtTenDanhMuc.Text = "";
            DanhMucThietBi_Load(sender, e);
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txtMaDanhMuc.Text = "";
            txtTenDanhMuc.Text = "";
        }
    }
}

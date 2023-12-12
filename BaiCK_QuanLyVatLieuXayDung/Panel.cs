using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiCK_QuanLyVatLieuXayDung
{
    public partial class Panel : Form
    {
        private Form currentFormChild;
        private static readonly EventHandler s_closeForm = (sender, e) => Application.Exit();

        private void OpenChildForm(Form ChildForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Dispose();
            }
            currentFormChild = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            pnlBody.Controls.Add(ChildForm);
            pnlBody.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            Disposed += s_closeForm;
        }

        public Panel()
        {
            InitializeComponent();
            btnTrangChu_Click(null, null);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TrangChu());
            lblTitle.Text = btnTrangChu.Text;
            lblTitle.Location = new Point((pnlTitle.Width - lblTitle.Width) / 2, (pnlTitle.Height - lblTitle.Height) / 2);
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyNhanVien());
            lblTitle.Text = btnQLNV.Text;
            lblTitle.Location = new Point((pnlTitle.Width - lblTitle.Width) / 2, (pnlTitle.Height - lblTitle.Height) / 2);
        }

        private void btnQLVT_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QuanLyVatTu());
            lblTitle.Text = btnQLVT.Text;
            lblTitle.Location = new Point((pnlTitle.Width - lblTitle.Width) / 2, (pnlTitle.Height - lblTitle.Height) / 2);
        }

        private void btnDanhMucVT_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DanhMucThietBi());
            lblTitle.Text = btnDanhMucVT.Text;
            lblTitle.Location = new Point((pnlTitle.Width - lblTitle.Width) / 2, (pnlTitle.Height - lblTitle.Height) / 2);
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DatHang());
            lblTitle.Text = btnDatHang.Text;
            lblTitle.Location = new Point((pnlTitle.Width - lblTitle.Width) / 2, (pnlTitle.Height - lblTitle.Height) / 2);
        }

        private void btnLichSuDH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichSuDatHang());
            lblTitle.Text = btnLichSuDH.Text;
            lblTitle.Location = new Point((pnlTitle.Width - lblTitle.Width) / 2, (pnlTitle.Height - lblTitle.Height) / 2);
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SaoLuu());
            lblTitle.Text = btnSaoLuu.Text;
            lblTitle.Location = new Point((pnlTitle.Width - lblTitle.Width) / 2, (pnlTitle.Height - lblTitle.Height) / 2);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Disposed -= s_closeForm;
            Dispose();
            Program.dangNhap.Show();
        }
    }
}

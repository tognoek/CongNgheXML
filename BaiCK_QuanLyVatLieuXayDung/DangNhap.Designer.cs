
namespace BaiCK_QuanLyVatLieuXayDung
{
    partial class DangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbHienMk = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TB_mk = new System.Windows.Forms.TextBox();
            this.TB_ten = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbHienMk
            // 
            this.cbHienMk.AutoSize = true;
            this.cbHienMk.BackColor = System.Drawing.SystemColors.Control;
            this.cbHienMk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHienMk.Location = new System.Drawing.Point(319, 248);
            this.cbHienMk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbHienMk.Name = "cbHienMk";
            this.cbHienMk.Size = new System.Drawing.Size(125, 22);
            this.cbHienMk.TabIndex = 17;
            this.cbHienMk.Text = "Hiện mật khẩu";
            this.cbHienMk.UseVisualStyleBackColor = false;
            this.cbHienMk.CheckedChanged += new System.EventHandler(this.cbHienMk_CheckedChanged_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(254, 286);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 36);
            this.button1.TabIndex = 16;
            this.button1.Text = "Đăng nhập";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.KiemTraDangNhap);
            // 
            // TB_mk
            // 
            this.TB_mk.Location = new System.Drawing.Point(319, 204);
            this.TB_mk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_mk.Name = "TB_mk";
            this.TB_mk.PasswordChar = '*';
            this.TB_mk.Size = new System.Drawing.Size(141, 22);
            this.TB_mk.TabIndex = 15;
            // 
            // TB_ten
            // 
            this.TB_ten.Location = new System.Drawing.Point(319, 148);
            this.TB_ten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_ten.Name = "TB_ten";
            this.TB_ten.Size = new System.Drawing.Size(141, 22);
            this.TB_ten.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LavenderBlush;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(195, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LavenderBlush;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(153, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(292, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đăng nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(126, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(525, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "PHẦN MỀM QUẢN LÝ VẬT LIỆU XÂY DỰNG";
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BaiCK_QuanLyVatLieuXayDung.Properties.Resources.bgrDangNhap;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 387);
            this.Controls.Add(this.cbHienMk);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TB_mk);
            this.Controls.Add(this.TB_ten);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DangNhap";
            this.Text = "DangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbHienMk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TB_mk;
        private System.Windows.Forms.TextBox TB_ten;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
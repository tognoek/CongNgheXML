
namespace BaiCK_QuanLyVatLieuXayDung
{
    partial class SaoLuu
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
            this.btnSQLtoXML = new System.Windows.Forms.Button();
            this.btnXMLtoSQL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSQLtoXML
            // 
            this.btnSQLtoXML.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSQLtoXML.Location = new System.Drawing.Point(268, 178);
            this.btnSQLtoXML.Name = "btnSQLtoXML";
            this.btnSQLtoXML.Size = new System.Drawing.Size(448, 74);
            this.btnSQLtoXML.TabIndex = 2;
            this.btnSQLtoXML.Text = "Khôi phục dữ liệu SQL → XML";
            this.btnSQLtoXML.UseVisualStyleBackColor = true;
            this.btnSQLtoXML.Click += new System.EventHandler(this.btnSQLtoXML_Click);
            // 
            // btnXMLtoSQL
            // 
            this.btnXMLtoSQL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXMLtoSQL.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXMLtoSQL.Location = new System.Drawing.Point(268, 56);
            this.btnXMLtoSQL.Name = "btnXMLtoSQL";
            this.btnXMLtoSQL.Size = new System.Drawing.Size(448, 74);
            this.btnXMLtoSQL.TabIndex = 3;
            this.btnXMLtoSQL.Text = "Chuyển dữ liệu từ XML → SQL";
            this.btnXMLtoSQL.UseVisualStyleBackColor = true;
            this.btnXMLtoSQL.Click += new System.EventHandler(this.btnXMLtoSQL_Click);
            // 
            // SaoLuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(964, 451);
            this.Controls.Add(this.btnSQLtoXML);
            this.Controls.Add(this.btnXMLtoSQL);
            this.Name = "SaoLuu";
            this.Text = "SaoLuu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSQLtoXML;
        private System.Windows.Forms.Button btnXMLtoSQL;
    }
}
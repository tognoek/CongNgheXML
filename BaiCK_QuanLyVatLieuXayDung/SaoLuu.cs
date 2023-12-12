using BaiCK_QuanLyVatLieuXayDung.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace BaiCK_QuanLyVatLieuXayDung
{
    public partial class SaoLuu : Form
    {
        public SaoLuu()
        {
            InitializeComponent();
        }

        private void btnXMLtoSQL_Click(object sender, EventArgs e)
        {
            saoLuuSQL sl1 = new saoLuuSQL();
            sl1.BackUpData();
            Tao();
            MessageBox.Show("Sao lưu dữ liệu thành công!");
        }

        private void btnSQLtoXML_Click(object sender, EventArgs e)
        {
            saoLuuXML sl2 = new saoLuuXML();
            sl2.RestoreData();
            Tao();
            MessageBox.Show("Sao lưu dữ liệu thành công!");
        }

        private void Tao()
        {
            String[] name = { "danhmuc", "nhanvien", "lichsu", "sanpham" };
            for (int i = 0; i < 4; i++)
            {

                String xsltFilePath = name[i] + ".xslt";
                String xmlFilePath = name[i] + ".xml";
                String outputFilePath = name[i] + ".html";
                TransformXmlWithXslt(xmlFilePath, xsltFilePath, outputFilePath);
            }
        }

        private void TransformXmlWithXslt(string xmlFilePath, string xsltFilePath, string outputFilePath)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();

            xslt.Load(xsltFilePath);

            using (XmlReader xmlReader = XmlReader.Create(xmlFilePath))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(outputFilePath))
                {
                    xslt.Transform(xmlReader, null, xmlWriter);
                }
            }
        }
    }
}

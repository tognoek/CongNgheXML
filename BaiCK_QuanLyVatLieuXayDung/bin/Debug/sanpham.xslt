<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/SanPhamList">
        <html>
            <head>
                <title>Thông Tin Sản Phẩm</title>
                <style>
                    table {
                        width: 100%;
                        border-collapse: collapse;
                        margin-top: 20px;
                    }
                    th, td {
                        border: 1px solid #dddddd;
                        text-align: left;
                        padding: 8px;
                    }
                    th {
                        background-color: #f2f2f2;
                    }
                </style>
            </head>
            <body>
                <h2>Thông Tin Sản Phẩm</h2>
                <table>
                    <tr>
                        <th>Mã Sản Phẩm</th>
                        <th>Tên Sản Phẩm</th>
                        <th>Ngày Sản Xuất</th>
                        <th>Số Lượng</th>
                        <th>Giá Cả</th>
                        <th>Mã Danh Mục</th>
                    </tr>
                    <xsl:apply-templates select="SanPham"/>
                </table>
            </body>
        </html>
    </xsl:template>

    <xsl:template match="SanPham">
        <tr>
            <td><xsl:value-of select="@MaSP"/></td>
            <td><xsl:value-of select="@TenSP"/></td>
            <td><xsl:value-of select="@NgaySX"/></td>
            <td><xsl:value-of select="@SoLg"/></td>
            <td><xsl:value-of select="@GiaCa"/></td>
            <td><xsl:value-of select="@MaDM"/></td>
        </tr>
    </xsl:template>

</xsl:stylesheet>

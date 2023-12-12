<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/LichSuList">
        <html>
            <head>
                <title>Lịch Sử Giao Dịch</title>
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
                <h2>Lịch Sử Giao Dịch</h2>
                <table>
                    <tr>
                        <th>Mã Hóa Đơn</th>
                        <th>Mã Nhân Viên</th>
                        <th>Thành Tiền</th>
                        <th>Ngày Thanh Toán</th>
                    </tr>
                    <xsl:apply-templates select="LichSu"/>
                </table>
            </body>
        </html>
    </xsl:template>

    <xsl:template match="LichSu">
        <tr>
            <td><xsl:value-of select="@MaHD"/></td>
            <td><xsl:value-of select="@MaNV"/></td>
            <td><xsl:value-of select="@ThanhTien"/></td>
            <td><xsl:value-of select="@NgayThanhToan"/></td>
        </tr>
    </xsl:template>

</xsl:stylesheet>

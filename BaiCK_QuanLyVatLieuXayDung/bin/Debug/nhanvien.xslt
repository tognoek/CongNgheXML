<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/NhanVienList">
        <html>
            <head>
                <title>Thông Tin Nhân Viên</title>
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
                <h2>Thông Tin Nhân Viên</h2>
                <table>
                    <tr>
                        <th>Mã Nhân Viên</th>
                        <th>Tên Nhân Viên</th>
                        <th>Địa Chỉ</th>
                        <th>Số Điện Thoại</th>
                        <th>Email</th>
                        <th>Giới Tính</th>
                        <th>Mật Khẩu</th>
                    </tr>
                    <xsl:apply-templates select="NhanVien"/>
                </table>
            </body>
        </html>
    </xsl:template>

    <xsl:template match="NhanVien">
        <tr>
            <td><xsl:value-of select="@MaNV"/></td>
            <td><xsl:value-of select="@TenNV"/></td>
            <td><xsl:value-of select="@DiaChi"/></td>
            <td><xsl:value-of select="@SDT"/></td>
            <td><xsl:value-of select="@Email"/></td>
            <td>
                <xsl:choose>
                    <xsl:when test="@GioiTinh = '1'">Nam</xsl:when>
                    <xsl:otherwise>Nữ</xsl:otherwise>
                </xsl:choose>
            </td>
            <td><xsl:value-of select="@MatKhau"/></td>
        </tr>
    </xsl:template>

</xsl:stylesheet>

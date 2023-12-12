<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/DanhMucList">
        <html>
            <head>
                <title>Danh Mục</title>
            </head>
            <body>
                <h2>Danh Mục</h2>
                <table border="1">
                    <tr>
                        <th>Mã Danh Mục</th>
                        <th>Tên Danh Mục</th>
                    </tr>
                    <xsl:apply-templates select="DanhMuc"/>
                </table>
            </body>
        </html>
    </xsl:template>

    <xsl:template match="DanhMuc">
        <tr>
            <td><xsl:value-of select="@MaDM"/></td>
            <td><xsl:value-of select="@TenDM"/></td>
        </tr>
    </xsl:template>

</xsl:stylesheet>

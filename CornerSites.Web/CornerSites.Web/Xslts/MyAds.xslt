<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="NewDataSet">
      <div>
        <xsl:for-each select="Table">
        <div style="padding-bottom:10px">
          <table>
            <tr>
              <td>
                AdHeader : 
              </td>
              <td>
                <xsl:value-of select ="AdHeader"/>
              </td>
            </tr>
            <tr>
              <td>
                PropertyType : 
              </td>
              <td>
                <xsl:value-of select ="PropertyType"/>
              </td>
            </tr>
            <tr>
              <td>
                AdExpiryDate : 
              </td>
              <td>
                <xsl:value-of select ="AdExpiryDate"/>
              </td>
            </tr>
          </table>
        </div>
        </xsl:for-each>
      </div>
    </xsl:template>
</xsl:stylesheet>

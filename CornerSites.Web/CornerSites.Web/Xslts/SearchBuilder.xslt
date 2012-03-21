<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="NewDataSet">
      <xsl:for-each select="Table">
        <xsl:variable name="BuilderID" >
          <xsl:value-of select="BuilderID"/>
        </xsl:variable>
        <div>
          <xsl:value-of select="BuilderName"/>
          <br></br>
          <xsl:value-of select="BuilderRegAddress"/>          
        </div>
        <div>
          <xsl:value-of select="AboutBuilder"/>
        </div>
        <div style="clear: both"></div>
          <div style="float: right">
            <a id="btnViewMore" runat="server" target="_blank">View More</a>
          </div>
          <div style="float: left ;padding-bottom:15px">
            <input type="button" id="btnContactsBuilder_{$BuilderID}" onclick="javascript:return ViewContactBuilder();" value="View Contact Details" />
          </div>
          <div style="float: left ;padding-bottom:15px">
            <input type="button" id="btnEmailBuilder_{$BuilderID}" onclick="javascript:return ViewContactBuilder();" value="Email" />
          </div>
          <div style="clear: both"></div>
            <div id="dvBuilder_{$BuilderID}" >
              <table>
                <tr>
                  <td>                    
                    Contact Name
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="ContactName"/>                    
                  </td>
                </tr>
                <tr>
                  <td>
                    Mobile No
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="BuilderMobileNumber"/>
                  </td>
                </tr>
                <tr>
                  <td>
                    Mobile No
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="BuilderPhoneNumber1"/>
                  </td>
                </tr>
                <tr>
                  <td>
                    Mobile No
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="BuilderPhoneNumber2"/>                   
                  </td>
                </tr>
                <tr>
                  <td>
                    Mobile No
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="BuilderPhoneNumber3"/>
                  </td>
                </tr>
                <!--<tr>
                  <td>
                    Email ID
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="EmailID"/>                    
                  </td>
                </tr>-->
              </table>
            </div>
      </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>

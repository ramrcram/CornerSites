<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="NewDataSet">
      <xsl:for-each select="Table">
        <xsl:variable name="ProjectID" >
          <xsl:value-of select="ProjectID"/>
        </xsl:variable>
        <div>
          <xsl:value-of select="ProjectName"/>
          <br></br>
          <xsl:value-of select="ProjectAddress"/>          
        </div>
        <div>
          <xsl:value-of select="ShortDescription"/>         
        </div>
        <div style="clear: both"></div>
          <div style="float: right">
            <a id="btnViewMore" runat="server" target="_blank">View More</a>
          </div>
          <div style="float: left; padding-bottom: 15px">
            <input type="button" id="btnContactsProject_{$ProjectID}" onclick="javascript:return ViewContactAgent();" value="View Contact Details" />
            <!--<asp:Button ID="btnContacts" runat="server" Text="View Contact Details" CommandName="viewcontact"
                CommandArgument="searchresult" />-->
          </div>
          <div style="float: left ;padding-bottom:15px">
            <input type="button" id="btnEmailProject_{$ProjectID}" onclick="javascript:return ViewContactAgent();" value="Email" />
            <!--<asp:Button ID="btnEmail" runat="server" Text="Send Email" CommandName="email" CommandArgument="searchresult" />-->
          </div>
        <div style="clear: both"></div>
            <div id="divContact" runat="server">
              <table>
                <tr>
                  <td>
                    Contact Name
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="ProjectContactName"/>                    
                  </td>
                </tr>
                <tr>
                  <td>
                    Phone No
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="ProjectPhoneNumber1"/>
                  </td>
                </tr>
                <tr>
                  <td>
                    Phone No
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="ProjectPhoneNumber2"/>
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
                    <xsl:value-of select="ProjectMobileNumber"/>
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
                <tr>
                  <td>
                    Website
                  </td>
                  <td>
                    :
                  </td>
                  <td>
                    <xsl:value-of select="BuiderURL"/>
                  </td>
                </tr>
              </table>
            </div>
          </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>

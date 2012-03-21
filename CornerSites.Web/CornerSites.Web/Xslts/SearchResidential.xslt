<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="NewDataSet">
    <xsl:for-each select="Table">
      <xsl:variable name="ID" >
        <xsl:if test="CommercialAdID != ''">
          <xsl:value-of select="CommercialAdID"/>
        </xsl:if>
        <xsl:if test="ResidentialAdID != ''">
          <xsl:value-of select="ResidentialAdID"/>
        </xsl:if>
        <xsl:if test="ResidentialReqId != ''">
          <xsl:value-of select="ResidentialReqId"/>
        </xsl:if>
        <xsl:if test="CommercialReqId != ''">
          <xsl:value-of select="CommercialReqId"/>
        </xsl:if>
      </xsl:variable>
      <div style="width: 100%;border:solid 5px #FFFFFF">
        <div style="padding-bottom:15px">
          <b>
            <xsl:value-of select="AdHeader"/>
          </b>
        </div>
        <div style="clear: both">
        </div>
        <div style="width: 35%; float: left ;padding-bottom:15px">
          <div>
            <img id="rupee" alt="" height="12px" width="7px" src="../Images/Rupee.png" />
            <xsl:value-of select="PropertyPrice"/>
            <!--<asp:Label ID="lblPropertyPrice" runat="server" Text=''
              <%# Eval("PropertyPrice")%>'></asp:Label>-->
          </div>
          <div style="clear: both">
          </div>
          <div>
            <xsl:value-of select="PropertyDescription"/>
            <!--<asp:Label ID="lblPropertyDescription" runat="server" Text=''
              <%# Eval("PropertyDescription")%>'></asp:Label>-->
          </div>
        </div>
        <div style="width: 35% ;padding-bottom:15px">
          <div>
            <table>
              <tr>
                <td>
                  Bedrooms
                </td>
                <td>
                  :
                </td>
                <td>
                  <xsl:value-of select="BedRooms"/>
                  <!--<asp:Label ID="Label2" runat="server" Text=''
                    <%# Eval("BedRooms")%>'></asp:Label>-->
                </td>
              </tr>
              <!--<xsl:if test="BathRooms = ''">-->
              <tr>
                <td>
                  Bathrooms
                </td>
                <td>
                  :
                </td>
                <td>
                  <xsl:value-of select="BathRooms"/>
                  <!--<asp:Label ID="Label4" runat="server" Text=''
                    <%# Eval("BathRooms")%>'></asp:Label>-->
                </td>
              </tr>
              <!--</xsl:if>-->
              <tr>
                <td>
                  Covered Area
                </td>
                <td>
                  :
                </td>
                <td>
                  <xsl:value-of select="BuildArea"/>
                  <!--<asp:Label ID="Label6" runat="server" Text=''
                    <%# Eval("BuildArea")%>'></asp:Label>-->
                </td>
              </tr>
              <tr>
                <td>
                  Build Area
                </td>
                <td>
                  :
                </td>
                <td>
                  <xsl:value-of select="BuildArea"/>
                  <!--<asp:Label ID="Label5" runat="server" Text=''
                    <%# Eval("BuildArea")%>'></asp:Label>-->
                </td>
              </tr>
            </table>
          </div>
        </div>
        <div style="width: 35%; float: right ;padding-bottom:15px">
          <div>
            <img id="rupee" alt="" height="12px" width="7px">
              <xsl:attribute name="src">
                <xsl:value-of select="PropertyImage1"/>
              </xsl:attribute>
            </img>
            <!--<asp:Image ID="proImage" runat="server" ImageUrl=''
            <%# Eval("PropertyImage1")%>' />-->
          </div>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left ;padding-bottom:15px">
          <div>
            Amenities
            <img id="rupee" alt="" height="12px" width="7px" src="Images/Rupee.png" ></img>
            <!--<asp:Image ID="imgAmenities" runat="server" ImageUrl="~/Images/Rupee.png" />-->
          </div>
        </div>
        <div style="clear: both"></div>
        <div style="float: right">
          <a id="btnViewMore_{$ID}" runat="server" target="_blank">View More</a>
        </div>
        <div style="float: left ;padding-bottom:15px">
          <input type="button" id="btnContacts_{$ID}" onclick="javascript:return ViewContact('divContact_','{$ID}');" value="View Contact Details" />
          <!--<asp:Button ID="btnContacts" runat="server" Text="View Contact Details" CommandName="viewcontact"
              CommandArgument="searchresult" />-->
        </div>
        <div style="float: left ;padding-bottom:15px">
          <input type="button" id="btnEmail_{$ID}" value="Send Email" />
          <!--<asp:Button ID="btnEmail" runat="server" Text="Send Email" CommandName="email" CommandArgument="searchresult" />-->
        </div>
        <div style="clear: both"></div>
        <div id="divContact_{$ID}" style="display:none">
          <table>
            <tr>
              <td>
                Name
              </td>
              <td>
                :
              </td>
              <td>
                <xsl:value-of select="FullName"/>
                <!--<asp:Label ID="lblName" runat="server" Text=''
                  <%# Eval("FullName")%>'></asp:Label>-->
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
                <xsl:value-of select="MobileNumber"/>
                <!--<asp:Label ID="lblMobile" runat="server" Text=''
                  <%# Eval("MobileNumber")%>'></asp:Label>-->
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
                --><!--<asp:Label ID="lblEmailID" runat="server" Text=''
                  <%# Eval("EmailID")%>'></asp:Label>--><!--
              </td>
            </tr>-->
          </table>
        </div>
      </div>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>

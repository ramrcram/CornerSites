<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostRequirement.ascx.cs" Inherits="CornerSites.Web.Modules.PostRequirement" %>
<%--<script type="text/javascript">
    $(document).ready(function() {
        $("#<%=txtCity.ClientID%>").autocomplete("<%= ConfigurationManager.AppSettings["SiteCityAutoComplete"]%>");
        $("#<%=txtLocation.ClientID%>").autocomplete("<%= ConfigurationManager.AppSettings["SiteLocationAutoComplete"]%>");
//    $("#<%=txtCity.ClientID%>").autocomplete('http://14.99.254.189:90/Modules/CityAutoComplete.ashx');
//    $("#<%=txtLocation.ClientID%>").autocomplete('http://14.99.254.189:90/Modules/LocationAutoComplete.ashx');
    });
</script>--%>

<div>
    Post Requirement
    Didn't find the property you were looking for? Just fill the form below with your 
    Requirements and Property advertisers will contact you soon.
    You will also receive alerts of properties matching your requirements.
</div>
<div style="padding-bottom:10px">
    <asp:Label ID="lblMessage" runat="server" EnableViewState="false"  ForeColor="Green" ></asp:Label>
</div>

<div>
    <table border="0" cellpadding="2" cellspacing="2" >
        <tr>
            <td colspan="2">
                I WANT TO :
                <asp:RadioButton ID="rbdBuy" runat="server" Text="Buy" Checked="true" GroupName="Search" />
                <asp:RadioButton ID="rbdRent" runat="server" Text="Rent" GroupName="Search" />
            </td>
        </tr>
        <tr>
         <td width="163">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span>STATE :</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedChange"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="163">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span>CITY :</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedChange" AutoPostBack="true"></asp:DropDownList>
                           <%-- <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="250">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span>BEDROOM :</span>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtBedroooms" runat="server"></asp:TextBox>
                        </td>                        
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span>PRICE(FORM) :</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtBudgetfrom" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span>PRICE(TO) :</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtBudgetTo" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>        
        <tr>
            <td>
                PRPERTY TYPE :
            </td>
            <td>
                LOCATION :
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlPropertType" runat="server">
                </asp:DropDownList>
            </td>
            <td>
            <asp:DropDownList ID="ddlLocation" runat="server" ></asp:DropDownList>
                <%--<asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>--%>
            </td>
        </tr>
        <tr>
            <td>
                Covered Area
            </td>
            <td>          
                <asp:DropDownList ID="ddlCoverdUnit" runat="server"></asp:DropDownList>      
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtCoveredArea" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Build Area
            </td>
            <td>          
                <asp:DropDownList ID="ddlBuildUnit" runat="server"></asp:DropDownList>      
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtBuildArea" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td>
                Discription
            </td>
            <td>                
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtDiscription" runat="server" TextMode="MultiLine" Rows="10"  Columns="10"> </asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfdCityID" runat="server" />
    <asp:HiddenField ID="hfdLocation" runat="server" />
</div>

<div>
    <asp:Button ID="btnPostReq" runat="server" onclick="btnPostReq_Click" Text="Post Requirement" />
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchRequirement.ascx.cs"
    Inherits="CornerSites.Web.Modules.SearchRequirement" %>
<%--<link href="../Css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />

<script src="../Scripts/jqueryMini-1.6.js" type="text/javascript"></script>

<script src="../Scripts/jquery.autocomplete.js" type="text/javascript"></script>--%>
<%--<script type="text/javascript">
    $(document).ready(function() {
        $("#<%=txtCity.ClientID%>").autocomplete("<%= ConfigurationManager.AppSettings["SiteCityAutoComplete"]%>");
        $("#<%=txtLocation.ClientID%>").autocomplete("<%= ConfigurationManager.AppSettings["SiteLocationAutoComplete"]%>");
//    $("#<%=txtCity.ClientID%>").autocomplete('http://14.99.254.189:90/Modules/CityAutoComplete.ashx');
//    $("#<%=txtLocation.ClientID%>").autocomplete('http://14.99.254.189:90/Modules/LocationAutoComplete.ashx');
    });
</script>--%>
<div>
    <table width="413" border="0" cellpadding="2" cellspacing="2">
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
                            <asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedChange"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>--%>
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
                <asp:DropDownList ID="ddlLocation" runat="server">
                </asp:DropDownList>
                <%-- <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_click" />
                <div>
                    <span>Show properties from</span>
                    <div>
                        <asp:CheckBox ID="chkIndividual" runat="server" Text="Individual" Checked="true" />
                        <asp:CheckBox ID="chkDealers" runat="server" Text="Dealers" Checked="true" />
                        <asp:CheckBox ID="chkBuilders" runat="server" Text="Builders" Checked="true" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfdCityID" runat="server" />
    <asp:HiddenField ID="hfdLocation" runat="server" />
</div>

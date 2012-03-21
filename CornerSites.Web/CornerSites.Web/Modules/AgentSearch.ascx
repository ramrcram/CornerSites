<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgentSearch.ascx.cs" Inherits="CornerSites.Web.Modules.AgentSearch" %>
<%--<script type="text/javascript">
    $(document).ready(function() {
        $("#<%=txtCity.ClientID%>").autocomplete("<%= ConfigurationManager.AppSettings["SiteCityAutoComplete"]%>");
        $("#<%=txtLocation.ClientID%>").autocomplete("<%= ConfigurationManager.AppSettings["SiteLocationAutoComplete"]%>");
    });
</script>--%>

<div>
    <table border="0" cellpadding="2" cellspacing="2" >        
        
        <tr>
          <td width="163">STATE :</td>
          <td width="163"><asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedChange"
                                AutoPostBack="true"> </asp:DropDownList>
            <%--<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>--%></td>
        </tr>
        <tr>
          <td>CITY :</td>
          <td><asp:DropDownList ID="ddlCity" runat="server" OnSelectedIndexChanged="ddlCity_SelectedChange" AutoPostBack="true"></asp:DropDownList>
            <%-- <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>--%></td>
        </tr>
        <tr>
          <td>Location:</td>
          <td><asp:DropDownList ID="ddlLocation" runat="server" ></asp:DropDownList>
            <%-- <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>--%></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td><asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click"  Text="Search"/></td>
        </tr>
    </table>
<asp:HiddenField ID="hfdCityID" runat="server" />
    <asp:HiddenField ID="hfdLocation" runat="server" />
</div>
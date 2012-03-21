<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBuilder.ascx.cs" Inherits="CornerSites.Web.Modules.SearchBuilder" %>


<div>
    <table border="0" cellpadding="2" cellspacing="2" >        
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
                        <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true"></asp:DropDownList>
                           <%-- <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>--%>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="250">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span>Search Builder:</span>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlSearchBuilder" runat="server">
                            <asp:ListItem Text="Operating In" Value="O"></asp:ListItem>
                            <asp:ListItem Text="Based In" Value="B"></asp:ListItem>
                            <asp:ListItem Text="Both" Value="A"></asp:ListItem>                            
                            </asp:DropDownList>
                        </td>                        
                    </tr>
                </table>
            </td>
            <td width="250">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>                            
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click"  Text="Search"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfdCityID" runat="server" />
    <asp:HiddenField ID="hfdSearchBuilder" runat="server" />
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfileInfo.ascx.cs"
    Inherits="CornerSites.Web.Modules.MyAccount.ProfileInfo" %>
<div >
    <table>
        <tr>
            <td>
                Name:
            </td>
            <td>
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                EmailID
            </td>
            <td>
                <asp:Label ID="lblMail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                PhoneNum
            </td>
            <td>
                <asp:Label ID="lblPhone" runat="server" ></asp:Label>
            </td>
        </tr>
    </table>
</div>

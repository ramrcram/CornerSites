<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DirectPayment.ascx.cs"
 Inherits="CornerSites.Web.Modules.DirectPayment" %>
<div>
    <table>
        <tr>
            <td>
                <span>Card Type</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlCardType" runat ="server">
                <asp:ListItem Text="MasterCard" Value="MasterCard"></asp:ListItem>
                <asp:ListItem Text="Visa" Value="Visa"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>  
        <tr>
            <td>
                <span>Card Number</span>
            </td>
            <td>
                <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>    
            <td>
                <span>Card Holder's Name</span>
            </td>
            <td>
                <asp:TextBox ID="txtCardHoldersName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>    
            <td>
                <span>Expiry</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
            </td>
        </tr> 
        <tr>
            <td>
                <span>CVV</span>
            </td>
            <td>
                <asp:TextBox ID="txtCVV" runat="server" TextMode="Password" ></asp:TextBox>
            </td>
        </tr> 
        <tr>
        <td></td>
            <td>
                <asp:Button ID="btnPay" Text="Pay" runat="server" onclick="btnPay_Click" />
            </td>    
        </tr>
    </table>
</div>
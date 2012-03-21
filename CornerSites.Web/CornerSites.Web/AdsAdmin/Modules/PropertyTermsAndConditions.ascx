<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PropertyTermsAndConditions.ascx.cs" 
    Inherits="CornerSites.Web.AdsAdmin.Modules.PropertyTermsAndConditions" %>
<div>
    <table>
        <tr>
            <td>
                <span>Terms & Conditions</span>
            </td>
            <td>
                <asp:TextBox ID="txtTermsConditions" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
            </tr>
            <tr>
                <td>
                    <span>Annual Dues ( if any)</span>
                </td>
            <td>
                <asp:TextBox id="txtAnnualDues" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
    </table>
</div>

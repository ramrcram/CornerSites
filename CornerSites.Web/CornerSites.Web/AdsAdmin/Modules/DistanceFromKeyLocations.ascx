<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DistanceFromKeyLocations.ascx.cs"
    Inherits="CornerSites.Web.AdsAdmin.Modules.DistanceFromKeyLocations" %>
<div id="distance">
    <table>
        <tr>
            <td>
                <span>
                    <asp:Label ID="lblHospital" runat="server" Text="Hospital"></asp:Label>
                    <asp:TextBox ID="txtHospital" runat="server"></asp:TextBox>
                    Kms </span>
            </td>
            <td>
                <span>
                    <asp:Label ID="lblMall" runat="server" Text="Shopping Mall/ Market"></asp:Label>
                    <asp:TextBox ID="txtMall" runat="server"></asp:TextBox>
                    Kms </span>
            </td>
            <td>
                <span>
                    <asp:Label ID="lblAirport" runat="server" Text="Airport"></asp:Label>
                    <asp:TextBox ID="txtAirport" runat="server"></asp:TextBox>
                    Kms </span>
            </td>
        </tr>
        <tr>
            <td>
                <span>
                    <asp:Label ID="lblRailway" runat="server" Text="Railway Station"></asp:Label>
                    <asp:TextBox ID="txtRailway" runat="server"></asp:TextBox>
                    Kms </span>
            </td>
            <td>
                <span>
                    <asp:Label ID="lblSchool" runat="server" Text="School/College"></asp:Label>
                    <asp:TextBox ID="txtSchool" runat="server"></asp:TextBox>
                    Kms </span>
            </td>
            <td>
                <span>
                    <asp:Label ID="lblTown" runat="server" Text="Town/city centre"></asp:Label>
                    <asp:TextBox ID="txtTown" runat="server"></asp:TextBox>
                    Kms </span>
            </td>
        </tr>
    </table>
</div>
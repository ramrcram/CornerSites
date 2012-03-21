<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PropertyFeatures.ascx.cs"
 Inherits="CornerSites.Web.AdsAdmin.Modules.PropertyFeatures" %>
 <div>
    <table>
        <tr>
            <td>
                <span>Floor Number </span>
            </td>
            <td>
                <asp:DropDownList ID="ddlFloorNumber" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <span>Total Floors</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlTotalFloors" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <span>Construction Age</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlConstructionAge" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <span>Ownership</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlOwnership" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <span>Furnished</span>
            </td>
            <td>
                <asp:DropDownList ID="ddlFurnished" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <span>LandMarks</span>
            </td>
            <td>
               <asp:TextBox ID="txtLandMark" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <span>Property Image ( max size 150 KB)</span>
            </td>
            <td>
                <asp:Image ID="imgProertyImage" runat="server" Width="100" Height="100" />
                <asp:FileUpload ID="fupPropertyImage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>   
                <asp:Literal ID="ltnUploadError" runat="server" EnableViewState="false"></asp:Literal>             
            </td>
            <td>
                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="upload" />
            </td>
        </tr>
    </table>
 </div>

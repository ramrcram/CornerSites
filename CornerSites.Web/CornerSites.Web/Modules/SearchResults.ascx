<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResults.ascx.cs"
    Inherits="CornerSites.Web.Modules.SearchResults" %>
<div style="clear: both">
</div>
<div style="padding-top: 45px;">
    <asp:Panel ID ="panResult" runat="server"></asp:Panel>
   <%-- <asp:Repeater ID="grdSearchAds" runat="server" OnItemCommand="grdSearchAds_ItemCommand"
        OnItemDataBound="grdSearchAds_ItemDataBound">
        <ItemTemplate>
            <div style="width: 100%;border:solid 5px #FFFFFF">
                <div style="padding-bottom:15px">
                    <b>
                    <asp:Label ID="lblAdHeader" runat="server" Text='<%# Eval("AdHeader")%>'></asp:Label>
                    </b>
                </div>
                <div style="clear: both">
                </div>
                <div style="width: 35%; float: left ;padding-bottom:15px">
                    <div>
                        <img id="rupee" alt="" height="12px" width="7px" src="../Images/Rupee.png" />
                        <asp:Label ID="lblPropertyPrice" runat="server" Text='<%# Eval("PropertyPrice")%>'></asp:Label>
                    </div>
                    <div style="clear: both">
                    </div>
                    <div>
                        <asp:Label ID="lblPropertyDescription" runat="server" Text='<%# Eval("PropertyDescription")%>'></asp:Label>
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
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("BedRooms")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bathrooms
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("BathRooms")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Covered Area
                                </td>
                                <td>
                                    :
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("BuildArea")%>'></asp:Label>
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
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("BuildArea")%>'></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div style="width: 35%; float: right ;padding-bottom:15px">
                    <div>
                        <asp:Image ID="proImage" runat="server" ImageUrl='<%# Eval("PropertyImage1")%>' />
                    </div>
                </div>
                <div style="clear: both">
                </div>
                <div style="float: left ;padding-bottom:15px">
                    <div>
                        Amenities
                        <asp:Image ID="imgAmenities" runat="server" ImageUrl="~/Images/Rupee.png" />
                    </div>
                </div>
                <div style="clear: both"></div>
                <div style="float: right">
                    <a id="btnViewMore" runat="server" target="_blank">View More</a>
                </div>
                <div style="float: left ;padding-bottom:15px">
                    <asp:Button ID="btnContacts" runat="server" Text="View Contact Details" CommandName="viewcontact"
                        CommandArgument="searchresult" />
                </div>
                <div style="float: left ;padding-bottom:15px">
                    <asp:Button ID="btnEmail" runat="server" Text="Send Email" CommandName="email" CommandArgument="searchresult" />
                </div>
                <div style="clear: both"></div>
                <div id="divContact" runat="server">
                    <table>
                        <tr>
                            <td>
                                Name
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("FullName")%>'></asp:Label>
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
                                <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("MobileNumber")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email ID
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblEmailID" runat="server" Text='<%# Eval("EmailID")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>            
            </div>
        </ItemTemplate>
    </asp:Repeater>--%>
</div>
<div style="clear: both">
</div>
<div>
    <asp:Literal ID="ltrNoRecord" runat="server"></asp:Literal>
</div>

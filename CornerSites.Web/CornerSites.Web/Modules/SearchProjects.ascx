<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchProjects.ascx.cs" Inherits="CornerSites.Web.Modules.SearchProjects" %>

<%--<script type="text/javascript">
    $(document).ready(function() {
    $("#<%=txtCity.ClientID%>").autocomplete("<%= ConfigurationManager.AppSettings["SiteCityAutoComplete"]%>");
    $("#<%=txtLocation.ClientID%>").autocomplete("<%= ConfigurationManager.AppSettings["SiteLocationAutoComplete"]%>");
    });
</script>--%>

<%--<div>
    Post Requirement
    Didn't find the property you were looking for? Just fill the form below with your 
    Requirements and Property advertisers will contact you soon.
    You will also receive alerts of properties matching your requirements.
</div>--%>

<div>
    <table border="0" cellpadding="2" cellspacing="2" >        
        <tr>
            <td width="163">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span>Lookign for :</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlPropertyType" runat="server" ></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddltype" ErrorMessage="Select Property Type" ControlToValidate="ddlPropertyType" 
                                InitialValue="-1" runat="server" ValidationGroup="Project">
                            *</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
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
            <td width="250">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <span>Location:</span>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                          <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                           <%-- <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>--%>
                            <asp:RequiredFieldValidator ID="rfdLocation" ErrorMessage="Select Property Type" ControlToValidate="ddlLocation" 
                                runat="server" ValidationGroup="Project">
                            </asp:RequiredFieldValidator>
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
                        <asp:DropDownList ID="ddlCity" runat="server"  OnSelectedIndexChanged="ddlCity_SelectedChange" AutoPostBack="true"></asp:DropDownList>
                           <%-- <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>--%>
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
                            <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click"  Text="Search" ValidationGroup="Project" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hfdCityID" runat="server" />
    <asp:HiddenField ID="hfdLocation" runat="server" />
</div>

<%--<div>    
    <asp:DataGrid ID="dgProject" runat="server" Visible="false" 
        onitemdatabound="dgProject_ItemDataBound" 
        onitemcommand="dgProject_ItemCommand">        
        <Columns>            
            <asp:TemplateColumn>                
                <ItemTemplate>
                    <div>
                        <asp:Label ID="lblProjectName" runat="server" Text='<%# Eval("ProjectName")%>'></asp:Label>
                        <asp:Label ID="lblProjectAddress" runat="server" Text='<%#Eval("ProjectAddress") %>'></asp:Label>
                    </div>                    
                    <div>
                        <asp:Label ID="lblShortDescription" runat="server" Text='<%#Eval("ShortDescription") %>'></asp:Label>
                    </div>
                     <div style="clear: both">
                    <div style="float: right">
                        <a id="btnViewMore" runat="server" target="_blank">View More</a>
                    </div>
                         <div style="float: left; padding-bottom: 15px">
                             <asp:Button ID="btnContacts" runat="server" Text="View Contact Details" CommandName="viewcontact"
                                 CommandArgument="searchresult" />
                         </div>
                <div style="float: left ;padding-bottom:15px">
                    <asp:Button ID="btnEmail" runat="server" Text="Send Email" CommandName="email" CommandArgument="searchresult" />
                </div>
                <div style="clear: both">
                <div id="divContact" runat="server">
                 <table>
                        <tr>
                            <td>
                                Contact Name
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server" Text='<%# Eval("ProjectContactName")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phone No
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("ProjectPhoneNumber1")%>'></asp:Label>
                            </td>
                        </tr>
                          <tr>
                            <td>
                               Phone No
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProjectPhoneNumber2")%>'></asp:Label>
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
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("ProjectMobileNumber")%>'></asp:Label>
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
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("BuilderPhoneNumber3")%>'></asp:Label>
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
                        <tr>
                            <td>
                                Website
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("BuiderURL")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
</div>--%>

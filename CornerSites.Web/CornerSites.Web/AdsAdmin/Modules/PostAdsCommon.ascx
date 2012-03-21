<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostAdsCommon.ascx.cs"
    Inherits="CornerSites.Web.AdsAdmin.Modules.PostAdsCommon" %>
    
<div id="divcommon">
    <h3>
        Basic Details and Location</h3>
    <div id="divRadBtns">
        <table>
            <tr>
                <td>
                    <span>Property to</span>
                    <asp:RadioButton ID="radBtnRent" runat="server" Text="Rent" Checked="true" GroupName="LeaseType" />
                    <asp:RadioButton ID="radBtnSell" runat="server" Text="Sell" GroupName="LeaseType" />
                </td>
            </tr>
        </table>
    </div>
    <%--<div id="divValidationSummary">
    <asp:ValidationSummary ID="valSummary" HeaderText="error" DisplayMode="List" runat="server" ShowSummary="true" ValidationGroup="grpsave" ShowMessageBox="false" />
    </div>--%>
    <div id="divFeatures">
        <table>
            <tr>
                <td>
                    <span>Ad header</span>
                </td>
                <td>
                    <asp:TextBox ID="txtAdHeader" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvAdHeader" runat="server" ValidationGroup="grpsave" 
                        ControlToValidate="txtAdHeader" ErrorMessage="Enter the Header">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Property type</span>.
                </td>
                <td>
                    <asp:DropDownList ID="ddltype" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                    </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="rfvddltype" ErrorMessage="Select Property Type" ControlToValidate="ddltype" InitialValue="-1" runat="server" ValidationGroup="grpsave">
                    *</asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--TODO: waiting for sales type and functionality--%>
            <%--<tr>
                <td>
                    <span>Sale Type *</span>. 
                </td>
                <td>
                    <asp:DropDownList ID="ddlSaleType" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <span>State </span>.
                </td>
                <td>
                    <asp:DropDownList ID="ddlState" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                    </asp:DropDownList>
                     <asp:requiredfieldvalidator id="rfvstate" controltovalidate="ddlstate" ErrorMessage="Select a state" initialvalue="-1" runat="server" validationgroup="grpsave">
                    *</asp:requiredfieldvalidator>
                </td>
            </tr>
            <tr>
                <td>
                    <span>City </span>
                </td>
                <td>
                    <asp:UpdatePanel ID="CityUpdatePanel" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlState" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rfvCity" ControlToValidate="ddlCity" ErrorMessage="Select a City" InitialValue="-1" runat="server" 
                                ValidationGroup="grpsave">
                     *</asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Location</span>
                </td>
                <td>
                    <asp:UpdatePanel ID="LocationUpdatePanel" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlCity" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlLocation" runat="server">
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rfvLocation" ControlToValidate="ddlLocation" ErrorMessage="Select your Locality" InitialValue="-1" runat="server" ValidationGroup="grpsave">
                             *</asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Address</span>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvAddress" ErrorMessage="Enter the Address" ControlToValidate="txtAddress" runat="server" ValidationGroup="grpsave">
                    *</asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    <h3>
        Basic Features and Price</h3>
    <div id="">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblDescProp" runat="server" Text="Descrption of Property "></asp:Label>
                    <asp:TextBox ID="txtDescProp" runat="server" TextMode="MultiLine"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rfvDesc"  ErrorMessage="Provide Property Description"  ControlToValidate="txtDescProp" runat="server" ValidationGroup="grpsave">
                    *</asp:RequiredFieldValidator>
                </td>
            </tr>
            <%-- RAMESH PLEASE NOTE
       only for plot it is not there all other residential properties bedroom and bathroom is there--%>
            <tr>
                <td>
                    <asp:Label ID="lblBedrooms" runat="server" Text="Bedrooms "></asp:Label>.
                    <asp:DropDownList ID="ddlBedrooms" runat="server">
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfvBedrooms" InitialValue="-1"  ErrorMessage="Select the number of bedrooms" ControlToValidate="ddlBedrooms" runat="server" ValidationGroup="grpsave">
                    *</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBathrooms" runat="server" Text="Bathrooms "></asp:Label>.
                    <asp:DropDownList ID="ddlBathrooms" runat="server">
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="rfvBathrooms" ControlToValidate="ddlBathrooms"  ErrorMessage="Select the number of bathrooms" InitialValue="-1" runat="server" ValidationGroup="grpsave">
                    *</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLandArea" runat="server" Text="Land/Plot Area"></asp:Label>
                    <span>
                        <asp:TextBox ID="txtLandArea" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLandarea"  ErrorMessage="Enter the Area" runat="server" ControlToValidate="txtLandArea" ValidationGroup="grpsave">
                        *</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlSqFt" runat="server">
                            <asp:ListItem Text="Sq-ft"></asp:ListItem>                            
                        </asp:DropDownList>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBuildArea" runat="server" Text="Build Area "></asp:Label>
                    <span>
                        <asp:TextBox ID="txtBuildArea" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBuildArea"  ErrorMessage="Enter the Build Area" runat="server" ControlToValidate="txtBuildArea" ValidationGroup="grpsave">
                        *</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlBuildSqFt" runat="server">
                            <asp:ListItem Text="Sq-ft"></asp:ListItem>
                        </asp:DropDownList>
                    </span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPrice" runat="server" Text="Total Price (in Rs)"></asp:Label>
                    <span>
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvPrice" runat="server"  ErrorMessage="enter the Price" ControlToValidate="txtPrice" ValidationGroup="grpsave">
                         *</asp:RequiredFieldValidator>
                        <asp:CheckBox ID="chkPrice" runat="server" />
                        <asp:Label ID="lblchkPrice" runat="server" Text="Price Negotiable"></asp:Label>
                    </span>
                </td>
            </tr>
        </table>
    </div>
</div>
<div>
    <%--<asp:UpdatePanel ID="ResidentiPlotSpecialFieldUpdatePanel" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddltype" EventName="SelectedIndexChanged" />
        </Triggers>
        <ContentTemplate>--%>
            <asp:Panel ID="panSpecialFeilds" runat="server">                
            </asp:Panel>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</div>
<div>    
</div>
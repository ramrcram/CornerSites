<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="CornerSites.Web.Modules.Register" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<div style="clear: both">
</div>
<div>
    <table>
        <tr>
            <td>
                Please fill the following Details to register
            </td>
        </tr>
        <tr>
            <td>
                * Symbol for Mandatory Fields
            </td>
        </tr>
        <tr>
            <td>
                <asp:RadioButton runat="server" ID="rbtIndividual" Checked="true" GroupName="UserType"
                    Text="Individual" />
                <%-- </td>
        <td>--%>
                <asp:RadioButton runat="server" ID="rbtDealer" GroupName="UserType" Text="Dealers/Agents" />
                <%--  </td>
        <td>--%>
                <asp:RadioButton runat="server" ID="rbtBuilder" GroupName="UserType" Text="Builders" />
            </td>
        </tr>
        <tr>
            <td>
                Full Name 
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFullName"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ValidationGroup="Register"
                    ControlToValidate="txtFullName" ErrorMessage="*" />
            </td>
        </tr>
        <tr>
            <td>
                Email ID 
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ValidationGroup="Register"
                    ControlToValidate="txtEmail" ErrorMessage="*" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please input correct email address!"
                    ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Password 
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="txtPassword"
                    ValidationGroup="Register" ErrorMessage="*" />
            </td>
        </tr>
        <tr>
            <td>
                City 
            </td>
            <td>
                <%--<asp:TextBox runat="server" ID="txtCity"></asp:TextBox>--%>
                <%--<asp:DropDownList runat="server" ID="ddlCity" AutoPostBack="True" 
                        DataSourceID="EntityDataSource1" DataTextField="CityName" 
                        DataValueField="CityID" ></asp:DropDownList>--%>
                <asp:DropDownList runat="server" ID="ddlCity" OnSelectedIndexChanged="ddlCity_SelectedChange" AutoPostBack="true">
                </asp:DropDownList>
                <%--<asp:EntityDataSource ID="EntityDataSource1" runat="server" 
                        ConnectionString="name=CornerSitesEntities" 
                        DefaultContainerName="CornerSitesEntities" EntitySetName="tblCity" 
                        EntityTypeFilter="tblCity">
                    </asp:EntityDataSource>--%>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ValidationGroup="Register"
                    ControlToValidate="ddlCity" ErrorMessage="*" />
            </td>
            <td>
                If your city is not listed<a href="Default.aspx"> Click here</a>
            </td>
        </tr>
        <tr>
            <td>
                Mobile Number 
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtMobile"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ValidationGroup="Register"
                    ControlToValidate="txtMobile" ErrorMessage="*" />
            </td>
            <td>
                <asp:CheckBox runat="server" ID="chkForSMS" Text="Use this mobile  number for SMS" />
            </td>
        </tr>
        <tr>
            <td>
                LandLine
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtLandline" />
            </td>
        </tr>
        <tr>
            <td>
                Additional Information
            </td>
        </tr>
        <tr>
            <td>
                Area
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlArea">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Address of Reg Office (Dealers/Builders)
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtRegOffice"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Enter the letters in the picture 
            </td>
            <td>
                <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="none" CaptchaLength="5"  CssClass="Captcha"
                    CaptchaHeight="60" CaptchaWidth="150" CaptchaLineNoise="None" CaptchaMinTimeout="5" CaptchaMaxTimeout="240" />
            </td>
        </tr>
        <tr>
            <td>
            </td>            
            <td>
                <asp:TextBox runat="server" ID="txtCaptcha"></asp:TextBox>
                <%--<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ValidationGroup="Register"
                    ControlToValidate="txtCaptcha" ErrorMessage="*" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <input id="chkAgree" disabled="disabled" type="checkbox" checked="checked" />I have read and
                agreed the <a href="Default.aspx">terms and conditions</a> of this website.
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" Text="" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" ID="btnRegister" ValidationGroup="Register" 
                    OnClick="btnRegister_click" Text="Register" />
            </td>
        </tr>
    </table>
</div>

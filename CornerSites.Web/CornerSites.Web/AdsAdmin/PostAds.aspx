<%@ Page Title="CornerSites :: post Ads" Language="C#" MasterPageFile="~/App_Master/layout.Master"
    AutoEventWireup="true" CodeBehind="PostAds.aspx.cs" Inherits="CornerSites.Web.AdsAdmin.PostAds" ValidateRequest="true" %>
<%--<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>--%>
<%@ Register TagPrefix="CornerSites" TagName="AdsCommon" Src="~/AdsAdmin/Modules/PostAdsCommon.ascx" %>
<%--<%@ Register TagPrefix="CornerSites" TagName="AddsSubscription" Src="~/Modules/AddsSubscription.ascx" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">        
    <link type="text/css" href="../Css/lightBox.css" rel='stylesheet' />
    <script src="../Scripts/lightBox.js" type="text/javascript" language="javascript" ></script>
    <script type="text/javascript" language="javascript">
        function LightBox() {
            debugger;
            ShowLightBox('dialogbox', 'true', -300, -300, 0, 0);
        } 
    </script>

    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <div class="clear">
    </div>
    <div>
        <asp:Panel ID="PostAdds" runat="server">
            <CornerSites:AdsCommon ID="cntAdsCommon" runat="server" />
        </asp:Panel>
    </div>
    <div>
        <%--Captcha Code--%>
        <div id="divCaptcha">
            <%--<recaptcha:recaptchacontrol id="recaptcha" runat="server" theme="white" publickey="6LecZL8SAAAAAGta9Ttn8wmdphtEUum8xJnM4-bo"
                privatekey="6LecZL8SAAAAAF1tnx-jfbPegHGjjpM9KYANVkwa" />--%>
        </div>
    </div>
    <div>
        <%--<anthem:Button ID="btnSaveButton" runat="server" Text="SaveAnthem" OnClick="btnSaveButton_Click" />--%>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
    </div>
   <div id="fade" class="LB-black-overlay" onclick="if (!is_modal) HideLightBox(); return true;">
    </div>
    <div id="dialogbox" class="LB-white-content" style="width: auto;">
        
        <div>
            <table >
            <tr>
                <td>
                    <a id="close" href="" onclick="HideLightBox(); return false;" />
                </td>
            </tr>
            <tr>
                <td>
                    <div>
                    <%--<CornerSites:AddsSubscription ID="cntAddsSubscription" runat="server" />--%>
                    </div>
                </td>
            </tr>
            </table>
        </div>
    </div>
</asp:Content>

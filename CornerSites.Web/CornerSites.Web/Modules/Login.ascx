<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="CornerSites.Web.Modules.Login" %>
<%@ Register Namespace="Anthem" Assembly="Anthem" TagPrefix="AnthemCornerSites" %>

<script type="text/javascript">
    $(document).ready(function() {
    ShowPopup();
});
</script>

<div id="boxes">
    <div id="dialog1" class="window">
    <div class="loginpopup" >
    <asp:Panel ID="pnlogin" runat="server" DefaultButton="">
        <div  >     
            <div style="text-align:center;color:#333333">
                Login to Website
            </div>     
            <div style="clear:both"></div>
            <div style="margin-left:61px;padding-bottom:40px;padding-top:19px">
                <div style="float:left" >
                    <span>EmailID </span>
                </div>
                <div style="float:left;padding-left:16px" >
                    <asp:TextBox runat="server" ID="txtLoginID" onkeyup="javascript:return EnterLogin(event)" ></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ValidationGroup="Login"
                        ControlToValidate="txtLoginID" ErrorMessage="*" />
                </div>
            </div>
            <div style="clear:both"></div>
            <div style="margin-left:61px">
                <div style="float:left">
                    <span>Password </span>
                </div>
                <div style="float:left;padding-left:5px">
                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" onkeyup="javascript:return EnterLogin(event)" ></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtPassword"
                            ValidationGroup="Login" ErrorMessage="*" />
                </div>
            </div>
            <div style="clear:both"></div>
            <div style="margin-left:99px;padding-top:9px">
                <asp:CheckBox runat="server" ID="chkRemember" Text="Keep me logged in"></asp:CheckBox>
            </div>
            <div style="clear:both"></div>
            <div style="margin-left:118px">
                    <input type="hidden" id="hdIsEnter" />                        
                    <input type="button" runat="server" id="btnLogin" onfocus="javascript:return DefaultLogin();" 
                        style="height:36px;width:60px" onclick="javascript:return LoginAnthem();" value="Login" />
            </div>
            <div style="clear:both"></div>
            <div style="margin-left:63px;float:left">
                <span>Forgot Password ? <a href="Default.aspx">Click here</a></span>
            </div>
            <div>
                <AnthemCornerSites:Label ID="lblStatus" runat="server"></AnthemCornerSites:Label>
            </div>            
        </div>
    </asp:Panel>
    </div>
    </div>
</div>

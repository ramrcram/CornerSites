<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" 
    CodeBehind="MyAccount.aspx.cs" Inherits="CornerSites.Web.MyAccount" %>
<%@ Register TagPrefix="CornerSites" TagName="ProfileInfo" Src="~/Modules/MyAccount/ProfileInfo.ascx" %>
<%@ Register TagPrefix="CornerSites" TagName="MySuscription" Src="~/Modules/MyAccount/MySubscription.ascx" %>
<%@ Register TagPrefix="CornerSites" TagName="MyAds" Src="~/Modules/MyAccount/MyAds.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-top:50px;padding-bottom:50px">
        <div style="float:left">
            <div id="MyProfileTab" onclick="javascript:return MyProfileTabView('MyProfile');" 
                style="cursor:pointer;height:30px;background-color:#FFF" >
                <div style="height:20px;background-color:#FFF">
                My Profile
                </div>
            </div>
            <div id="UpdateProfileTab" onclick="javascript:return MyProfileTabView('UpdateProfile');" style="cursor:pointer;height:30px;background-color:#FFF" >
                UpdateProfile
            </div>
            <div id="MySubscriptionTab" onclick="javascript:return MyProfileTabView('MySubscription');" style="cursor:pointer;height:30px;background-color:#FFF" >
                My Subscription
            </div>
            <div id="MyAddsTab" onclick="javascript:return MyProfileTabView('MyAdds');" style="cursor:pointer;height:30px;background-color:#FFF" >
                My Adds
            </div>
            <div id="InvoiceTab" onclick="javascript:return MyProfileTabView('Invoice');" style="cursor:pointer;height:30px;background-color:#FFF" >
                Invoice
            </div>
        </div>
        <div style="float:right">
            <div id="MyProfile" style="display:block" >
                <CornerSites:ProfileInfo ID="cntProfileInfo" runat="server" />
            </div>
            <div id="UpdateProfile" style="display:none">
                
            </div>
            <div id="MySubscription" style="display:none">
                <CornerSites:MySuscription ID="cntMySuscription" runat="server" />
            </div>
            <div id="MyAdds" style="display:none">
                <CornerSites:MyAds ID="cntMyAds" runat="server" />
            </div>
            <div id="Invoice" style="display:none">
                
            </div>
        </div>
    </div>
</asp:Content>

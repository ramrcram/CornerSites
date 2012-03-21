<%@ Page Title="Subscription" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" 
        CodeBehind="Subscription.aspx.cs" Inherits="CornerSites.Web.Subscription" %>
<%@ Register TagPrefix="CornerSites"  TagName="Subscription" Src="~/Modules/AddsSubscription.ascx"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div>
        <CornerSites:Subscription ID="cntSubscription" runat="server" />
    </div>
    
</asp:Content>

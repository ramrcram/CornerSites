<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" 
    CodeBehind="Register.aspx.cs" Inherits="CornerSites.Web.Register" %>
<%@ Register TagPrefix="CornerSites"  TagName="Register" Src="~/Modules/Register.ascx"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <CornerSites:Register ID="cntRegister" runat="server"></CornerSites:Register>
    </div>
</asp:Content>

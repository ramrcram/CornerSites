<%@ Page Title="postRequirement" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" 
    CodeBehind="PostRequirement.aspx.cs" Inherits="CornerSites.Web.PostRequirement" %>
<%@ Register TagPrefix="CornerSites" TagName="PostRequirement" Src="~/Modules/PostRequirement.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CornerSites:PostRequirement ID="cntPostRequirement" runat="server" />
</asp:Content>

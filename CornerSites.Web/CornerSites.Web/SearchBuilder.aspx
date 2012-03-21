<%@ Page Title="SearchBuilder" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" 
CodeBehind="SearchBuilder.aspx.cs" Inherits="CornerSites.Web.SearchBuilder" %>
<%@ Register TagPrefix="CornerSites" TagName="SearchBuilder" Src="~/Modules/SearchBuilder.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CornerSites:SearchBuilder ID="cntSearchBuilder" runat="server" />
</asp:Content>

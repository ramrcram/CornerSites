<%@ Page Title="SearchProject" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" CodeBehind="SearchProjects.aspx.cs" Inherits="CornerSites.Web.SearchProjects" %>
<%@ Register TagPrefix="CornerSites" TagName="SearchProject" Src="~/Modules/SearchProjects.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<CornerSites:SearchProject ID="cntSearchProject" runat="server" />
</asp:Content>

<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" 
    CodeBehind="SearchRequirement.aspx.cs" Inherits="CornerSites.Web.SearchRequirement" %>
<%@ Register TagPrefix="CornerSites"   TagName="SearchRequirement" Src="~/Modules/SearchRequirement.ascx"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CornerSites:SearchRequirement ID="cntSearchReqirement" runat="server"></CornerSites:SearchRequirement>
</asp:Content>
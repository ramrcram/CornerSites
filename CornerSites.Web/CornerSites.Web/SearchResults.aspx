<%@ Page Title="CorenerSites :: Search Result" Language="C#" MasterPageFile="~/App_Master/layout.Master" 
 AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="SearchResults.aspx.cs" Inherits="CornerSites.Web.SearchResults" %>
<%@ Register TagPrefix="CornerSites"  TagName="SearchResult" Src="~/Modules/SearchResults.ascx"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CornerSites:SearchResult ID="cntSearchResult" runat="server"></CornerSites:SearchResult>
</asp:Content>

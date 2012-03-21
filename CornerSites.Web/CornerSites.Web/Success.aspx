<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" 
    CodeBehind="Success.aspx.cs" Inherits="CornerSites.Web.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding-bottom:100px" >
        <asp:Literal ID="ltrSuccessMessage" runat="server"></asp:Literal>        
        <div id="dvmessage" runat="server">
        </div>
    </div>
</asp:Content>

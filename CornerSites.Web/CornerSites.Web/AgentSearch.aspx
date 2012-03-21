<%@ Page Title="AgentSearch" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true" 
CodeBehind="AgentSearch.aspx.cs" Inherits="CornerSites.Web.AgentSearch" %>
<%@ Register TagPrefix="CornerSites" TagName="AgentSearch" Src="~/Modules/AgentSearch.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table>
    <tr>
      <td><div class="heading">
          <div class="leftBar"> </div>
          <h2 class="headingText">Agent Search<span></span></h2>
        </div></td>
    </tr>
    <tr>
      <td><CornerSites:AgentSearch ID="cntAgentSearch" runat="server" /></td>
    </tr>
  </table>
</asp:Content>

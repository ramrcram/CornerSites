<%@ Page Title="" Language="C#" MasterPageFile="~/App_Master/layout.Master" AutoEventWireup="true"
    CodeBehind="PaySubscription.aspx.cs" Inherits="CornerSites.Web.SSL.PaySubscription" %>

<%@ Register TagPrefix="CornerSites" TagName="Payment" Src="~/Modules/DirectPayment.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            Amount :  
            <asp:Label ID="lblAmount" runat="server"></asp:Label>
        </div>
        <div style="padding-bottom:50px;" id="dvPayMemet">
            <div>
                <CornerSites:Payment ID="cntPayMemet" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

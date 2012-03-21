<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryWindow.aspx.cs" Inherits="CornerSites.Web.QueryWindow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <div>
                <asp:TextBox ID="txtquery" runat="server" TextMode="MultiLine" Columns="20" 
                    Rows="20" Height="153px" Width="945px"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnquery" runat="server" onclick="btnquery_Click" Text="submit" />
            </div>
        </div>
        <div>
            <asp:GridView ID="gridview" runat="server">
                
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>

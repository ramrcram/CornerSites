<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResidentialPlotFields.ascx.cs"
    Inherits="CornerSites.Web.AdsAdmin.Modules.ResidentialPlotFields" %>
<%@ Register TagPrefix="CornerSites" TagName="PropertyTermsAndConditions" Src="~/AdsAdmin/Modules/PropertyTermsAndConditions.ascx" %>
<%@ Register TagPrefix="CornerSites" TagName="DistanceFromKeyLocations" Src="~/AdsAdmin/Modules/DistanceFromKeyLocations.ascx" %>

<script type="text/javascript" language="javascript">
    $(document).ready(function() {
            
        //Hide (Collapse) the toggle containers on load
        $(".toggle_container").hide();

        //Switch the "Open" and "Close" state per click then slide up/down (depending on open/close state)
        $("h2.trigger").click(function() {
            $(this).toggleClass("active").next().slideToggle("slow");
            return false; //Prevent the browser jump to the link anchor
        });

           }); 
</script>
<div id="divPlot" class="container" >
    <h3>Additional Information</h3>
    <%--Ramesh
        add the symbol for folding up and dropping down--%>
    <h2 class="trigger"><a href="#">Property Features</a></h2>    

   <div class="toggle_container">
	<div class="block">
    <div id="divFeatures">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblConstAge" runat="server" Text="Construction Age"></asp:Label>.
                    <asp:DropDownList ID="ddlConstAge" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblOwnership" runat="server" Text="Ownership"></asp:Label>.
                    <asp:DropDownList ID="ddlOwnership" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <%--<asp:Label ID="lblLandmarks" runat="server" Text="Landmarks & Neighbourhood :[ We strongly recommend you to mention landmark(s) near your property ]"></asp:Label>--%>
                    <asp:Label ID="lblLandmarks" runat="server" Text="Landmarks"></asp:Label>
                    <asp:TextBox ID="txtLandmarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblImage" runat="server" Text="Property Image ( max size 150 KB)"></asp:Label>.
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Label ID="lblTerms" runat="server" Text=" Terms and Conditions (if any)"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </div>
    </div>
    <%--Ramesh
add the symbol for folding up and dropping down--%>
    <h2 class="trigger"><a href="#">Property Terms & conditions</a></h2>    

   <div class="toggle_container">
    <div class="block">    
    <div>
         <CornerSites:PropertyTermsAndConditions ID="PropertyTermsAndConditions1" runat="server" >
        </CornerSites:PropertyTermsAndConditions>
        
    </div>
    </div>
    </div>
    <%--Ramesh
add the symbol for folding up and dropping down--%>
<h2 class="trigger"><a href="#">Distance From key locations</a></h2>    

   <div class="toggle_container">
    <div class="block">    
    <div>
       <CornerSites:DistanceFromKeyLocations ID="cntDistanceFromKeyLocations" runat="server" >
        </CornerSites:DistanceFromKeyLocations>
    </div>    
    </div>
    </div>
</div>
<div class="clear"></div>

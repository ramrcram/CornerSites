<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResidentialHouseVilla.ascx.cs"
    Inherits="CornerSites.Web.AdsAdmin.Modules.ResidentialHouseVilla" %>
<%@ Register TagPrefix="CornerSites" TagName="PropertyTermsAndConditions" Src="~/AdsAdmin/Modules/PropertyTermsAndConditions.ascx" %>
<%@ Register TagPrefix="CornerSites" TagName="DistanceFromKeyLocations" Src="~/AdsAdmin/Modules/DistanceFromKeyLocations.ascx" %>
<%@ Register TagPrefix="CornerSites" TagName="PropertyFeatures" Src="~/AdsAdmin/Modules/PropertyFeatures.ascx" %>
<%@ Register TagPrefix="CornerSites" TagName="Amenities" Src="~/AdsAdmin/Modules/Amenities.ascx" %>

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

<div class="container">
    <div>
        <h2 class="trigger">
            <a href="#">Property Features</a></h2>
        <div class="toggle_container">
            <div class="block">
                <CornerSites:PropertyFeatures ID="cntPropertyFeatures" runat="server" />
            </div>
        </div>
    </div>
    <div>
        <h2 class="trigger">
            <a href="#">Property Terms & conditions</a></h2>
        <div class="toggle_container">
            <div class="block">
                <CornerSites:PropertyTermsAndConditions ID="cntPropertyTermsAndConditions" runat="server">
                </CornerSites:PropertyTermsAndConditions>
            </div>
        </div>
    </div>
    <div>
        <h2 class="trigger">
            <a href="#">Amenties</a></h2>
        <div class="toggle_container">
            <div class="block">
                <CornerSites:Amenities ID="cntAmenities" runat="server" />
            </div>
        </div>
    </div>
    <div>
        <h2 class="trigger">
            <a href="#">Distance From key locations</a></h2>
        <div class="toggle_container">
            <div class="block">
                <CornerSites:DistanceFromKeyLocations ID="cntDistanceFromKeyLocations" runat="server">
                </CornerSites:DistanceFromKeyLocations>
            </div>
        </div>
    </div>
</div>

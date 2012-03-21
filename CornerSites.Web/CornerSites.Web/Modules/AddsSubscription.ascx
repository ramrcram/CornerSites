<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddsSubscription.ascx.cs"
    Inherits="CornerSites.Web.Modules.AddsSubscription" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CornerSites" %>
<%@ Register Namespace="Anthem" Assembly="Anthem" TagPrefix="AnthemCornerSites" %>
<%@ Register  TagName="IndividualsSubscription" TagPrefix="CornerSites" Src="~/Modules/SubscriptionIndividuals.ascx" %>
<%@ Register  TagName="Agents" TagPrefix="CornerSites" Src="~/Modules/SubscriptionAgents.ascx" %>
<%@ Register  TagName="Builders" TagPrefix="CornerSites" Src="~/Modules/SubscriptionBuilders.ascx" %>
<%@ Register  TagName="ServicePack" TagPrefix="CornerSites" Src="~/Modules/SubscriptionServicePack.ascx" %>
<div>
    <div style="padding-top: 20px">
        <CornerSites:TabContainer ID="tbcSubscription" runat="server" ActiveTabIndex="0">            
            <CornerSites:TabPanel ID="tpIndividuals" runat="server" HeaderText="Individuals">
                <ContentTemplate>  
                    <div>
                    <div>
                        <div>
                        <b>
                            Individuals
                        </b> 
                        </div>
                        <div>
                        <CornerSites:IndividualsSubscription ID="cntIndividuals" runat="server" />
                        </div>
                    </div>
                    <div>
                        <div>
                        <b>
                            ServicePack
                        </b> 
                        </div>
                        <div>
                        <CornerSites:ServicePack ID="cntServicePack" runat="server" />
                        </div>                   
                    </div>
                    </div>
                </ContentTemplate>
            </CornerSites:TabPanel>
            <CornerSites:TabPanel ID="tbAgents" runat="server" HeaderText="Agents">
                <ContentTemplate>                
                <div>
                    <div>
                        <div>
                        <b>
                            Agents
                        </b> 
                        </div>
                        <div>
                        <CornerSites:Agents ID="cntAgents" runat="server" />
                        </div>
                    </div>
                    <div>
                        <div>
                        <b>
                            ServicePack
                        </b> 
                        </div>
                        <div>
                        <CornerSites:ServicePack ID="cntAgentServicePack" runat="server" />
                        </div>                   
                    </div>
                    </div>
                </ContentTemplate>
            </CornerSites:TabPanel>
            <CornerSites:TabPanel ID="tbBuilders" runat="server" HeaderText="Builders">
                <ContentTemplate>
                <div>
                    <div>
                        <div>
                        <b>
                            Builders
                        </b> 
                        </div>
                        <div>
                        <CornerSites:Builders ID="cntBuilders" runat="server" />
                        </div>
                    </div>
                    <div>
                        <div>
                        <b>
                            ServicePack
                        </b> 
                        </div>
                        <div>
                        <CornerSites:ServicePack ID="cntBuildersServicepack" runat="server" />
                        </div>                   
                    </div>
                    </div>
                
                </ContentTemplate>
            </CornerSites:TabPanel>
        </CornerSites:TabContainer>
    </div>
</div>
<div>
    <asp:Repeater ID="rptSubscription" runat="server">
        <ItemTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblAdPackageName" runat="server" Text='<%#Eval("AdPackageName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPackageDescription" runat="server" Text='<%#Eval("PackageDescription") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPriceInINR" runat="server" Text='<%#Eval("PriceInINR") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Search.ascx.cs" 
    Inherits="CornerSites.Web.Modules.Search" %>
<%@ Register TagPrefix="CornerSites"  TagName="ResidentialSearch" Src="~/Modules/ResidentialSearch.ascx"  %>
<%@ Register TagPrefix="CornerSites"  TagName="Requirement" Src="~/Modules/SearchRequirement.ascx"  %>
<%@ Register TagPrefix="CornerSites"  TagName="Builder" Src="~/Modules/SearchBuilder.ascx"  %>
<%@ Register TagPrefix="CornerSites"  TagName="Agent" Src="~/Modules/AgentSearch.ascx"  %>
<%@ Register TagPrefix="CornerSites"  TagName="Projects" Src="~/Modules/SearchProjects.ascx"  %>

<div class="formSearch">
    <CornerAjax:TabContainer  ID="tbcSubscription" runat="server" ActiveTabIndex="0" ForeColor="Black" BackColor="White">
                <CornerAjax:TabPanel ID="tbResidentialSearch" runat="server" >
                    <HeaderTemplate>
                        ResidentialSearch
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div style="float:left" >                        
                        <CornerSites:ResidentialSearch ID="cntResidentialSearch" runat="server" />
                        </div>
                    </ContentTemplate>
                </CornerAjax:TabPanel>
                <CornerAjax:TabPanel ID="tbRequirements" runat="server" >
                    <HeaderTemplate>
                    Requirements
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div style="float:left" >
                        <CornerSites:Requirement ID="cntRequirement" runat="server" />
                        </div>
                    </ContentTemplate>                    
                </CornerAjax:TabPanel>
                <CornerAjax:TabPanel ID="tbBuilders" runat="server">
                    <HeaderTemplate>
                    Builders
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div style="float:left" >
                        <CornerSites:Builder ID="cntBuilder" runat="server" />
                        </div>
                    </ContentTemplate>
                </CornerAjax:TabPanel>
                <CornerAjax:TabPanel ID="tbAgents" runat="server">
                    <HeaderTemplate>
                    Agents
                </HeaderTemplate>
                    <ContentTemplate>
                     <div style="float:left" >
                    <CornerSites:Agent ID="cntAgent" runat="server" />
                    </div>
                    </ContentTemplate>
                </CornerAjax:TabPanel>
                <CornerAjax:TabPanel ID="tbprojects" runat="server">
                    <HeaderTemplate>
                    projects
                </HeaderTemplate>
                    <ContentTemplate>
                    <div style="float:left">
                    <CornerSites:Projects ID="cntProjects" runat="server" />
                    </div>
                    </ContentTemplate>
                </CornerAjax:TabPanel>
    </CornerAjax:TabContainer>
</div>

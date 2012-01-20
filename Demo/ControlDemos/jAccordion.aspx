<%@ Page Language="C#" MasterPageFile="~/MasterPages/DemoMaster.master" AutoEventWireup="true" CodeFile="jAccordion.aspx.cs" Inherits="ControlDemos_jAccordion" Title="jAccordion" %>

<%@ Register Assembly="jQuery.NET" Namespace="jQuery.NET.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    .fl-panel { float: left; }
    .marg-left { margin-left: 10px !important; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <cc1:jAccordion ID="JAccordion1" Collapsible="true" CssClass="fl-panel" Width="500px" runat="server" OpenIcon="Gear">
        <TemplatePanel>
            <cc1:jAccordionPanel runat="server" Title="<%# ((AccordionData)Container.DataItem).Title %>">
                <%# ((AccordionData)Container.DataItem).Body %>
            </cc1:jAccordionPanel>
        </TemplatePanel>
    </cc1:jAccordion>
    
    
    <cc1:jAccordion ID="jAccordion2" CssClass="fl-panel marg-left" runat="server" Width="300" AutoHeight="false" DisableIcons="true" StartIndex="1">
        <Panels>
            <cc1:jAccordionPanel ID="panel1" runat="server" Title="Manual Panel 1">
                <p>Manual panels allow you to turn static HTML content...</p>
            </cc1:jAccordionPanel>
            <cc1:jAccordionPanel ID="JAccordionPanel1" runat="server" Title="Manual Panel 2">
                <p>...into accordion content!</p>
            </cc1:jAccordionPanel>
            <cc1:jAccordionPanel ID="JAccordionPanel2" runat="server" Title="Manual Panel 3">
                <ul>
                    <li>Fill</li>
                    <li>your</li>
                    <li>panel</li>
                    <li>with</li>
                    <li>any</li>
                    <li>content</li>
                    <li>you</li>
                    <li>choose.</li>
                </ul>
            </cc1:jAccordionPanel>
        </Panels>
    </cc1:jAccordion>
</asp:Content>


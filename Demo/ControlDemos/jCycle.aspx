<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="jCycle.aspx.cs" Inherits="Demos_Cycle" MasterPageFile="~/MasterPages/DemoMaster.master" Title="jCycle" %>
<%@ Register Assembly="jQuery.NET" Namespace="jQuery.NET.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div style="float:left; margin-right:20px;">
<h2>Image Cycle</h2>
    <cc1:jCycle ID="JCycle1" runat="server" TransitionEffect="cover" FolderPath="~/images/Lunch at the PDC" ClickToAdvance="true" PagerPosition="Top" PrevNextPosition="Top" Width="500" Height="752" DisplayControls="Pager"></cc1:jCycle>
    </div>
    <div style="float:left; width: 300px;">
    <h2>Text Cycle</h2>
    <cc1:jCycle ID="JCycle2" runat="server">
        <ItemTemplate>
        <div>
        <%# Container.DataItem %>
        </div>
        </ItemTemplate>
    </cc1:jCycle>
    </div>
</asp:Content>

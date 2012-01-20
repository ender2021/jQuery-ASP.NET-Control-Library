<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jDualListBox.aspx.cs" Inherits="ControlDemos_jDualListBox" MasterPageFile="~/MasterPages/DemoMaster.master" Title="jDualListBox" %>

<%@ Register Assembly="jQuery.NET" Namespace="jQuery.NET.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <cc1:jDualListBox ID="JDualListBox1" runat="server" Rows="20" Buttons="MoveAll,MoveSelected" ShowFilters="false">
        <asp:ListItem value="501649">2008-2009 "Mini" Baja</asp:ListItem>
        <asp:ListItem value="501497">AAPA - Asian American Psychological Association</asp:ListItem>
        <asp:ListItem value="501053">Academy of Film Geeks</asp:ListItem>
        <asp:ListItem value="500001">Accounting Association</asp:ListItem>
        <asp:ListItem value="501227">ACLU</asp:ListItem>
        <asp:ListItem value="501610">Active Minds</asp:ListItem>
        <asp:ListItem value="501514">Activism with A Reel Edge (A.W.A.R.E.)</asp:ListItem>
        <asp:ListItem value="501656">Adopt a Grandparent Program</asp:ListItem>
        <asp:ListItem value="501050">Africa Awareness Student Organization</asp:ListItem>
        <asp:ListItem value="501075">African Diasporic Cultural RC Interns</asp:ListItem>
        <asp:ListItem value="501493">Agape</asp:ListItem>
        <asp:ListItem value="501562">AGE-Alliance for Graduate Excellence</asp:ListItem>
        <asp:ListItem value="500676">AICHE (American Inst of Chemical Engineers)</asp:ListItem>
        <asp:ListItem value="501460">AIDS Sensitivity Awareness Project ASAP</asp:ListItem>
        <asp:ListItem value="500004">Aikido Club</asp:ListItem>
        <asp:ListItem value="500336">Akanke</asp:ListItem>
        </cc1:jDualListBox>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit!" />
        <div>
            <asp:Repeater ID="rptrYouPicked" runat="server" Visible="false">
                <HeaderTemplate><p>You Selected:</p><ul></HeaderTemplate>
                <ItemTemplate><li><%# PrintItem(Container.DataItem) %></li></ItemTemplate>
                <FooterTemplate></ul></FooterTemplate>
            </asp:Repeater>
        </div>
</asp:Content>
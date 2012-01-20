<%@ Page Language="C#" MasterPageFile="~/MasterPages/DemoMaster.master" AutoEventWireup="true" CodeFile="jAutocomplete.aspx.cs" Inherits="ControlDemos_jAutocomplete" Title="jAutocomplete" %>

<%@ Register Assembly="jQuery.NET" Namespace="jQuery.NET.Controls"
    TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    ul,li { list-style: none; margin: 0px; padding: 0px; display: block; }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <cc1:jAutocomplete ID="JAutocomplete1" UITheme="MintChoc" Width="500" DataSourceUrl="~/ajax.ashx?action=autocomplete" runat="server" />

</asp:Content>


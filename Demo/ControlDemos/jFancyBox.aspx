<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/DemoMaster.master" AutoEventWireup="true" CodeFile="jFancyBox.aspx.cs" Inherits="ControlDemos_jFancyBox" %>
<%@ Register Assembly="jQuery.NET" Namespace="jQuery.NET.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>You can do a simple image fancybox:</p>
<cc1:jFancyBox ID="JFancyBox8" runat="server" ContentUrl="~/Images/Lunch At The PDC/117.jpg" BoxType="Image"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Lunch At The PDC/117.jpg" Height="83" Width="125" /></cc1:jFancyBox>
<br /><br />

<cc1:jFancyBox ID="jfb1" runat="server" ContentUrl="~/Images/Hula Power/130.jpg" BoxType="Image" GroupName="HulaPower">Or you</cc1:jFancyBox>
<cc1:jFancyBox ID="JFancyBox1" runat="server" ContentUrl="~/Images/Hula Power/131.jpg" BoxType="Image" GroupName="HulaPower">can link</cc1:jFancyBox>
<cc1:jFancyBox ID="JFancyBox2" runat="server" ContentUrl="~/Images/Hula Power/132.jpg" BoxType="Image" GroupName="HulaPower">several together</cc1:jFancyBox>
<cc1:jFancyBox ID="JFancyBox3" runat="server" ContentUrl="~/Images/Hula Power/133.jpg" BoxType="Image" GroupName="HulaPower">to form</cc1:jFancyBox>
<cc1:jFancyBox ID="JFancyBox4" runat="server" ContentUrl="~/Images/Hula Power/134.jpg" BoxType="Image" GroupName="HulaPower">a gallery.</cc1:jFancyBox>

<br /><br />

<cc1:jFancyBox ID="JFancyBox5" runat="server" BoxType="Content" FancyBoxContentID="jfbc1">Fancybox some HTML content!</cc1:jFancyBox>
<br /><br />

<cc1:jFancyBox ID="JFancyBox7" runat="server" BoxType="AjaxContent" ContentUrl="~/ajax.ashx?action=ajax-content">Use Ajax content!</cc1:jFancyBox>
<br /><br />

<cc1:jFancyBox ID="JFancyBox9" runat="server" BoxType="Iframe" ContentUrl="http://fancybox.net/">Iframe, Uframe, we all frame for Iframes!</cc1:jFancyBox>
<br /><br />

<cc1:jFancyBox ID="JFancyBox6" runat="server" BoxType="YouTube" ContentUrl="http://www.youtube.com/watch?v=d5mK7dzyUkM">You can even YouTube!</cc1:jFancyBox>


<cc1:jFancyBoxContent ID="jfbc1" runat="server">
    <h1>FANCY</h1>
    <p>I can put whatever I want in here, because I'm fancy that way.</p>
    <asp:Image runat="server" ImageUrl="~/Images/Lunch At The PDC/109.jpg" />
</cc1:jFancyBoxContent>
</asp:Content>


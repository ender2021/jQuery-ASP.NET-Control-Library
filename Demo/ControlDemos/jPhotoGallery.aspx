<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="jPhotoGallery.aspx.cs" Inherits="_Default" MasterPageFile="~/MasterPages/DemoMaster.master" Title="jPhotoGallery" %>
<%@ Register Assembly="jQuery.NET" Namespace="jQuery.NET.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <cc1:jPhotoGallery ID="JPhotoGallery1" runat="server" Height="600" Width="600" 
            FolderPath="~/Images/Lunch at the PDC/" />
</asp:Content>

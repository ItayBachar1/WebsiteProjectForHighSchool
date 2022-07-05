<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <center>
<h1><b><u><i>Deatails</i></u></b></h1>
<br />
<br />
<table>
<tr>
<td class="style4">Product's Id:</td>
<td class="style4">
    <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td class="style3">Product's Name:</td>
<td class="style3">
    <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td class="style2">Product's Price:</td>
<td class="style2">
    <asp:Label ID="lblmyprice" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td class="style1">Product's Kind:</td>
<td class="style1">
    <asp:Label ID="lblcompany" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td class="style5">Product's Image:</td>
<td class="style5">
    <asp:Image ID="imgproduct" runat="server" Height="184px" Width="230px" />
    </td>
</tr>
</table>

<br /> <br /><br /><br /><font color="olive"><a href="Order.aspx">Back to orders.</a></font>
</center>
</asp:Content>


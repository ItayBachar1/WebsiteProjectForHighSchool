<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="DeliveryDetails.aspx.cs" Inherits="DeliveryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h1 style="color:Black"><b><i><u>Delivery Details</u></i></b></h1>
<br /><br />
<table>
<tr>
<td>
    <asp:Label ID="lbl1" runat="server" Text="Delivery's Id:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lbliddelivery" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl2" runat="server" Text="Driver's Id:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lbliddriver" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>Client's Id:</td>
<td><asp:Label ID="lblidclient" runat="server" Text=""></asp:Label></td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl3" runat="server" Text="Order's Id:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblidorder" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl4" runat="server" Text="Car's Id:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblidcar" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl5" runat="server" Text="Date Of Delivery:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lbldateofdelivery" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl11" runat="server" Text="Delivery's Status:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lbldeliverystatus" runat="server" Text=""></asp:Label>
    </td>
    </tr>
    </table>
</center>
</asp:Content>


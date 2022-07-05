<%@ Page Title="Client Data" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="ClientDetails.aspx.cs" Inherits="ClientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h1 style="color:Black"><b><i><u>Show client details</u></i></b></h1>
<br /><br />
<table>
<tr>
<td>
    <asp:Label ID="lbl1" runat="server" Text="ID:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblidclient" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl2" runat="server" Text="Name:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblfullname" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl3" runat="server" Text="Email:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblemail" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl4" runat="server" Text="Phone:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblphone" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl7" runat="server" Text="City:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblcity" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl8" runat="server" Text="Address:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl9" runat="server" Text="Address' Number:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblnumaddress" runat="server" Text=""></asp:Label>
    </td>
</tr>
</table>
</center>
</asp:Content>


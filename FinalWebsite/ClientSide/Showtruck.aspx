<%@ Page Title="Show Truck" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Showtruck.aspx.cs" Inherits="Showtruck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h1 style="color:Black"><b><i><u>Show Truck</u></i></b></h1>
<br /><br />
<table>
<tr>
<td>
    <asp:Label ID="lbl1" runat="server" Text="Truck's Id:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblidcar" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl2" runat="server" Text="Truck's Name:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblnamecar" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl3" runat="server" Text="Track's Capacity:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblcarcapacity" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl4" runat="server" Text="Track's Image:"></asp:Label>
    </td>
<td>
    <asp:Image ID="pic" runat="server" Height="117px" Width="156px" />
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="Label5" runat="server" Text="Truck's Status:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblcarstatus" runat="server" Text=""></asp:Label>
    </td>
</tr>
</table>
</center>
</asp:Content>


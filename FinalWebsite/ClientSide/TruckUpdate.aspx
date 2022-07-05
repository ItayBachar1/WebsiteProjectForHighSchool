<%@ Page Title="Update Truck" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="TruckUpdate.aspx.cs" Inherits="TruckUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<h1 style="color:Black"><b><i><u>Update A Truck</u></i></b></h1>
<br /><br />
<table>
<tr>
<td>
    <asp:Label ID="lbl1" runat="server" Text="Truck's ID:"></asp:Label>
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
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl3" runat="server" Text="Truck's Capacity:"></asp:Label>
    </td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtcapa" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtcapa" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl9" runat="server" Text="Truck's Image:"></asp:Label>
    </td>
<td>
    <asp:Image ID="piccar" runat="server" Height="117px" Width="156px" />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    </td>
</tr>
<tr>
<td>Truck's Status:</td>
<td>
    <asp:DropDownList ID="DropDownList4" runat="server">
        <asp:ListItem Value="0">active</asp:ListItem>
        <asp:ListItem Value="1">not active</asp:ListItem>
        <asp:ListItem Value="2">sold</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr><td>
    <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
        Text="Update Truck" />
    </td>
    </tr>
    </table>
    <br /> <a href="Searchtruck.aspx" style="font-weight: bolder; font-size: large;">Click to see more trucs </a><br /><br />

    </center>
</asp:Content>


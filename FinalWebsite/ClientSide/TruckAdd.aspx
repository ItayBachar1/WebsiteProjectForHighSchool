<%@ Page Title="Add A Truck" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="TruckAdd.aspx.cs" Inherits="TruckAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1 style="color:Black"><b><u>Add A Truck</u></b></h1>
<br />
<br />
<table>
<tr>
<td>
    <asp:Label ID="lblcarpic" runat="server" Text="Track's Image:"></asp:Label>
    </td>
<td class="style1">
    <asp:Image ID="Image1" runat="server" Height="144px" Width="137px" 
        ImageUrl="~/pic/truck.jpg" />
    <br />

    <asp:FileUpload ID="FileUpload1" runat="server" />

    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lblcarcapacity" runat="server" Text="Track's Capacity:"></asp:Label>
    </td>
<td class="style1">
    <asp:TextBox ID="txtcarcapacity" runat="server" Height="39px" Width="186px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtcarcapacity" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lblcarname" runat="server" Text="Truck's Name:"></asp:Label>
    </td>
<td class="style1">
    <asp:TextBox ID="txtcaname" runat="server" Height="39px" Width="193px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtcaname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    </td>
</tr>
    <tr>
    <td>
    
        <asp:Button ID="btnadd" runat="server" Text="Add Truck" onclick="btnadd_Click" />
    
    </td>
    </tr>
</table>
</center>
</asp:Content>


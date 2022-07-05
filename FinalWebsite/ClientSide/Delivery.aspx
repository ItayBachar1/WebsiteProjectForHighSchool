<%@ Page Title="Add A Delivery" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Delivery.aspx.cs" Inherits="Delivery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center><h1 style="color:Black"><b><u>Add Delivery</u></b></h1>
<br />
<br />
<table>
<tr>
<td> Driver's ID: </td>
<td class="style1">
    <asp:Label ID="lbldriver" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>Client's Id:</td>
<td class="style1">
    <asp:Label ID="lblidclient" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td> Order's ID: </td>
<td class="style1">
    <asp:Label ID="lblidorder" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lblcarname" runat="server" Text="Truck's Name:"></asp:Label>
    <asp:Label ID="lblerror" runat="server"></asp:Label>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtcarname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    </td>
<td class="style1">
    <asp:TextBox ID="txtcarname" runat="server" Height="39px" Width="193px"></asp:TextBox>
    </td>
</tr>
<tr>
<td>Delivery's Date:</td>
<td><asp:Label ID="lbldateofdelivery" runat="server" Text=""></asp:Label></td>
</tr>
 <br />
    <br />
    <tr>
    <td>
    
        <asp:Button ID="btnadd" runat="server" Text="Add a Delivery" onclick="btnadd_Click" />
    
    </td>
    </tr>
</table>
</center>
</asp:Content>


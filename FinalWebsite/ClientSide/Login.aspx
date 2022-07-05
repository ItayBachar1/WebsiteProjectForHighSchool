<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<h1><b><U>Login</U></b></h1>
<br />
<table>
<tr>
<td>
    <asp:Label ID="lbluser" runat="server" Text="id"></asp:Label>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtpass" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    </td>
<td>
    <asp:TextBox ID="txtuser" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lblpass" runat="server" Text="password"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtpass" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    </td>
<td>
    <asp:TextBox ID="txtpass" TextMode="Password" runat="server"></asp:TextBox>
    </td>
</tr>
<br />
<br />
<br />
<tr><td colspan="2">
    <asp:Button ID="btnlog" runat="server" Text="Login" onclick="btnlog_Click" 
        Width="236px" />
    </td></tr>
</table>











</center>
</asp:Content>


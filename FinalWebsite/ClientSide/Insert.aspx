<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Insert.aspx.cs" Inherits="Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
 <center><h1>Insert</h1>
<br />

<form action="Insert.aspx">

<table>
<tr>
<td> ID:</td>
<td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtid" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtid" runat="server"></asp:TextBox></td>
     <td><asp:Label ID="lbl_clientidError" runat="server" style="color:red; margin-left:5px" 
                        Font-Bold="True" Font-Italic="True" Font-Names="Gisha" Font-Overline="False" 
                        Font-Underline="True" ForeColor="#CC3300"></asp:Label></td>
</tr>

<tr>
<td> Firstname:</td>
<td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Lastname:</td>
<td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtlastname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Password:</td>
<td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtpass" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtpass" TextMode="Password" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td class="style1"> City:</td>
    <td class="style1">
        <asp:DropDownList ID="city"  runat="server" Height="22px" Width="128px" 
                     >
            <asp:ListItem Value="0">בחר עיר</asp:ListItem>
                </asp:DropDownList>
    </td>
     <td><asp:Label ID="lbl_cityError" runat="server" style="color:red; margin-left:5px" 
                        Font-Bold="True" Font-Italic="True" Font-Names="Gisha" Font-Overline="False" 
                        Font-Underline="True" ForeColor="#CC3300"></asp:Label></td>
</tr>

<tr>
<td> Street:</td>
<td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtstreet" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtstreet" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Number Street:</td>
<td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtnum" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtnum" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Phone:</td>
<td>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtphone" ErrorMessage="Write phone like 03-5555555" 
        ValidationExpression="0\d-\d\d\d\d\d\d\d"></asp:RegularExpressionValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtphone" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtphone" runat="server"></asp:TextBox></td>
</tr>
       
       <tr>
<td> Birth:</td>
<td>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="txtBirth" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtBirth" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Mail:</td>
<td>
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="txtmail" ErrorMessage="Write like example@example.com" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="txtmail" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtmail" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Image:</td>
<td>
                <asp:Image ID="img" runat="server" Height="85px" Width="94px" ImageUrl="~/images/11.jpg"/><br />
                <asp:FileUpload ID="image" runat="server" />
            </td>
</tr>

<tr>
<td> Level:</td>
<td>
    <asp:DropDownList ID="txtlevel" runat="server">
    <asp:ListItem Value="client">Client</asp:ListItem>
    <asp:ListItem Value="Worker">Worker</asp:ListItem>
    <asp:ListItem Value="Admin">Admin</asp:ListItem>
    </asp:DropDownList>
</td>
</tr>

<tr>
<td></td>
<td>
    <asp:Button ID="btnadd" runat="server" Text="Add new client" 
        onclick="BtnInsert_Click" /></td>
</tr>

</table>
</form>


</center>

</asp:Content>


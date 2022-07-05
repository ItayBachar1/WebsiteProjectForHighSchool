<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Reg.aspx.cs" Inherits="Reg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
 <center><h1>Register</h1>
<br />

<form action="Reg.aspx">
<table>
<tr>
<td> ID:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="pass" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="id" runat="server"></asp:TextBox></td>
    <td><asp:Label ID="lbl_clientidError" runat="server" style="color:red; margin-left:5px" 
                        Font-Bold="True" Font-Italic="True" Font-Names="Gisha" Font-Overline="False" 
                        Font-Underline="True" ForeColor="#CC3300"></asp:Label></td>
</tr>
<tr>
<td> Firstname:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="name" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="name" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Lastname:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="lastname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="lastname" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Pass:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
        ControlToValidate="pass" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="pass" TextMode="Password" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td class="style1"> City:</td>
    <td class="style1">
        <asp:DropDownList ID="city"  runat="server" Height="22px" Width="128px" onselectedindexchanged="city_SelectedIndexChanged">
            <asp:ListItem>&#1489;&#1495;&#1512; &#1506;&#1497;&#1512;</asp:ListItem>
                </asp:DropDownList>
    </td>
    <td><asp:Label ID="lbl_cityError" runat="server" style="color:red; margin-left:5px" 
                        Font-Bold="True" Font-Italic="True" Font-Names="Gisha" Font-Overline="False" 
                        Font-Underline="True" ForeColor="#CC3300"></asp:Label></td>
    
</tr>

<tr>
<td> Address:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="street" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="street" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Street Num:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="num" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="num" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Phone:</td>
<td>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="phone" ErrorMessage="Write phone like 03-555555" 
        ValidationExpression="0\d-\d\d\d\d\d\d\d"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="phone" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="phone" runat="server"></asp:TextBox></td>
</tr>
       
       <tr>
<td> Birthday:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="Birth" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="Birth" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td> Mail:</td>
<td>
     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ControlToValidate="txtmail" ErrorMessage="Write like example@example.com" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="txtmail" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtmail" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Image</td>
<td>
                <asp:Image ID="img" runat="server" Height="85px" Width="94px" ImageUrl="~/images/11.jpg"/><br />
                <asp:FileUpload ID="image" runat="server" />
            </td>
</tr>

<tr>
<td></td>
<td>
    <asp:Button ID="btnadd" runat="server" Text="Add new client" 
        onclick="BtnReg_Click" /></td>
</tr>

</table>
</form>


</center>

</asp:Content>


<%@ Page Title="Update Stock" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="UpdateProducts.aspx.cs" Inherits="UpdateProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<h1>  Update, Delete & Restore Products</h1>
<br /><br />
<table>
<tr>
<td>
    <asp:Label ID="lbl1" runat="server" Text="Product's ID:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl2" runat="server" Text="Product's Name:"></asp:Label>
    </td>
<td>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl3" runat="server" Text="Product's Kind:"></asp:Label>
    </td>
<td>
    <asp:DropDownList ID="Kind" runat="server">
        <asp:ListItem Value="0">Chose A Kind</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl4" runat="server" Text="Product's Minimum Amount:"></asp:Label>
    </td>
<td>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
        runat="server" ControlToValidate="txtminamount" 
        ErrorMessage="&nbsp;Numbers only" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtminamount" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtminamount" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl5" runat="server" Text="Product's Maximum Amount:"></asp:Label>
    </td>
<td>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
        runat="server" ControlToValidate="txtmaxamount" 
        ErrorMessage="&nbsp;Numbers only" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtmaxamount" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtmaxamount" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl6" runat="server" Text="Product's Current Amount:"></asp:Label>
    </td>
<td>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" 
        runat="server" ControlToValidate="txtcurrentamount" 
        ErrorMessage="&nbsp;Numbers only" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtcurrentamount" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtcurrentamount" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl7" runat="server" Text="Product's Consumer Price:"></asp:Label>
    </td>
<td>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" 
        runat="server" ControlToValidate="txtconsumerprice" 
        ErrorMessage="&nbsp;Numbers only" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtconsumerprice" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtconsumerprice" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl10" runat="server" Text="Product's Cost:"></asp:Label>
    </td>
<td>
  <asp:RegularExpressionValidator ID="RegularExpressionValidator6" 
        runat="server" ControlToValidate="txtcost" 
        ErrorMessage="&nbsp;Numbers only" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtcost" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtcost" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl8" runat="server" Text="Product's Supplier:"></asp:Label>
    </td>
<td>
    <asp:DropDownList ID="Supplier" runat="server">
        <asp:ListItem Value="0">Chose A Supplier</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl9" runat="server" Text="Product's Image:"></asp:Label>
    </td>
<td>
    <asp:Image ID="pic" runat="server" Height="117px" Width="156px" />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    </td>
</tr>

<tr>
<td>
    <asp:Label ID="lbl11" runat="server" Text="Product's Status:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr><td></td></tr>
<tr><td></td></tr>
<tr>
<td>
    <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
        Text="Update" />
    </td>
<td>
    <asp:Button ID="btndelete" runat="server" Text="Delete" 
        onclick="btndelete_Click" />
    </td>
    <td>
        <asp:Button ID="btnrestore" runat="server" Text="Rstore" 
            onclick="btnrestore_Click" />
    </td>
</tr>
</table>
</center>
</asp:Content>
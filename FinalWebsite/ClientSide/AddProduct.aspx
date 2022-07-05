<%@ Page Title="Add A Product" Language="C#" MasterPageFile="Design.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
 <center><b><font size="42px">Add A New Product</font></b>
<br />

<form action="AddNewProduct.aspx">

<table style="background-color:Black" >
<tr>
<td>Product ID:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtid" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtid" runat="server"></asp:TextBox></td>
    <td><asp:Label ID="lbl_pidError" runat="server" style="color:red; margin-left:5px" 
                        Font-Bold="True" Font-Italic="True" Font-Names="Gisha" Font-Overline="False" 
                        Font-Underline="True" ForeColor="#CC3300"></asp:Label></td>
</tr>

<tr>
<td>Product Name:</td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td class="style1">Kind: </td>
    <td class="style1">
        <asp:DropDownList ID="kind"  runat="server" Height="22px" Width="128px">

            <asp:ListItem Selected="True" Value="0">Choose A Kind</asp:ListItem>
                </asp:DropDownList>
    </td>
    
</tr>

<tr>
<td>Minimum Amount:</td>
<td>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtminamount" 
ErrorMessage="&nbsp;Numbers only please" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtminamount" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtminamount" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Maximum Amount:</td>
<td>
<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtmaxamount" 
ErrorMessage="&nbsp;Numbers only please" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtmaxamount" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtmaxamount" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Current Amount:</td>
<td>
<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtcurrent" 
ErrorMessage="&nbsp;Numbers only please" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtcurrent" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtcurrent" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Consumer Price:</td>
<td>
<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtconsumerprice" 
ErrorMessage="&nbsp;Numbers only please" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtconsumerprice" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtconsumerprice" runat="server"></asp:TextBox></td>
</tr>

<tr>
<td>Cost:</td>
<td>
<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtcost" 
ErrorMessage="&nbsp;Numbers only" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtcost" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtcost" runat="server"></asp:TextBox></td>
</tr>
       
<tr>
<td class="style1">Supplier ID:</td>
    <td class="style1">
        <asp:DropDownList ID="supid"  runat="server" Height="22px" Width="128px">

            <asp:ListItem Value="0">Choose A Supplier</asp:ListItem>
                </asp:DropDownList>
    </td>
    
</tr>

<tr>
<td>Image:</td>
<td>
                <asp:Image ID="img" runat="server" Height="85px" Width="94px" ImageUrl="~/pic/product/11.gif"/><br />
                <asp:FileUpload ID="image" runat="server" />
            </td>
</tr>

<tr>
<td></td>
<td>
    <asp:Button ID="btnadd" runat="server" Text="Add A Product" 
        onclick="BtnInsert_Click" /></td>
</tr>

</table>
</form>


</center>
</asp:Content>
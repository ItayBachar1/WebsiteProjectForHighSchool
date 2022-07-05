<%@ Page Title="Update" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Update.aspx.cs" Inherits="Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<h1 style="color:Black"><b><i><u>Update</u></i></b></h1>
<br /><br />
<table>
<tr>
<td>
    <asp:Label ID="lbl1" runat="server" Text="Id:"></asp:Label>
    </td>
<td>
    <asp:Label ID="lblid" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl4" runat="server" Text="New Password:"></asp:Label>
    </td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtnewpass" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtnewpass" TextMode="Password" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl7" runat="server" Text="Email:"></asp:Label>
    </td>
<td>
    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" 
        ControlToValidate="txtemail" ErrorMessage="Write like asd@gmail.com" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtemail" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl8" runat="server" Text="Phone:"></asp:Label>
    </td>
<td>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
        ControlToValidate="txtphone" ErrorMessage="Write phone like 03-5555555" 
        ValidationExpression="0\d-\d\d\d\d\d\d\d"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtphone" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
<td>
    <asp:Label ID="lbl9" runat="server" Text="City:"></asp:Label>
    </td>
<td>
    <asp:DropDownList ID="cities" runat="server">
        <asp:ListItem>Choose city</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td>

    <asp:Label ID="lbl10" runat="server" Text="Address:"></asp:Label>
    </td>
<td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtaddress" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
    <asp:Label ID="lbl11" runat="server" Text="Address' Number:"></asp:Label>
    </td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtnumaddress" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtnumaddress" runat="server"></asp:TextBox>
    </td>
</tr>
<tr>
<td>
          
    <asp:Label ID="lbl5" runat="server" Text="First Name:"></asp:Label>
    </td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtname" runat="server" ></asp:TextBox>
    </td>
</tr>


<tr>
<td>

    <asp:Label ID="lbl6" runat="server" Text="Last Name:"></asp:Label>
    </td>
<td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="txtlastname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    <asp:TextBox ID="txtlastname" runat="server" ></asp:TextBox>
    </td>
</tr>


<tr>
<td>
<asp:Label ID="lbl12" runat="server" Text="Image:"></asp:Label>
</td>
<td> 
<asp:Image ID="img" ImageUrl="~/pic/users/11.jpg" runat="server" Height="74px" 
        Width="97px"/>
 <asp:FileUpload ID="f" runat="server" />
</td>
</tr>


<tr><td>
    <asp:Button ID="btnupdate" runat="server" Text="Update" onclick="btnupdate_Click" />
    </td></tr>

</table>
</center>
</asp:Content>
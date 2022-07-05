<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="UpdateDelivery.aspx.cs" Inherits="UpdateDelivery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<h1><b><i><u>Update Delivery</u></i></b></h1>
<table>
<tr>
<td>Delivery's Id:</td>
<td>  
<asp:Label ID="lbliddelivery" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td>Order's Id:</td>
<td>  
<asp:Label ID="lblidorder" runat="server" Text=""></asp:Label>
</td>
</tr>
<tr>
<td>Driver's Id:</td>
<td>
    
    <asp:Label ID="lbliddriver" runat="server" Text=""></asp:Label>
    
    </td>
</tr>
<tr>
<td>Client's Id:</td>
<td>  
    <asp:Label ID="lblidclient" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
<td>Car's Name:</td>
<td>
    <asp:TextBox ID="txtcarname" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtcarname" ErrorMessage="Empty"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
<td>Delivery Date:</td>
<td>
 <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
</td>
</tr>
<%--<tr>
<td >Date of delivery:</td>
<td>
    <asp:DropDownList ID="Days" runat="server" Width="51px" Height="16px">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
        <asp:ListItem Value="5">5</asp:ListItem>
        <asp:ListItem Value="6">6</asp:ListItem>
        <asp:ListItem Value="7">7</asp:ListItem>
        <asp:ListItem Value="8">8</asp:ListItem>
        <asp:ListItem Value="9">9</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="11">11</asp:ListItem>
        <asp:ListItem Value="12">12</asp:ListItem>
        <asp:ListItem Value="13">13</asp:ListItem>
        <asp:ListItem Value="14">14</asp:ListItem>
        <asp:ListItem Value="15">15</asp:ListItem>
        <asp:ListItem Value="16">16</asp:ListItem>
        <asp:ListItem Value="17">17</asp:ListItem>
        <asp:ListItem Value="18">18</asp:ListItem>
        <asp:ListItem Value="19">19</asp:ListItem>
        <asp:ListItem Value="20">20</asp:ListItem>
        <asp:ListItem Value="21">21</asp:ListItem>
        <asp:ListItem Value="22">22</asp:ListItem>
        <asp:ListItem Value="23">23</asp:ListItem>
        <asp:ListItem Value="24">24</asp:ListItem>
        <asp:ListItem Value="25">25</asp:ListItem>
        <asp:ListItem Value="26">26</asp:ListItem>
        <asp:ListItem Value="27">27</asp:ListItem>
        <asp:ListItem Value="28">28</asp:ListItem>
        <asp:ListItem Value="29">29</asp:ListItem>
        <asp:ListItem Value="30">30</asp:ListItem>
        <asp:ListItem Value="31">31</asp:ListItem>
    </asp:DropDownList>
    </td>
    <td class="style2">
        <asp:DropDownList ID="Months" runat="server">
        <asp:ListItem>01</asp:ListItem>
        <asp:ListItem>02</asp:ListItem>
        <asp:ListItem>03</asp:ListItem>
        <asp:ListItem>04</asp:ListItem>
        <asp:ListItem>05</asp:ListItem>
        <asp:ListItem>06</asp:ListItem>
        <asp:ListItem>07</asp:ListItem>
        <asp:ListItem>08</asp:ListItem>
        <asp:ListItem>09</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        </asp:DropDownList>
    </td>
</tr>--%>
<tr>
<td>Repair's Status:</td>
<td>
    <asp:DropDownList ID="DropDownList4" runat="server">
        <asp:ListItem Value="0">shipped</asp:ListItem>
        <asp:ListItem Value="1">no shipped</asp:ListItem>
        <asp:ListItem Value="2">arrived</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
<tr><td>
    <asp:Button ID="btnadd" runat="server" Text="Update Delivery" 
        onclick="btnadd_Click"/>
    </td></tr>
</table>
</center>
</asp:Content>


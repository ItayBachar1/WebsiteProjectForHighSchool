<%@ Page Title="Search A Product" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="SearchProducts.aspx.cs" Inherits="SearchProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 268435376px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<b><font color="blue" size="42px">Search A Product</font></b>
<br />
<br />
<table>
<tr>
<td colspan="3">
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Selected="True" Value="0">All Products</asp:ListItem>
        <asp:ListItem Value="1">On The Shop</asp:ListItem>
        <asp:ListItem Value="2">ID</asp:ListItem>
        <asp:ListItem Value="3">Name</asp:ListItem>
        <asp:ListItem Value="4">Current Amount</asp:ListItem>
        <asp:ListItem Value="5">Consumer Price</asp:ListItem>
        <asp:ListItem Value="6">Cost</asp:ListItem>
    </asp:DropDownList>
    </td>
<td>
    <asp:TextBox ID="txtsearch" runat="server" Height="44px" Width="152px"></asp:TextBox>
    </td>
<td>
    <asp:Button ID="btnsearch" runat="server" Text="Search" 
        onclick="btnsearch_Click" />
    </td>
    <tr>
<td></td>
<td> </td>
<td>
</td>
<td>
    <asp:Label ID="lblmes" runat="server" Text="The Product Does Not Exist" 
        BorderColor="Black" BackColor="White" Font-Size="X-Large" Font-Bold="True" 
        ForeColor="Black"></asp:Label>
    </td>
</tr>
</table>
<br />
<div style="overflow:scroll;">
    <asp:GridView ID="GridView1" runat="server" EnableModelValidation="True" 
        AllowPaging="True" AutoGenerateColumns="False"  PageSize="3" 
        onpageindexchanging="GridView1_PageIndexChanging1" 
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" ForeColor="Black" GridLines="None" >
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:TemplateField HeaderText="Show">
                <ItemTemplate>
                    <asp:Button ID="btnshow" runat="server" Text="Show" onclick="btnshow_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ProductID" HeaderText="ID" />
            <asp:BoundField DataField="ProductName" HeaderText="Name" />
            <asp:BoundField DataField="KindID" HeaderText="Kind" />
            <asp:BoundField DataField="MinAmount" HeaderText="Minimum Amount" />
            <asp:BoundField DataField="MaxAmount" HeaderText="Maximum Amount" />
            <asp:BoundField DataField="CurrentAmount" HeaderText="Current Amount" />
            <asp:BoundField DataField="ConsumerPrice" HeaderText="Consumer Price" />
            <asp:BoundField DataField="Cost" HeaderText="Cost" />
            <asp:BoundField DataField="SupID" HeaderText="Supplier" />
            <asp:TemplateField HeaderText="Product's Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="70px" 
                        ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Picture","pic/product/{0}") %>' 
                        Width="150px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Status" HeaderText="On The Shop" />
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
            HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    </asp:GridView>
    </div>
<br />
</center>
</asp:Content>
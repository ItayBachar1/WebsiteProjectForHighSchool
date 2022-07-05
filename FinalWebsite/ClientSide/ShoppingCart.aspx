<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<h1><b><u><i>Shopping Cart</i></u></b></h1>
<br />
<br />
    <asp:GridView ID="shopcart" runat="server" CellPadding="4" 
        EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
        AutoGenerateColumns="False" 
        onselectedindexchanged="shopcart_SelectedIndexChanged" 
        onrowcancelingedit="shopcart_cancelcommand">
      
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Remove" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="Product's Id" HeaderText="Product's Id" />
            <asp:BoundField DataField="Product's Name" HeaderText="Product's Name" />
            <asp:BoundField DataField="Product's Price" HeaderText="Product's Price" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Total Price" HeaderText="Total Price" />
            <asp:TemplateField HeaderText="Prodct's Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="68px" 
                        ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Image","pic/product/{0}") %>' 
                        Width="75px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>

    <br /><br /><br />
   <h1> <a href="AddOrder.aspx">Order</a> </h1>
</center>
</asp:Content>


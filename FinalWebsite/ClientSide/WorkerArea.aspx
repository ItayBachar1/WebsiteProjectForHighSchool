<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="WorkerArea.aspx.cs" Inherits="WorkerArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 style="font-size: xx-large; font-weight: normal">Your Area</h1>

<a href="Update.aspx" style="font-weight: bolder; font-size: large;">Update your details</a><br /><br />
<a href="AddProduct.aspx" style="font-weight: bolder; font-size: large;">Add Product to the Website</a> <br /><br />
<a href="SearchProducts.aspx" style="font-weight: bolder; font-size: large;">Search Products</a> <br /><br />
<a href="Order.aspx" style="font-weight: bolder; font-size: large;">Order</a> <br /><br />
<a href="SearchOrder.aspx" style="font-weight: bolder; font-size: large;">Search your order</a> <br /><br />
<a href="TruckAdd.aspx" style="font-weight: bolder; font-size: large;">Add truck</a> <br /><br />
<a href="TruckUpdate.aspx" style="font-weight: bolder; font-size: large;">Update truck</a><br /><br />
<a href="Searchtruck.aspx" style="font-weight: bolder; font-size: large;">Search truck</a> <br /><br />
<a href="DeliverySearch.aspx" style="font-weight: bolder; font-size: large;">Search delivery</a><br /><br />
<a href="UpdateDelivery.aspx" style="font-weight: bolder; font-size: large;">Update delivery</a><br /><br />



<center>
  <asp:GridView ID="delivery" runat="server" 
            AutoGenerateColumns="False" style="margin-left: 0px" 
        onselectedindexchanged="delivery_SelectedIndexChanged" BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Horizontal" Width="457px" >
        <Columns>
            <asp:TemplateField HeaderText="Show order">
             <ItemTemplate>
                    <asp:Button ID="btnshoworder" runat="server" Height="28px" Text="Show Order" 
                        Width="54px" onclick="btnshoworder_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Show Client">
                <ItemTemplate>
                    <asp:Button ID="btnshow" runat="server" Height="28px" Text="Show Client" 
                        Width="54px" onclick="btnshow_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Idss" HeaderText="Client's ID" />
            <asp:BoundField DataField="OrderID" HeaderText="Order's ID" />
            <%--<asp:BoundField DataField="ProductID" HeaderText="Product's ID" />--%>
            <asp:TemplateField HeaderText="Deliver">
                <ItemTemplate>
                    <asp:Button ID="btndelivery" runat="server" Text="Do Delivery" 
                        onclick="btndelivery_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView></center>
</asp:Content>


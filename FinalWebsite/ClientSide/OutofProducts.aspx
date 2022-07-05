<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="OutOfProducts.aspx.cs" Inherits="OutOfProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="Label1" runat="server" Text="You have to order more of these produts"></asp:Label>

<br />

<center>
    <asp:GridView ID="grdUnderMin" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" Height="222px" Width="421px" 
    onselectedindexchanged="grdUnderMin_SelectedIndexChanged" CellPadding="4" 
        AllowPaging="True" onpageindexchanging="grdUnderMin_PageIndexChanging" 
        PageSize="5" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
           <asp:CommandField ButtonType="Button" SelectText="Update" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="ProductID" HeaderText="Id" />
            <asp:BoundField DataField="ProductName" HeaderText="Name" />
            <asp:BoundField DataField="CurrentAmount" HeaderText="Current capacity" />
            <asp:BoundField DataField="MinAmount" HeaderText="Minimum capacity" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>

    </center>
</asp:Content>


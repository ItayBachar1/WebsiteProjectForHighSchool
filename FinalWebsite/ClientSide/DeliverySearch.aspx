<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="DeliverySearch.aspx.cs" Inherits="DeliverySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<h1><b><u><i>Search Deliveries</i></u></b></h1>
<br />
<br />
<table>
<%if(level.Equals("client")){ %>
<td>
    
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Value="0">All Deliveries</asp:ListItem>
        <asp:ListItem Value="1">Shipped</asp:ListItem>
        <asp:ListItem>Not Shipped</asp:ListItem>
    </asp:DropDownList>
    
    </td> 
    <%} %>

    <%else{ %>
    <td>
    
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="0">All Deliveries</asp:ListItem>
            <asp:ListItem Value="1">on the way</asp:ListItem>
            <asp:ListItem Value="2">Delivery&#39;s Id</asp:ListItem>
            <asp:ListItem Value="3">Not sent</asp:ListItem>
            <asp:ListItem Value="4">Car&#39;s Id</asp:ListItem>
        </asp:DropDownList>
    
    </td>
    <%} %>
<td class="style2">
    <asp:TextBox ID="txtsearch" runat="server" Height="33px" Width="91px"></asp:TextBox>
    </td>
<td>
    <asp:Button ID="btnsearch" runat="server" Text="Search" 
        onclick="btnsearch_Click" />
    </td>
    <tr>
<td></td>
<td> </td>
<td>
    <asp:Label ID="lblmes" runat="server" Text="The Delivery Doesn't Exist" 
        BorderColor="Black" BackColor="White" Font-Size="X-Large" Font-Bold="True" 
        ForeColor="Black" Visible="false"></asp:Label>
    </td>
</tr>
</table>
<br />
<br />
    <asp:GridView ID="Delivery" runat="server" 
      
        EnableModelValidation="True" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Show Delivery">
                <ItemTemplate>
                    <asp:Button ID="btnShow" runat="server" Height="29px" onclick="btnShow_Click" 
                        Text="Show" Width="52px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DeliveryID" HeaderText="Delivery's Id" />
            <asp:BoundField DataField="TruckID" HeaderText="Car's Id" />
            <asp:BoundField DataField="DriverID" HeaderText="Driver's Id" />
            <asp:BoundField DataField="Idss" HeaderText="Client's Id" />
            <asp:BoundField DataField="DeliveryDate" HeaderText="Date Of Delivery" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
        </Columns>
    </asp:GridView>
    </center>
</asp:Content>


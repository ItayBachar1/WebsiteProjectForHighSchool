<%@ Page Title="Search Trucks" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Searchtruck.aspx.cs" Inherits="Searchtruck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<h1><b><u><i>Search truck</i></u></b></h1>
<br />
<br />
<table>
<tr>
<td colspan="3">
    <asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="0">All Trucks</asp:ListItem>
        <asp:ListItem Value="1">Active</asp:ListItem>
        <asp:ListItem Value="2">Truck's ID</asp:ListItem>
        <asp:ListItem Value="3">Not Active</asp:ListItem>
        <asp:ListItem Value="4">Truck's name</asp:ListItem>
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
    <asp:Label ID="lblmes" runat="server" Text="The truck does not exist" 
        BorderColor="Black" BackColor="White" Font-Size="X-Large" Font-Bold="True" 
        ForeColor="Black" Visible="false"></asp:Label>
    </td>
</tr>
</table>
<br />


<br />
    <asp:GridView ID="cars" runat="server" 
      
        EnableModelValidation="True" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Show Truck">
                <ItemTemplate>
                    <asp:Button ID="btnShow" runat="server" Height="29px" onclick="btnShow_Click" 
                        Text="Show" Width="52px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TruckID" HeaderText="Truck's ID" />
            <asp:BoundField DataField="TruckName" HeaderText="Truck's Name" />
            <asp:BoundField DataField="Capacity" HeaderText="Truck's Capacity" />
            <asp:BoundField DataField="Status" HeaderText="Truck's Status" />
            <asp:TemplateField HeaderText="Truck's Image">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="137px" 
                        ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Picture","pic/{0}") %>' 
                        Width="205px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </center>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="SearchOrder.aspx.cs" Inherits="SearchOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
 <table>
                    <tr>
            <td rowspan="7">
                <asp:Image ID="img1" runat="server" Height="231px" Width="215px" 
                    ImageUrl="~/pic/images.jpg"></asp:Image>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl1" runat="server" Text="Username"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtuser" runat="server"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td>
                <asp:Label ID="lbl3" runat="server" Text="First name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Last name"></asp:Label>
            </td>
            <td align="center" class="style2">
                <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
        <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click"  />
            </td>
<td>
     <asp:Label ID="lbldidnt" runat="server" Text="Didn't found" Visible="false" Font-Bold="true" ForeColor="Red" Font-Size="Large"></asp:Label>

</td>
        </tr>

    
   
    </table>

    <br />
    <asp:GridView ID="GrdOrders" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" 
    onselectedindexchanged="GrdOrders_SelectedIndexChanged" CellPadding="4" 
        Width="663px" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
                   <asp:CommandField ButtonType="Button" SelectText="Show" 
                ShowSelectButton="True" />
            <asp:BoundField DataField="OrderID" HeaderText="Id" />
            <asp:BoundField DataField="OrderDate" HeaderText="Date" />
            <asp:BoundField DataField="Total" HeaderText="Total Price" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
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


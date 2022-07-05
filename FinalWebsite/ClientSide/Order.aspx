<%@ Page Title="Order" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<h1><b><u><i>Search Prodcut</i></u></b></h1>
<br />
<br />
<table>
<tr>
<td>
    <asp:DropDownList ID="catgorie" runat="server" 
        onselectedindexchanged="catgorie_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="0">All Kinds</asp:ListItem>
        <asp:ListItem Value="1">T-Shirt</asp:ListItem>
        <asp:ListItem Value="2">Jeans</asp:ListItem>
        <asp:ListItem Value="3">Skinny Jeans</asp:ListItem>
        <asp:ListItem Value="4">Shoes</asp:ListItem>
        <asp:ListItem Value="5">Bags</asp:ListItem>
        <asp:ListItem Value="6">Super Skinny</asp:ListItem>
        <asp:ListItem Value="7">Underwear</asp:ListItem>
        <asp:ListItem Value="8">Flip Flops</asp:ListItem>
        <asp:ListItem Value="9">Undershirt</asp:ListItem>
        <asp:ListItem Value="10">Heels</asp:ListItem>
        <asp:ListItem Value="11">Skirt</asp:ListItem>
    </asp:DropDownList>
      </td>
<td>
    <asp:TextBox ID="txtsearch" runat="server" Height="30px" Width="117px"></asp:TextBox>
    </td>
    <td>
        <asp:Button ID="Button1" runat="server" Text="Search" 
            onclick="btnsearch_Click" />
    </td>
</tr>
<tr>
<td></td>
<td>
    <asp:Label  ID="lblmes" runat="server" Text="The Product Doesn't Exist" 
    BorderColor="Black" BackColor="White" Font-Size="X-Large" Font-Bold="True" 
    ForeColor="Black" Visible="false"></asp:Label>
    </td> </tr>
</table>
<br />
        <asp:DataList ID="dtlProd" runat="server" RepeatColumns="2" 
        RepeatDirection="Horizontal" BackColor="#DEBA84" 
        BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Both" 
        onupdatecommand="dtlProd_UpdateCommand" 
        oneditcommand="dtlProd_EditCommand" Height="400px" Width="500px" 
            onselectedindexchanged="dtlProd_SelectedIndexChanged" CellSpacing="2" >
      

        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />

            <ItemStyle BackColor="#FFF7E7" ForeColor="#8C4510" />

    <ItemTemplate>
    
    <table>
    <tr>
    <td rowspan="4">
        <asp:Image ID="img" runat="server" Height="200px" 
            ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Picture","pic/product/{0}") %>' 
            Width="300px" />  </td>
    </tr>
    
    <tr>
    <td>Name:</td>
    <td>
        <asp:Label ID="lblName" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"ProductName") %>'></asp:Label></td>
    </tr>
    <tr>
    <td>Price:</td>
    <td>
        <asp:Label ID="lblPrice" runat="server" 
            Text='<%# DataBinder.Eval(Container.DataItem,"ConsumerPrice") %>'></asp:Label></td>
    </tr>
    <tr>
    <td>Quantity:</td>
    <td>
        <asp:DropDownList ID="quantity1" runat="server" Height="16px" Width="51px">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        </td>

        <td>
            <asp:Label Visible="false" ID="lblCurCap" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CurrentAmount") %>'></asp:Label>
        </td>
        <td>
            <asp:Label Visible="false" ID="lblid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ProductID") %>'></asp:Label>
        </td>
    </tr>
      <tr>
  <td>
      <asp:Button ID="btndeatails" runat="server" Text="Deatails" 
          CommandName="Edit" Height="31px" Width="70px"  /></td>



        <td>
      <asp:Button ID="btnaddtocart" runat="server" Text="Add" CommandName="Update" 
                Height="50px" Width="70px" /></td>
  </tr>
    </table>
    </ItemTemplate>



        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />

    </asp:DataList>

        <table>
            <tr>

                <td>
                    <asp:Button ID="Button2" runat="server" Text="My Cart" OnClick="btnOrder_Click" />
                </td>
              </tr>

        </table>
  






</center>
</asp:Content>


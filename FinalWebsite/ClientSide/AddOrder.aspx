<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="AddOrder.aspx.cs" Inherits="AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
<a href="Order.aspx">Return to orders</a>
<br />
<br />
    <asp:GridView ID="GrdOrder" runat="server" CellPadding="4" 
        EnableModelValidation="True" 
            AutoGenerateColumns="False" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
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
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

  
    </asp:GridView>






    <br />

    <br />
    <p>Add your credit card details</p>
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="Code"></asp:Label>
        </td>

    <td>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtCode" ErrorMessage="Empty"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
        </td>
    </tr>

      <tr>
    <td>
        <asp:Label ID="Label2" runat="server" Text="ExpiryDate"></asp:Label>
          </td>

    <td>
        <asp:DropDownList ID="dropMonth" runat="server" Height="45px" Width="94px">
            <asp:ListItem>Month</asp:ListItem>
        </asp:DropDownList>

        <asp:DropDownList ID="dropYear" runat="server" Height="39px" Width="76px">
            <asp:ListItem>Year</asp:ListItem>
        </asp:DropDownList>

         </td>
    </tr>

       <tr>
    <td>
        <asp:Label ID="Label3" runat="server" Text="CVV"></asp:Label>
           </td>

    <td>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
        runat="server" ControlToValidate="txtCvv" 
        ErrorMessage="Wrong CVV" ValidationExpression="^\d\d\d\d"></asp:RegularExpressionValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtCvv" ErrorMessage="Empty"></asp:RequiredFieldValidator>
        <asp:TextBox ID="txtCvv" runat="server"></asp:TextBox>
           </td>
    </tr>

    </table>

    <br />

    <asp:Button ID="btnOrder" runat="server" Text="Order" 
        onclick="btnOrder_Click" />
    </center>
</asp:Content>


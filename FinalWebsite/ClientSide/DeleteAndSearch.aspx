<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="DeleteAndSearch.aspx.cs" Inherits="DeleteAndSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<form id="Form1">
        <hr />
    <center>
        <h1>Search/Delete User</h1>
        <asp:TextBox ID="tb_searchCriteria" runat="server"></asp:TextBox>     &nbsp; 
          <asp:DropDownList ID="dd_searchType" runat="server">
            <asp:ListItem>Firstname</asp:ListItem>
              <asp:ListItem Value="Mail">Email</asp:ListItem>
            <asp:ListItem Value="Idss">Id</asp:ListItem>
              <asp:ListItem>Status</asp:ListItem>
              <asp:ListItem>Firstname</asp:ListItem>
              <asp:ListItem>Lastname</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="btn_findClient" runat="server" Text="Find Client" OnClick="btn_findClient_Click" />
    </center>

        <center>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                   OnRowCommand="GridView1_RowCommand" 
                   OnRowDataBound="GridView1_RowDataBound"
                    OnRowDeleting="GridView1_RowDeleting" EnableModelValidation="True" 
                Height="319px" Width="279px" CellPadding="3" 
                GridLines="Horizontal" BackColor="White" BorderColor="#E7E7FF" 
                BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:BoundField DataField="Idss" HeaderText="Client ID" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Password" HeaderText="Password" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Firstname" HeaderText="First name" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Lastname" HeaderText="Last name" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="City" HeaderText="City" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Street" HeaderText="Street" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Numstreet" HeaderText="Number street" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Phone" HeaderText="Phone" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Mail" HeaderText="Mail" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Birth" HeaderText="Birth" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Picture">
                     <ItemTemplate>
                         <asp:Image ID="Image2" runat="server" Height="50px" ImageUrl='<%# DataBinder.Eval(Container.DataItem,"Pic","pic/users/{0}") %>' Width="50px" />
                     </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField DataField="Level" HeaderText="Level" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status" >
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                   <asp:TemplateField HeaderText="Delete/Restore">
             <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" 
                CommandArgument='<%# Eval("Idss") %>' 
                CommandName="Delete" runat="server">
                Delete / Restore</asp:LinkButton>
            </ItemTemplate>
                       <ItemStyle HorizontalAlign="Center" />
   </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        </asp:GridView>
        <br />
        </center>

    </form>

</asp:Content>


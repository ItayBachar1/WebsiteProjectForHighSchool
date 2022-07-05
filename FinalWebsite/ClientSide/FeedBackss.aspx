<%@ Page Title="Feedbacks" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="FeedBackss.aspx.cs" Inherits="FeedBackss" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lbl1" runat="server" Text="Username"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>

        </tr>

        <tr>
            <td>
                <asp:Label ID="lbl3" runat="server" Text="Worker"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTrainer" runat="server"></asp:TextBox>
            </td>
        </tr>
       

        <tr>
        <td><asp:Label ID="Label6" runat="server" Text="Date"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="dropMonth" runat="server" Width="77px">
                <asp:ListItem>Month</asp:ListItem>
                <asp:ListItem>01</asp:ListItem>
                <asp:ListItem>02</asp:ListItem>
                <asp:ListItem>03</asp:ListItem>
                <asp:ListItem>04</asp:ListItem>
                <asp:ListItem>05</asp:ListItem>
                <asp:ListItem>06</asp:ListItem>
                <asp:ListItem>07</asp:ListItem>
                <asp:ListItem>08</asp:ListItem>
                <asp:ListItem>09</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
    <asp:DropDownList ID="dropYear" runat="server" Width="90px">
        <asp:ListItem>2016</asp:ListItem>
    </asp:DropDownList>
</td>
        </tr>




       <tr>
             <td colspan="2" class="style1">
                 <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                     Text="Search" />

                     &nbsp;&nbsp;
                                                              <asp:Button ID="btnDelete" 
                     runat="server" onclick="btnDelete_Click" Text="Delete" />

                                                          &nbsp;&nbsp;

                        
            </td>

            <td>
     <asp:Label ID="lbldidnt" runat="server" Text="Not Found" Visible="false" Font-Bold="true" ForeColor="Red" Font-Size="Large"></asp:Label>

            </td>
        </tr>   
        
    
   
    </table>
    <br />

<asp:GridView ID="GrdFeedbacks" runat="server" AutoGenerateColumns="False" 
        BackColor="Cyan" BorderColor="yellow" BorderStyle="None" BorderWidth="1px" 
        CellPadding="6" EnableModelValidation="True" AllowPaging="True" 
        onpageindexchanging="GrdFeedbacks_PageIndexChanging" 
      PageSize="5" onrowdatabound="GrdFeedbacks_RowDataBound">
    <Columns>
        <asp:TemplateField HeaderText="Select">
            <ItemTemplate>
                <asp:CheckBox ID="chkbox" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="IdFeedback" HeaderText="Feedback's ID" />
        <asp:BoundField DataField="Idss" HeaderText="Username's ID" />
        <asp:BoundField DataField="Worker" HeaderText="Worker" />
        <asp:BoundField DataField="DateFeedback" HeaderText="Date" />
        <asp:TemplateField HeaderText="Show">
            <ItemTemplate>
                <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="Show" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#330099" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
</asp:GridView>
</asp:Content>


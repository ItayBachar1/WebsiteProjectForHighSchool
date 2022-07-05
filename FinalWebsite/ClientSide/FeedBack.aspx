<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 273px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h1>Give us your feedback!</h1>
 <table class="regTable">

        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Worker" Font-Names="Gisha"></asp:Label>
            </td>
            <td class="style1">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtTrainer" ErrorMessage="Empty" Font-Names="Gisha"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtTrainer" runat="server" Width="106px" BackColor="White" 
                               Font-Names="Gisha" ForeColor="#663300"></asp:TextBox>
               

  </td>
    
        </tr>

        <tr>
   <td>
                <asp:Label ID="Label5" runat="server" Text="Professionalism" Font-Names="Gisha"></asp:Label></td>
            <td class="style1">
                <asp:DropDownList ID="dropPro" runat="server" BackColor="White" 
                    Font-Names="Gisha" ForeColor="#663300">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>

        
        <tr>
   <td>
                <asp:Label ID="Label1" runat="server" Text="Human Relation" Font-Names="Gisha"></asp:Label></td>
            <td class="style1">
                <asp:DropDownList ID="dropHuman" runat="server" BackColor="White" 
                    Font-Names="Gisha" ForeColor="#663300">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>

    <tr>
   <td>
                <asp:Label ID="Label9" runat="server" Text="Satisfaction" Font-Names="Gisha"></asp:Label></td>
            <td class="style1">
                <asp:DropDownList ID="dropSatis" runat="server" BackColor="White" 
                    Font-Names="Gisha" ForeColor="#663300">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>


                <tr>
   <td>
                <asp:Label ID="Label4" runat="server" Text="Comments" Font-Names="Gisha"></asp:Label>
                    </td>
            <td class="style1">
         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
        ControlToValidate="txtInformation" ErrorMessage="Empty" Font-Names="Gisha"></asp:RequiredFieldValidator>
        <asp:TextBox id="txtInformation" TextMode="multiline" Columns="50" Rows="5" 
                    runat="server" Height="167px" Width="227px" BackColor="White" 
                    Font-Names="Gisha" ForeColor="#663300" />


            </td>
        </tr>

        

                       <tr>
                                <td>

              <asp:Button ID="btnFeedBack" runat="server" Text="Send Feedback" onclick="btnFeedBack_Click" 
                                        BackColor="#663300" BorderStyle="Groove" Font-Names="Gisha" ForeColor="White" 
                                        Height="44px" Width="120px"/>
          </td>


        </tr>





    </table>
</asp:Content>


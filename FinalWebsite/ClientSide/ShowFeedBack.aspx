<%@ Page Title="Show Feedback" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="ShowFeedBack.aspx.cs" Inherits="ShowFeedBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table class="regTable">
            <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Feedback's ID"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </td>
        </tr>

                    <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Username's ID"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
            </td>
        </tr>

                    <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Worker"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTrainer" runat="server" Text=""></asp:Label>
            </td>
        </tr>

                    <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Professionalism"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPro" runat="server" Text=""></asp:Label>
            </td>
        </tr>

                    <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Human Relation"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblHumanRelation" runat="server" Text=""></asp:Label>
            </td>
        </tr>

                            <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Satisfaction"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSatisfaction" runat="server" Text=""></asp:Label>
            </td>
        </tr>

                          <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Comments"></asp:Label>
            </td>
            <td>
                <asp:TextBox id="txtInformation" TextMode="multiline" Columns="50" Rows="5" runat="server" Height="167px" Width="227px" ReadOnly="true" />
            </td>
            </tr>

    
    </table>


</asp:Content>


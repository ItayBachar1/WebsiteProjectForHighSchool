<%@ Page Title="" Language="C#" MasterPageFile="~/Design.master" AutoEventWireup="true" CodeFile="ClientArea.aspx.cs" Inherits="ClientArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1 style="font-size: xx-large; font-weight: normal">Your Area</h1>
<a href="Update.aspx" style="font-weight: bolder; font-size: large;">Update your details</a> <br /><br />
<a href="Order.aspx" style="font-weight: bolder; font-size: large;">Order</a><br /><br />
<a href="SearchOrder.aspx" style="font-weight: bolder; font-size: large;">Search your orders</a><br /><br />
<a href="DeliverySearch.aspx" style="font-weight: bolder; font-size: large;">Search your delivery</a><br /><br />
<a href="FeedBack.aspx" style="font-weight: bolder; font-size: large;">Give us a feedback :) </a><br /><br />

</asp:Content>


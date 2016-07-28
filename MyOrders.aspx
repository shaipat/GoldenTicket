<%@ Page Title="MyOrders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="HW2.MyOrders" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="jumbotron fluid">
		<h1><span class="glyphicon glyphicon-shopping-cart" style="margin-top:-20px; font-size: 50px;"></span> My Orders.</h1>


		<h3>A quick summary of your orders:</h3><br />
		<asp:Label runat="server" ID="txtPhoneNumber" CssClass="h3"  Text=""></asp:Label>
		


		<%--ORDERS TABLE--%>
		<%--Items will be added from SQL DB Dynamically--%>
		<asp:Table runat="server" ID="TblOrders" CssClass="orders-table table-hover">
			<asp:TableRow CssClass="header">
				<asp:TableCell>Movie Name</asp:TableCell>
				<asp:TableCell>Number Of Seats</asp:TableCell>
				<asp:TableCell>Credit Card Type</asp:TableCell>
				<asp:TableCell>Order Date</asp:TableCell>
			</asp:TableRow>
			
		</asp:Table>	

	 </div>
</asp:Content>

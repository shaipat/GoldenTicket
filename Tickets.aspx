<%@ Page Title="Tickets" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="HW2.Tickets" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="jumbotron fluid">
		<h1><span class="glyphicon glyphicon-film" style="margin-top:-28px; font-size: 50px;"></span> Buy a Ticket.</h1>



		<div class="row">

			<div class="col-lg-4">
				 <div id="left">
				<h3>Step 1: Make a choice</h3>
					 <%--movies list--%>
					<asp:DropDownList ID="MoviesList" runat="server" CssClass="form-control"> </asp:DropDownList>  
			</div>
			</div>

			<div class="row fluid col-lg-5">
				<h3>Step 2: Take a seat</h3>
				<div class="col-lg-3" >
					<h4 style="margin-bottom:18px; margin-top:3px;">Line 1:</h4>
					<h4 style="margin-bottom:18px;">Line 2:</h4>
					<h4 style="margin-bottom:18px;">Line 3:</h4>
					<h4>Line 4:</h4>
				</div>             


				<div class="col-lg-2" style="margin-left: -20px;">
					<div id ="right">
				

						<asp:CheckBoxList runat="server" ID="Seats" RepeatColumns="5" CssClass="chkChoice" RepeatDirection="Horizontal" Font-Size="Larger" RepeatLayout="Table" CellPadding="10" Height="150" Width="250" CellSpacing="10" Font-Bold="False">
							<asp:ListItem Value="R1S1">1</asp:ListItem>
							<asp:ListItem Value="R1S2">2</asp:ListItem>
							<asp:ListItem Value="R1S3">3</asp:ListItem>
							<asp:ListItem Value="R1S4">4</asp:ListItem>
							<asp:ListItem Value="R1S5">5</asp:ListItem>
							<asp:ListItem Value="R2S1">1</asp:ListItem>
							<asp:ListItem Value="R2S2">2</asp:ListItem>
							<asp:ListItem Value="R2S3">3</asp:ListItem>
							<asp:ListItem Value="R2S4">4</asp:ListItem>
							<asp:ListItem Value="R2S5">5</asp:ListItem>
							<asp:ListItem Value="R3S1">1</asp:ListItem>
							<asp:ListItem Value="R3S2">2</asp:ListItem>
							<asp:ListItem Value="R3S3">3</asp:ListItem>
							<asp:ListItem Value="R3S4">4</asp:ListItem>
							<asp:ListItem Value="R3S5">5</asp:ListItem>
							<asp:ListItem Value="R4S1">1</asp:ListItem>
							<asp:ListItem Value="R4S2">2</asp:ListItem>
							<asp:ListItem Value="R4S3">3</asp:ListItem>
							<asp:ListItem Value="R4S4">4</asp:ListItem>
							<asp:ListItem Value="R4S5">5</asp:ListItem>
						 </asp:CheckBoxList>
		
				   
					 </div>
				</div>
			</div>

			<div class="col-lg-3">
				<h3>Step 3: Time to pay</h3>
				 <asp:Button ID="btnPay" OnClick="btnPay_Click" cssClass="btn btn-success" runat="server" Text="Pay Now" />
			</div>
			


		</div>






	 </div>
</asp:Content>

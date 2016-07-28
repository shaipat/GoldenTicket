<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="HW2.Payment" %>
<%@ MasterType VirtualPath="~/Site.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<div class="jumbotron">
		<h1><span class="glyphicon glyphicon-credit-card" style="margin-top:-18px; font-size: 45px;"></span> <%: Title %>.</h1>


		<div class="row">


			<div class="col-lg-6">
				<h2 style="margin-top:0; font-weight:500; margin-bottom:20px;">Order Confirmation</h2>
				<div class="summary">
					<asp:Label ID="OrderSummary" CssClass="h3" runat="server" Text=""></asp:Label>
				</div>
				 
			</div>


		  <div class="col-lg-6">
				<h2 style="margin-top:0; font-weight:500; margin-bottom:20px;">Now open your wallet.</h2>
				
						<div class="form-horizontal" style="padding: 10px;">

							<div class="form-group">
								<label for="ddlCreditList" class="col-lg-3 control-label">Card Type</label>
								<asp:DropDownList ID="ddlCreditList" runat="server" CssClass="form-control" Font-Size="Large" Font-Bold="True">
									<asp:ListItem Enabled="true" Text="Visa" Value="1"></asp:ListItem>
									<asp:ListItem Text="MasterCard" Value="2"></asp:ListItem>
									<asp:ListItem Text="American Express" Value="3"></asp:ListItem>
								</asp:DropDownList>   
							 </div>

							<div class="form-group">
								<label for="txtCreditNumber" class="col-lg-3 control-label">Card Number</label>
								<asp:TextBox ID="txtCreditNumber" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="Large"></asp:TextBox>
							</div>

							<div class="form-group">
								<label for="txtPhoneNumber" class="col-lg-3 control-label">Phone Number</label>
								<asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" Font-Bold="True" Font-Size="Large"></asp:TextBox>
							</div>

							 <div class="form-group">
								 <label for="rbCoupon" class="col-lg-3 control-label">Got Coupon?</label>
								 <asp:RadioButtonList ID="rbCoupon" CssClass="col-lg-offset-4" runat="server" RepeatDirection="Horizontal" Font-Size="Large" Height="50" RepeatLayout="Table" Width="120">
									 <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
									 <asp:ListItem Text="No" Value="No" Selected="True"></asp:ListItem>
								 </asp:RadioButtonList>
							 </div>

							<asp:RequiredFieldValidator runat="server" ValidationGroup="PaySubmit" ControlToValidate="txtCreditNumber" ErrorMessage="*Credit Card Required" ForeColor="Red"> </asp:RequiredFieldValidator> 
							<asp:RequiredFieldValidator runat="server" ValidationGroup="PaySubmit" ControlToValidate="txtPhoneNumber" CssClass="m-left-10" ErrorMessage="*Phone Number Required" ForeColor="Red" > </asp:RequiredFieldValidator><br />
							<asp:RegularExpressionValidator runat="server" id="rexNumber"  ValidationGroup="PaySubmit"  controltovalidate="txtCreditNumber"  validationexpression="^[0-9]{6}" errormessage="Only 6 digits credit card allowed!" ForeColor="Red" /><br />
							<asp:RegularExpressionValidator runat="server" id="rexPhone"  ValidationGroup="PaySubmit"   controltovalidate="txtPhoneNumber" validationexpression="^[0-9]{10}" errormessage="Incorrect phone number!" ForeColor="Red" /><br /><br />


							<div class="form-group">
								<div class="col-lg-offset-4">
									<asp:Button ID="btnOrderNow" OnClick="btnOrderNow_Click" CssClass="btn btn-danger" ValidationGroup="PaySubmit" runat="server" Text="Order Now" />
								</div>
							</div>
						</div>
				
			</div>


		</div>

	 </div>
</asp:Content>

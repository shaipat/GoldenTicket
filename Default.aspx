<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HW2._Default" %>

<%@ MasterType VirtualPath="~/Site.master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1 style="font-weight: 700">Golden Ticket Cinema</h1>
        <img src="../images/samuel.gif" class="img-circle img-responsive" width="400" style="float: right;" />
        <p class="lead">
            Welcome to Golden Ticket Cinema. We are proud to have you.<br />
            Enjoy your stay! :)<br />
            <br />
            <br />
            
            <strong>To begin, please login: </strong>
        </p>


        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-lg-5">
                    <label for="txtUserName" class="control-label">User Name</label>
                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>

                    <label for="txtPassword" class="control-label">Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
            </div>
            <div class="form-group has-success">
                <div class="col-lg-3">
                    <asp:Button ID="btnLetsGo" CssClass="btn btn-success" runat="server" Text="Let's Go!" OnClick="btnLetsGo_Click" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>

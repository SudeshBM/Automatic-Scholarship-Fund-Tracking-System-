<%@ Page Title="" Language="C#" MasterPageFile="~/Donor.Master" AutoEventWireup="true" CodeBehind="AddDonorWallet.aspx.cs" Inherits="AutomateScholarship.AddDonorWallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Add Donor Wallet Amount:</h4>
            </div>
            <div class="form-body">
                
                <div class="form-group">
                    <label>
                        Enter Amount</label>
                    <asp:TextBox ID="txtAmount" class="form-control" runat="server" placeholder="Enter Amount"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Amount"
                        ControlToValidate="txtAmount" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
                <div class="pull-right">
                    <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                        ValidationGroup="A" />
                </div>
                <br />
            </div>
        </div>
    </div>
</asp:Content>

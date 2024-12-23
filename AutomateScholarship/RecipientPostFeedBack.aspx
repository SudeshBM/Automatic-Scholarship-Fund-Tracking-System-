<%@ Page Title="" Language="C#" MasterPageFile="~/Recipient.Master" AutoEventWireup="true" CodeBehind="RecipientPostFeedBack.aspx.cs" Inherits="AutomateScholarship.RecipientPostFeedBack" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Post Feed Back:</h4>
            </div>
            <div class="form-body">
                
                <asp:Panel ID="Panel1" runat="server">
                <h3>NGO ScholarShip Details</h3>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                 </asp:Table>
                </asp:Panel>
                
                <asp:Panel ID="Panel2" runat="server">
                <div class="form-group">
                    <label>
                        Enter Feedback</label>
                    <asp:TextBox ID="txtFeedback" class="form-control" runat="server" placeholder="Enter Feedback"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Feedback"
                        ControlToValidate="txtFeedback" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <div class="pull-right">
                    <asp:Button ID="btnSubmit" class="btn btn-default" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                        ValidationGroup="A" />
                </div>
                </asp:Panel>
                 <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

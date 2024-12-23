<%@ Page Title="" Language="C#" MasterPageFile="~/Recipient.Master" AutoEventWireup="true" CodeBehind="AddRecipientEducation.aspx.cs" Inherits="AutomateScholarship.AddRecipientEducation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Add Education Details:</h4>
            </div>
            <div class="form-body">
                <div class="form-group">
                    <label>
                        Enter School/College Name</label>
                    <asp:TextBox ID="txtIName" class="form-control" runat="server" placeholder="Enter School/College Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter School/College Name"
                        ControlToValidate="txtIName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                 <div class="form-group">
                    <label>
                        Enter Education/Degree</label>
                    <asp:TextBox ID="txtEducation" class="form-control" runat="server" placeholder="Enter Education"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Education"
                        ControlToValidate="txtEducation" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                 <div class="form-group">
                    <label>
                        Enter Year Pass</label>
                    <asp:TextBox ID="txtYearPass" class="form-control" runat="server" placeholder="Enter Year Pass"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Year Pass"
                        ControlToValidate="txtYearPass" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>
                        Enter Percentage</label>
                    <asp:TextBox ID="txtPercentage" class="form-control" runat="server" placeholder="Enter Percentage"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Percentage"
                        ControlToValidate="txtPercentage" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
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

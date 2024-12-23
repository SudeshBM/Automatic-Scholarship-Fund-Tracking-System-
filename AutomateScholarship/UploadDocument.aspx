<%@ Page Title="" Language="C#" MasterPageFile="~/Recipient.Master" AutoEventWireup="true" CodeBehind="UploadDocument.aspx.cs" Inherits="AutomateScholarship.UploadDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Upload Document:</h4>
            </div>
            <div class="form-body">
                 <div class="form-group">
                    <label>
                        Enter Document Name</label>
                    <asp:TextBox ID="txtFileName" class="form-control" runat="server" placeholder="Enter File Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter File Name"
                        ControlToValidate="txtFileName" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>
                        Select File</label>
                    <asp:FileUpload ID="PhotoFile" class="form-control" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select File"
                        ForeColor="Red" ValidationGroup="A" ControlToValidate="PhotoFile"></asp:RequiredFieldValidator>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/NGO.Master" AutoEventWireup="true" CodeBehind="NGOScholarship.aspx.cs" Inherits="AutomateScholarship.NGOScholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Add Scholarship:</h4>
            </div>
            <div class="form-body">
                <div class="form-group">
                    <label>
                        Select Scholarship Academic</label>
                    <asp:DropDownList ID="ddlAcademic" class="form-control" runat="server">
                    
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Academic"
                        ControlToValidate="ddlAcademic" ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--"></asp:RequiredFieldValidator>
                </div>
                
                <div class="form-group">
                    <label>
                        Enter Scholarship Apply Start Date</label>
                    <asp:TextBox ID="txtSD" class="form-control" runat="server" placeholder="Enter Scholarship Apply Start Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Scholarship Apply Start Date"
                        ControlToValidate="txtSD" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>
                        Enter Scholarship Apply End Date</label>
                    <asp:TextBox ID="txtED" class="form-control" runat="server" placeholder="Enter Scholarship Apply End Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Scholarship Apply End Date"
                        ControlToValidate="txtED" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
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

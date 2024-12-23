<%@ Page Title="" Language="C#" MasterPageFile="~/Recipient.Master" AutoEventWireup="true" CodeBehind="ApplyScholarship.aspx.cs" Inherits="AutomateScholarship.ApplyScholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    View NGO Scholarship Details:</h4>
            </div>
            <div class="form-body">
            <div class="form-group">
                    <label>
                        Select NGO</label>
                    <asp:DropDownList ID="ddlNGO" class="form-control" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="ddlNGO_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select NGO"
                        ControlToValidate="ddlNGO" ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--"></asp:RequiredFieldValidator>
                </div>
                <br /><br />
                 <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                 </asp:Table>
                 <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

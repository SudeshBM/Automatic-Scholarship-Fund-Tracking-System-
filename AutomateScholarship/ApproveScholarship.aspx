<%@ Page Title="" Language="C#" MasterPageFile="~/NGO.Master" AutoEventWireup="true" CodeBehind="ApproveScholarship.aspx.cs" Inherits="AutomateScholarship.ApproveScholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Approve Scholarship:</h4>
            </div>
            <div class="form-body">
                <div class="form-group">
                    <label>
                        Select Scholarship Academic</label>
                    <asp:DropDownList ID="ddlAcademic" class="form-control" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="ddlAcademic_SelectedIndexChanged">
                    
                    </asp:DropDownList>
                </div>
                
               <br /><br />
                <asp:Panel ID="Panel1" runat="server">
                <h3>NGO ScholarShip Details</h3>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                 </asp:Table>
                </asp:Panel>
                 <br /><br />
                <asp:Panel ID="Panel2" runat="server">
                <h3>Recipient Apply ScholarShip Details</h3>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table2" runat="server">
                 </asp:Table>
                </asp:Panel>
                <br /><br />
                <asp:Panel ID="Panel3" runat="server">
                <h3>Recipient Education Details</h3>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table3" runat="server">
                 </asp:Table>
                </asp:Panel>
                <br /><br />
                <asp:Panel ID="Panel4" runat="server">
                <h3>Recipient Document Details</h3>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table4" runat="server">
                 </asp:Table>
                </asp:Panel>
                <asp:Panel ID="Panel5" runat="server">
                <div class="form-group">
                    <label>
                        Enter Reason</label>
                    <asp:TextBox ID="txtReason" class="form-control" runat="server" placeholder="Enter Reason"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Reason"
                        ControlToValidate="txtReason" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
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

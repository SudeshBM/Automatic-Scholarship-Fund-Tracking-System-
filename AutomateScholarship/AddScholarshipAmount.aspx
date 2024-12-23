<%@ Page Title="" Language="C#" MasterPageFile="~/NGO.Master" AutoEventWireup="true" CodeBehind="AddScholarshipAmount.aspx.cs" Inherits="AutomateScholarship.AddScholarshipAmount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Add Scholarship Amount:</h4>
            </div>
            <div class="form-body">
                <div class="form-group">
                    <label>
                        Select Scholarship Academic</label>
                    <asp:DropDownList ID="ddlAcademic" class="form-control" runat="server">
                    <asp:ListItem>--Select--</asp:ListItem>
                          <asp:ListItem>SSLC</asp:ListItem>
                           <asp:ListItem>Diploma</asp:ListItem>
                            <asp:ListItem>PUC</asp:ListItem>
                            <asp:ListItem>UG</asp:ListItem>
                              <asp:ListItem>PG</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Academic"
                        ControlToValidate="ddlAcademic" ForeColor="#FF3300" ValidationGroup="A" InitialValue="--Select--"></asp:RequiredFieldValidator>
                </div>
                
                
                 <div class="form-group">
                    <label>
                        Enter Scholarship Description</label>
                    <asp:TextBox ID="txtDescription" class="form-control" runat="server" placeholder="Enter Description"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Description"
                        ControlToValidate="txtDescription" ForeColor="#FF3300" ValidationGroup="A"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>
                        Enter Scholarship Amount</label>
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

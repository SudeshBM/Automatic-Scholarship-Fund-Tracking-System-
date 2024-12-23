<%@ Page Title="" Language="C#" MasterPageFile="~/NGO.Master" AutoEventWireup="true"
    CodeBehind="ViewDonateAmount.aspx.cs" Inherits="AutomateScholarship.ViewDonateAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Donation Details:</h4>
            </div>
            <div class="form-body">
                <h2>
                    Government Pay Details</h2>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                </asp:Table>
                <br />
                <br />
                <h2>
                    Donor Pay Details</h2>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table2" runat="server">
                </asp:Table>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

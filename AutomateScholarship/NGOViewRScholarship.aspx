﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NGO.Master" AutoEventWireup="true" CodeBehind="NGOViewRScholarship.aspx.cs" Inherits="AutomateScholarship.NGOViewRScholarship" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="forms">
        <h2 class="title1">
        </h2>
        <div class="form-grids row widget-shadow" data-example-id="basic-forms">
            <div class="form-title">
                <h4>
                    Donor Pay NGO:</h4>
            </div>
            <div class="form-body">
                 <asp:Panel ID="Panel1" runat="server">
                <h3>NGO ScholarShip Details</h3>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table1" runat="server">
                 </asp:Table>
                </asp:Panel>
                <br /><br />
                <asp:Panel ID="Panel2" runat="server">
                <h3>Scholarship Feedback</h3>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table2" runat="server">
                 </asp:Table>
                </asp:Panel>
                <br /><br />
                <asp:Panel ID="Panel3" runat="server">
                <h3>Recipient Details</h3>
                <asp:Table class="table table-striped table-bordered table-hover" ID="Table3" runat="server">
                 </asp:Table>
                </asp:Panel>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

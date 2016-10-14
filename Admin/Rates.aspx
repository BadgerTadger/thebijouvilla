<%@ Page Title="Rates" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Rates.aspx.cs" Inherits="Admin_Rates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <link href="Content/Site.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
        $(function () {
            $('#<%= txtStartDate.ClientID %>').datepicker({
                firstDay: 6,
                dateFormat: "yy-mm-dd",
                minDate: 1
            });
        });
        $(function () {
            $('#<%= txtEndDate.ClientID %>').datepicker({
                firstDay: 6,
                dateFormat: "yy-mm-dd",
                minDate: 2
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h2><%: Title %>.</h2>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnAdmin" runat="server" Text="Back to Admin" OnClick="btnAdmin_Click" />
            </div>
        </div>
        <div id="divGrid" runat="server" class="row" visible="false">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="RateID"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" 
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="RateID" HeaderText="Row ID" ReadOnly="true" />
                        <asp:BoundField DataField="StartDate" HeaderText="Effective From" ReadOnly="true" />
                        <asp:BoundField DataField="EndDate" HeaderText="Effective To" ReadOnly="true" />
                        <asp:BoundField DataField="Rate" HeaderText="Rate" />
                        <asp:CommandField ShowEditButton="true" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnAddRates" runat="server" Text="Add New Rates" OnClick="btnAddRates_Click" />
            </div>
        </div>
        <div runat="server" id="divAddRates" class="row" visible="false">
            <div class="col-md-12">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Start Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStartDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="End Date"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Rate"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSaveRate" runat="server" Text="Save" OnClick="btnSaveRate_Click" />
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblWarning" CssClass="WarningText" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>


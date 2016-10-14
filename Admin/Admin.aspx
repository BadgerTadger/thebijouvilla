<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2><%: Title %>.</h2>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnEditRates" runat="server" Text="Edit Rates" OnClick="btnEditRates_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <asp:Calendar ID="Calendar1" OnDayRender="Calendar1_DayRender"
                    runat="server" Width="100%" Height="500" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged"
                    OnSelectionChanged="Calendar1_SelectionChanged" FirstDayOfWeek="Saturday"></asp:Calendar>
                <asp:Label runat="server" ID="lblStatus" />
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <p>&nbsp;</p>
            <div id="divDebug" runat="server">
                
            </div>
            <p>&nbsp;</p>
        </div>
        <div id="divGrid" runat="server" class="row" visible="false">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="RowID"
                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="RowID" HeaderText="Row ID" ReadOnly="true" />
                        <asp:BoundField DataField="BookingID" HeaderText="Booking ID" ReadOnly="true" />
                        <asp:BoundField DataField="TenantID" HeaderText="Tenant ID" ReadOnly="true" />
                        <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" ReadOnly="true" />
                        <asp:BoundField DataField="Rate" HeaderText="Rate" />
                        <asp:BoundField DataField="Agency" HeaderText="Agency" />
                        <asp:TemplateField HeaderText="Confirmed">
                            <ItemTemplate>
                                <asp:Label ID="lblConfirmed" runat="server" Text='<%# Eval("Confirmed") %>'
                                    Enabled="false" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkEditConfirmed" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Comments" HeaderText="Comments" />
                        <asp:CommandField ShowEditButton="true" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnAddDates" runat="server" Text="Add Dates To Booking" OnClick="btnAddDates_Click" />
                &nbsp;
                <asp:Button ID="btnConfirmAll" runat="server" Text="Confirm All Dates" OnClick="btnConfirmAll_Click" />
                &nbsp;
                <asp:Button ID="btnUnconfirmAll" runat="server" Text="Unconfirm All Dates" OnClick="btnUnconfirmAll_Click" />
                &nbsp;
                <asp:Button ID="btnDeleteAll" runat="server" Text="Delete All Dates" OnClick="btnDeleteAll_Click" />
            </div>
        </div>
        <div runat="server" id="divAddDates" class="row" visible="false">
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
                        <td colspan="2">
                            <asp:Button ID="btnSaveDates" runat="server" Text="Save" OnClick="btnSaveDates_Click" />
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnCancelSaveDates" runat="server" Text="Cancel" OnClick="btnCancelSaveDates_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblWarning" CssClass="WarningText" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <p>&nbsp;</p>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div runat="server" id="divTenant" class="col-md-4">
                <asp:HiddenField runat="server" ID="hdnTenantID" />
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Name</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtName" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">AddressLine1</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtAddress1" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">AddressLine2</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtAddress2" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Town</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtTown" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">City</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtCity" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">County</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtCounty" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Post Code</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtPostcode" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Country</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtCountry" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Email</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtEmail" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Landline</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtLandline" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Mobile</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox runat="server" ID="txtMobile" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Comments</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox TextMode="MultiLine" Rows="3" runat="server" ID="txtComments" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Previous Tenant?</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:CheckBox ID="chkPreviousTenant" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div runat="server" id="div1" class="col-md-4">
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
</asp:Content>

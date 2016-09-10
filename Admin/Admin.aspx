<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" EnableViewState="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2><%: Title %>.</h2>
        <h3>Rates</h3>
        <asp:RadioButtonList ID="rblRateFrequency" runat="server" CssClass="rbl" AutoPostBack="true" OnSelectedIndexChanged="rblRateFrequency_SelectedIndexChanged">
            <asp:ListItem Text="Weekly" Value="w" Selected="True" />
            <asp:ListItem Text="Daily" Value="d" />
        </asp:RadioButtonList>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <asp:GridView ID="gvRates" runat="server"></asp:GridView>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <p>&nbsp;</p>
        </div>
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8">
                <asp:Calendar ID="Calendar1" OnDayRender="Calendar1_DayRender"
                    runat="server" Width="100%" Height="500" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged"
                    OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                <asp:Label runat="server" ID="lblStatus" />
            </div>
            <div class="col-md-2"></div>
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
            </div>
            <div runat="server" id="div1" class="col-md-4">
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Booking ID</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label runat="server" ID="lblBoobkingID" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server">Rate</asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label runat="server" ID="lblTenantID" Width="250" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div class="col-md-2"></div>
        </div>
        <div class="row">
            <p>&nbsp;</p>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvBookings" runat="server" Width="100%"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

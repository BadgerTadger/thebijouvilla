<%@ Page Title="Tenants" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Tenants.aspx.cs" Inherits="Admin_Tenants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <h2><%: Title %></h2>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnAdmin" runat="server" Text="Back to Admin" OnClick="btnAdmin_Click" />
            </div>
        </div>
        <div id="divGrid" runat="server" class="row" visible="false">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="TenantID"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                    OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="TenantID" HeaderText="Tenant ID" ReadOnly="true" />
                        <asp:BoundField DataField="TenantName" HeaderText="Name" />
                        <asp:BoundField DataField="Address1" HeaderText="Address 1" />
                        <asp:BoundField DataField="Address2" HeaderText="Address 2" />
                        <asp:BoundField DataField="Town" HeaderText="Town" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="County" HeaderText="County" />
                        <asp:BoundField DataField="Postcode" HeaderText="Postcode" />
                        <asp:BoundField DataField="Country" HeaderText="Country" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Landline" HeaderText="Landline" />
                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                        <asp:BoundField DataField="Comments" HeaderText="Comments" />
                        <asp:CommandField ShowEditButton="true" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnAddTenant" runat="server" Text="Add New Tenant" OnClick="btnAddTenant_Click" />
            </div>
        </div>
        <asp:Label ID="lblWarning" CssClass="WarningText" runat="server" Text="" Visible="false"></asp:Label>
        <div runat="server" id="divAddTenant" class="row" visible="false">
            <div class="col-md-12">
                <table>
                    <tr>
                        <td width="30%"></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h4>About you:</h4>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Full Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTenantName" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="First Line of Address"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress1" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Second Line of Address"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress2" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Town"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTown" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="City"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="County"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCounty" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Postcode"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPostcode" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Country"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCountry" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="Landline"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtLandline" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Text="Mobile"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMobile" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label14" runat="server" Text="Comments"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="10" Width="800"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSaveTenant" runat="server" Text="Save" OnClick="btnSaveTenant_Click" />
                        </td>
                        <td colspan="2">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


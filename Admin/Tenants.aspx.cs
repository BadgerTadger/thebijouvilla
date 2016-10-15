using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Tenants : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["LoggedIn"]) == false)
        {
            Response.Redirect("~/Default.aspx", true);
        }
        if (!Page.IsPostBack)
        {
            LoadTenantsGrid();
        }
    }

    private void LoadTenantsGrid()
    {
        try
        {
            DataSet ds = null;
            Tenant tenant = new Tenant();
            ds = tenant.GetTenantData();
            if (ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                divGrid.Visible = true;
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
                divGrid.Visible = false;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Admin.aspx", true);
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        LoadTenantsGrid();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        lblWarning.Visible = false;
        LoadTenantsGrid();
        int tenantid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        Tenant tenant = new Tenant(tenantid);
        tenant.GetTenant();
        List<DateTimeConfirmed> dtcList = tenant.HasBookings();
        if (dtcList.Count > 0)
        {
            lblWarning.Text = string.Format("The following bookings must be deleted before you can delete {0}<br />", tenant.TenantName);
            foreach (DateTimeConfirmed dtc in dtcList)
            {
                lblWarning.Text += string.Format("{0} - {1}<br />", dtc.BookedDate.ToString("dd/MM/yyyy"), dtc.Confirmed ? "Confirmed" : "Pending");
            }
            lblWarning.Visible = true;
        }
        else
        {
            tenant.DeleteTenant();
        }
        LoadTenantsGrid();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        LoadTenantsGrid();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string strTenantID = row.Cells[0].Text;
            TextBox textTenantName = (TextBox)row.Cells[1].Controls[0];
            TextBox textAddress1 = (TextBox)row.Cells[2].Controls[0];
            TextBox textAddress2 = (TextBox)row.Cells[3].Controls[0];
            TextBox textTown = (TextBox)row.Cells[4].Controls[0];
            TextBox textCity = (TextBox)row.Cells[5].Controls[0];
            TextBox textCounty = (TextBox)row.Cells[6].Controls[0];
            TextBox textPostcode = (TextBox)row.Cells[7].Controls[0];
            TextBox textCountry = (TextBox)row.Cells[8].Controls[0];
            TextBox textEmail = (TextBox)row.Cells[9].Controls[0];
            TextBox textLandline = (TextBox)row.Cells[10].Controls[0];
            TextBox textMobile = (TextBox)row.Cells[11].Controls[0];
            TextBox textComments = (TextBox)row.Cells[12].Controls[0];

            int tenantID = 0;
            int.TryParse(strTenantID, out tenantID);

            GridView1.EditIndex = -1;

            Tenant tenant = new Tenant(tenantID);
            tenant.TenantName = textTenantName.Text;
            tenant.Address1 = textAddress1.Text;
            tenant.Address2 = textAddress2.Text;
            tenant.Town = textTown.Text;
            tenant.City = textCity.Text;
            tenant.County = textCounty.Text;
            tenant.Postcode = textPostcode.Text;
            tenant.Country = textCountry.Text;
            tenant.Email = textEmail.Text;
            tenant.Landline = textLandline.Text;
            tenant.Mobile = textMobile.Text;
            tenant.Comments = textComments.Text;

            tenant.UpdateTenant();
            LoadTenantsGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
            }
            else
            {
            }
        }
    }

    protected void btnAddTenant_Click(object sender, EventArgs e)
    {
        divAddTenant.Visible = true;
    }

    protected void btnSaveTenant_Click(object sender, EventArgs e)
    {
        lblWarning.Text = "";
        lblWarning.Visible = false;

        if (ValidFields())
        {
            Tenant tenant = new Tenant();
            tenant.TenantName = txtTenantName.Text;
            tenant.Address1 = txtAddress1.Text;
            tenant.Address2 = txtAddress2.Text;
            tenant.Town = txtTown.Text;
            tenant.City = txtCity.Text;
            tenant.County = txtCounty.Text;
            tenant.Postcode = txtPostcode.Text;
            tenant.Country = txtCountry.Text;
            tenant.Email = txtEmail.Text;
            tenant.Landline = txtLandline.Text;
            tenant.Mobile = txtMobile.Text;
            tenant.Comments = txtComments.Text;
            tenant.Insert();
            divAddTenant.Visible = false;
        }
        else
        {
            lblWarning.Visible = true;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }

    private bool ValidFields()
    {
        bool retVal = true;

        if (string.IsNullOrWhiteSpace(txtTenantName.Text))
        {
            retVal = false;
            lblWarning.Text += "Please provide your name<br />";
        }

        if ((string.IsNullOrWhiteSpace(txtAddress1.Text) && string.IsNullOrWhiteSpace(txtAddress2.Text))
            || (string.IsNullOrWhiteSpace(txtTown.Text) && string.IsNullOrWhiteSpace(txtCity.Text))
            || (string.IsNullOrWhiteSpace(txtCounty.Text) && string.IsNullOrWhiteSpace(txtCountry.Text)))
        {
            retVal = false;
            lblWarning.Text += "Please complete your address details<br />";
        }

        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            retVal = false;
            lblWarning.Text += "Please provide an email address<br />";
        }
        else if (!Utils.IsValidEmail(txtEmail.Text))
        {
            retVal = false;
            lblWarning.Text += "The email address provided is not valid<br />";
        }

        if (string.IsNullOrWhiteSpace(txtLandline.Text) && string.IsNullOrWhiteSpace(txtMobile.Text))
        {
            retVal = false;
            lblWarning.Text += "Please provide at least one phone number<br />";
        }

        return retVal;
    }
}
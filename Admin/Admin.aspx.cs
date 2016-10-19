using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Admin_Admin : System.Web.UI.Page
{
    protected DataSet dsBookings;
    public static List<DateTime> selectedDates = new List<DateTime>();
    private MySqlConnection cn = new MySqlConnection(Utils.ConnString);
    private List<DateTime> bookedDates = null;
    DateTime startDate = DateTime.MinValue;
    DateTime endDate = DateTime.MinValue;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["LoggedIn"]) == false)
        {
            Response.Redirect("~/Default.aspx", true);
        }
        if (!IsPostBack)
        {
            divTenant.Visible = false;
            Calendar1.VisibleDate = DateTime.Today;
            Session["SelectedDates"] = selectedDates;
        }
        else
        {
        }
        FillHolidayDataset();
    }

    protected void FillHolidayDataset()
    {
        DateTime firstDate = new DateTime(Calendar1.VisibleDate.Year,
            Calendar1.VisibleDate.Month, 1);
        DateTime lastDate = GetFirstDayOfNextMonth();
        dsBookings = GetCurrentMonthData(firstDate, lastDate);
    }

    protected DateTime GetFirstDayOfNextMonth()
    {
        int monthNumber, yearNumber;
        if (Calendar1.VisibleDate.Month == 12)
        {
            monthNumber = 1;
            yearNumber = Calendar1.VisibleDate.Year + 1;
        }
        else
        {
            monthNumber = Calendar1.VisibleDate.Month + 1;
            yearNumber = Calendar1.VisibleDate.Year;
        }
        DateTime lastDate = new DateTime(yearNumber, monthNumber, 1);
        return lastDate;
    }

    protected DataSet GetCurrentMonthData(DateTime firstDate,
         DateTime lastDate)
    {
        DataSet dsMonth = new DataSet();
        string sqlCmd = string.Format(
            @"SELECT b.BookingDate, b.Confirmed, t.TenantName
            FROM thebijouvilla.Bookings b
            INNER JOIN thebijouvilla.Tenants t 
            WHERE BookingDate >= '{0}' AND BookingDate < '{1}';",
            firstDate.ToString("yyyy-MM-dd HH:mm:ss"),
            lastDate.ToString("yyyy-MM-dd HH:mm:ss"));

        MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
        adr.SelectCommand.CommandType = CommandType.Text;
        try
        {
            adr.Fill(dsMonth); //opens and closes the DB connection automatically !! (fetches from pool)

            if (dsMonth != null && dsMonth.Tables.Count > 0)
            {
                bookedDates = new List<DateTime>();
                foreach (DataRow dr in dsMonth.Tables[0].Rows)
                {
                    bookedDates.Add((DateTime)dr["BookingDate"]);
                }
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = ex.Message;
        }
        finally
        {
            cn.Dispose(); // return connection to pool
        }
        return dsMonth;
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.Text = "";
        }
        else
        {
            DateTime nextDate;
            if (dsBookings != null && dsBookings.Tables.Count > 0)
            {
                foreach (DataRow dr in dsBookings.Tables[0].Rows)
                {
                    nextDate = (DateTime)dr["BookingDate"];
                    if (nextDate == e.Day.Date)
                    {
                        if (int.Parse(dr["Confirmed"].ToString()) == 1)
                        {
                            e.Cell.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            e.Cell.BackColor = System.Drawing.Color.Pink;
                        }
                    }

                }
            }
            if (e.Day.IsSelected == true)
            {
                DateTime selDate = e.Day.Date;
                bool alreadyBooked = false;
                if (dsBookings != null)
                {
                    foreach (DataRow dr in dsBookings.Tables[0].Rows)
                    {
                        DateTime dDate;
                        dDate = (DateTime)dr["BookingDate"];
                        if (dDate == selDate)
                        {
                            alreadyBooked = true;
                        }
                    }
                }

                if (!alreadyBooked)
                {
                    selectedDates.Add(selDate);
                }
                else
                {
                    lblStatus.Text = string.Format("{0} is already booked", selDate.ToString("dd/MM/yyyy"));
                    LoadTenantData(selDate);
                    LoadBookingsGrid(selDate);
                }
                Session["SelectedDates"] = selectedDates;
            }
        }
    }

    protected void Calendar1_VisibleMonthChanged(object sender,
        MonthChangedEventArgs e)
    {
        Utils.SelectedDate = new DateTime();
        GridView1.DataSource = null;
        lblStatus.Text = "No Records Found";
        divGrid.Visible = false;
        LoadBookingsGrid(Utils.SelectedDate);
        FillHolidayDataset();
    }

    private void LoadBookingsGrid(DateTime selDate)
    {
        string sqlCmd = string.Format("SELECT MIN(BookingID) AS BookingID FROM thebijouvilla.Bookings WHERE BookingDate = '{0}'; ", selDate.ToString("yyyy-MM-dd HH:mm:ss"));

        MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
        adr.SelectCommand.CommandType = CommandType.Text;
        DataTable dt = new DataTable();
        try
        {
            adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)

            if (dt.Rows.Count == 1)
            {
                int bookingID;
                int.TryParse(dt.Rows[0]["BookingID"].ToString(), out bookingID);
                if (bookingID > 0)
                {
                    LoadBookingsGrid(bookingID);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Dispose(); // return connection to pool
        }
    }

    private void LoadBookingsGrid(int bookingID)
    {
        try
        {
            string sqlCmd = @"SELECT RowID, BookingID, TenantID, DATE_FORMAT(BookingDate,'%d/%m/%Y') as BookingDate, Rate, Agency,
                CASE WHEN Confirmed = 1 THEN 'True' ELSE 'False' END AS Confirmed, Comments FROM thebijouvilla.Bookings WHERE BookingID = 
                ?BookingID ORDER BY RowID;";
            cn.Open();
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            adr.SelectCommand.Parameters.AddWithValue("?BookingID", bookingID);
            DataSet ds = new DataSet();
            adr.Fill(ds); //opens and closes the DB connection automatically !! (fetches from pool)
            if (ds.Tables[0].Rows.Count > 0)
            {
                Utils.tenantID = int.Parse(ds.Tables[0].Rows[0]["TenantID"].ToString());
                Utils.bookingID = int.Parse(ds.Tables[0].Rows[0]["BookingID"].ToString());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                divGrid.Visible = true;
            }
            else
            {
                Utils.bookingID = 0;
                Utils.tenantID = 0;
                lblStatus.Text = "No Records Found";
                divGrid.Visible = false;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Dispose(); // return connection to pool
        }
    }

    private void LoadTenantData(DateTime selDate)
    {
        string sqlCmd = string.Format("SELECT MIN(TenantID) AS TenantID FROM thebijouvilla.Bookings WHERE BookingDate = '{0}'; ", selDate.ToString("yyyy-MM-dd HH:mm:ss"));

        MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
        adr.SelectCommand.CommandType = CommandType.Text;
        DataTable dt = new DataTable();
        try
        {
            adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)

            if (dt.Rows.Count == 1)
            {
                int tenantID;
                int.TryParse(dt.Rows[0]["TenantID"].ToString(), out tenantID);
                if (tenantID > 0)
                {
                    LoadTenantData(tenantID);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Dispose(); // return connection to pool
        }
    }

    private void LoadTenantData(int tenantID)
    {
        Tenant tenant = new Tenant(tenantID);
        tenant.GetTenant();

        divTenant.Visible = true;
        hdnTenantID.Value = tenantID.ToString();
        txtName.Text = tenant.TenantName;
        txtAddress1.Text = tenant.Address1;
        txtAddress2.Text = tenant.Address2;
        txtTown.Text = tenant.Town;
        txtCity.Text = tenant.City;
        txtCounty.Text = tenant.County;
        txtPostcode.Text = tenant.Postcode;
        txtCountry.Text = tenant.Country;
        txtEmail.Text = tenant.Email;
        txtLandline.Text = tenant.Landline;
        txtMobile.Text = tenant.Mobile;
        txtComments.Text = tenant.Comments;
        chkPreviousTenant.Checked = tenant.PreviousTenant;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime selDate = new DateTime(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day);
        Utils.SelectedDate = selDate;
        GridView1.DataSource = null;
        Utils.bookingID = 0;
        Utils.tenantID = 0;
        lblStatus.Text = "No Records Found";
        divGrid.Visible = false;
        LoadBookingsGrid(Utils.SelectedDate);
        FillHolidayDataset();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LoadBookingsGrid(Utils.SelectedDate);
        int rowid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("delete FROM Bookings where RowID='" + rowid + "'", cn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            cn.Dispose();
        }

        FillHolidayDataset();
        LoadBookingsGrid(Utils.SelectedDate);
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        LoadBookingsGrid(Utils.SelectedDate);
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string textRowID = row.Cells[0].Text;
            TextBox textRate = (TextBox)row.Cells[4].Controls[0];
            TextBox textAgency = (TextBox)row.Cells[5].Controls[0];
            CheckBox chkEditConfirmed = (CheckBox)row.FindControl("chkEditConfirmed");
            TextBox textComments = (TextBox)row.Cells[7].Controls[0];

            Decimal rate = 0M;
            Decimal.TryParse(textRate.Text, out rate);
            string agency = textAgency.Text;
            bool confirmed = chkEditConfirmed.Checked;
            string comments = textComments.Text;
            int rowID = 0;
            int.TryParse(textRowID, out rowID);

            GridView1.EditIndex = -1;
            cn.Open();
            string sqlCmd = @"UPDATE thebijouvilla.Bookings Set 
                Rate = ?Rate, 
                Agency = ?Agency,
                Confirmed = ?Confirmed, 
                Comments = ?Comments 
                WHERE RowID = ?RowID ";
            MySqlCommand cmd = new MySqlCommand(sqlCmd, cn);
            cmd.Parameters.AddWithValue("Rate", rate);
            cmd.Parameters.AddWithValue("Agency", agency);
            cmd.Parameters.AddWithValue("Confirmed", confirmed);
            cmd.Parameters.AddWithValue("Comments", comments);
            cmd.Parameters.AddWithValue("RowID", rowID);
            cmd.ExecuteNonQuery();
            cn.Close();

            LoadBookingsGrid(Utils.SelectedDate);
            FillHolidayDataset();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        LoadBookingsGrid(Utils.SelectedDate);
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        LoadBookingsGrid(Utils.SelectedDate);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DateTime bd = DateTime.Parse(drview[3].ToString());
                e.Row.Cells[3].Text = bd.ToString("dd/MM/yyyy");
                CheckBox chkb = (CheckBox)e.Row.FindControl("chkEditConfirmed");
                if (drview[6].ToString() == "True")
                { chkb.Checked = true; }
                else { chkb.Checked = false; }
            }
            else
            {
                //Literal lblBD = (Literal)e.Row.Cells[4].Controls[0];
                DateTime bd = DateTime.MinValue;
                DateTime.TryParse(drview[3].ToString(), out bd);
                if (bd != DateTime.MinValue)
                {
                    e.Row.Cells[3].Text = bd.ToString("dd/MM/yyyy");
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string tenantName = txtName.Text;
        string address1 = txtAddress1.Text;
        string address2 = txtAddress2.Text;
        string town = txtTown.Text;
        string city = txtCity.Text;
        string county = txtCounty.Text;
        string postcode = txtPostcode.Text;
        string country = txtCountry.Text;
        string email = txtEmail.Text;
        string landline = txtLandline.Text;
        string mobile = txtMobile.Text;
        string comments = txtComments.Text;
        bool previousTenant = chkPreviousTenant.Checked;
        cn.Open();
        string sqlCmd = @"UPDATE Tenants Set TenantName = ?TenantName, Address1 = ?Address1, Address2 = ?Address2,
                        Town = ?Town, City = ?City, County = ?County, PostCode = ?Postcode, Country = ?Country,
                        Email = ?Email, Landline = ?Landline, Mobile = ?Mobile, Comments = ?Comments,
                        PreviousTenant = ?PreviousTenant WHERE TenantID = ?TenantID";

        MySqlCommand cmd = new MySqlCommand(sqlCmd, cn);
        cmd.Parameters.AddWithValue("TenantName", tenantName);
        cmd.Parameters.AddWithValue("Address1", address1);
        cmd.Parameters.AddWithValue("Address2", address2);
        cmd.Parameters.AddWithValue("Town", town);
        cmd.Parameters.AddWithValue("City", city);
        cmd.Parameters.AddWithValue("County", county);
        cmd.Parameters.AddWithValue("Postcode", postcode);
        cmd.Parameters.AddWithValue("Country", country);
        cmd.Parameters.AddWithValue("Email", email);
        cmd.Parameters.AddWithValue("Landline", landline);
        cmd.Parameters.AddWithValue("Mobile", mobile);
        cmd.Parameters.AddWithValue("Comments", comments);
        cmd.Parameters.AddWithValue("PreviousTenant", previousTenant);
        cmd.Parameters.AddWithValue("TenantID", Utils.tenantID);
        cmd.ExecuteNonQuery();
        cn.Close();

        LoadBookingsGrid(Utils.SelectedDate);
        FillHolidayDataset();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        LoadBookingsGrid(Utils.SelectedDate);
        FillHolidayDataset();
    }

    private bool ValidFields()
    {
        bool retVal = true;

        string[] startDateSplit = txtStartDate.Text.Split('/');
        if (startDateSplit.Length == 3)
        {
            startDate = new DateTime(int.Parse(startDateSplit[2]), int.Parse(startDateSplit[1]), int.Parse(startDateSplit[0]));
        }
        if (startDate == DateTime.MinValue)
        {
            retVal = false;
            lblWarning.Text += "Start Date must be selected<br />";
        }
        else
        {
            if (bookedDates != null && bookedDates.Contains(startDate))
            {
                retVal = false;
                lblWarning.Text += "The selected Start Date is unavailable<br />";
            }
            else
            {
                if (startDate < DateTime.Now)
                {
                    retVal = false;
                    lblWarning.Text += "Start Date cannot be in the past<br />";
                }
            }
        }

        string[] endDateSplit = txtEndDate.Text.Split('/');
        if (endDateSplit.Length == 3)
        {
            endDate = new DateTime(int.Parse(endDateSplit[2]), int.Parse(endDateSplit[1]), int.Parse(endDateSplit[0]));
        }
        if (endDate == DateTime.MinValue)
        {
            endDate = startDate;
        }
        else
        {
            if (bookedDates != null && bookedDates.Contains(endDate))
            {
                retVal = false;
                lblWarning.Text += "The selected End Date is unavailable<br />";
            }
            else
            {
                if (endDate < startDate)
                {
                    retVal = false;
                    lblWarning.Text += "End Date must be on or after the Start Date<br />";
                }
            }
        }

        if (startDate != DateTime.MinValue && endDate != DateTime.MinValue)
        {
            for (DateTime date = startDate.AddDays(1); date.Date <= endDate.AddDays(-1).Date; date = date.AddDays(1))
            {
                if (bookedDates.Contains(date))
                {
                    retVal = false;
                    lblWarning.Text += "The selected date range contains dates that are unavailable<br />";
                    break;
                }
            }
        }
        return retVal;
    }

    protected void btnAddDates_Click(object sender, EventArgs e)
    {
        divAddDates.Visible = true;
    }

    protected void btnSaveDates_Click(object sender, EventArgs e)
    {
        lblWarning.Text = "";
        lblWarning.Visible = false;

        if (ValidFields())
        {
            Booking booking = new Booking(startDate, endDate);
            booking.InsertBooking(Utils.bookingID, Utils.tenantID, true);
            txtStartDate.Text = "";
            txtEndDate.Text = "";
            startDate = new DateTime();
            endDate = new DateTime();
            divAddDates.Visible = false;
            LoadBookingsGrid(Utils.SelectedDate);
            FillHolidayDataset();
        }
        else
        {
            lblWarning.Visible = true;
        }
    }

    protected void btnCancelSaveDates_Click(object sender, EventArgs e)
    {
        lblWarning.Text = "";
        lblWarning.Visible = false;
        txtStartDate.Text = "";
        txtEndDate.Text = "";
        startDate = new DateTime();
        endDate = new DateTime();
        divAddDates.Visible = false;
    }

    protected void btnConfirmAll_Click(object sender, EventArgs e)
    {
        Booking booking = new Booking(Utils.bookingID);
        booking.ToggleConfirm(true);
        LoadBookingsGrid(Utils.SelectedDate);
        FillHolidayDataset();
    }

    protected void btnUnconfirmAll_Click(object sender, EventArgs e)
    {
        Booking booking = new Booking(Utils.bookingID);
        booking.ToggleConfirm(false);
        LoadBookingsGrid(Utils.SelectedDate);
        FillHolidayDataset();
    }

    protected void btnDeleteAll_Click(object sender, EventArgs e)
    {
        Booking booking = new Booking(Utils.bookingID);
        booking.Delete();
        LoadBookingsGrid(Utils.SelectedDate);
        FillHolidayDataset();
    }

    protected void btnEditRates_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Rates.aspx", true);
    }

    protected void btnEditTenants_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Tenants.aspx", true);
    }
}
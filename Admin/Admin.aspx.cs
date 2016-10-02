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
        else if (Calendar1.SelectedDates.Contains(Calendar1.SelectedDate) || Calendar1.SelectedDate == Calendar1.SelectedDate)
        {
            Calendar1.SelectedDates.Remove(Calendar1.SelectedDate);
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
            @"SELECT b.BookingDate, t.TenantName
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
        DateTime nextDate;
        if (dsBookings != null && dsBookings.Tables.Count > 0)
        {
            foreach (DataRow dr in dsBookings.Tables[0].Rows)
            {
                nextDate = (DateTime)dr["BookingDate"];
                if (nextDate == e.Day.Date)
                {
                    e.Cell.BackColor = System.Drawing.Color.Pink;
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
                lblStatus.Text = string.Format("{0} is already booked", selDate.ToShortDateString());
                divTenant.Visible = true;
                LoadTenantData(selDate);
                LoadBookingsGrid(selDate);
            }
            Session["SelectedDates"] = selectedDates;
        }
    }

    protected void Calendar1_VisibleMonthChanged(object sender,
        MonthChangedEventArgs e)
    {
        FillHolidayDataset();
    }

    private void LoadBookingsGrid(DateTime selDate)
    {
        try
        {
            string sqlCmd = string.Format(@"SELECT RowID, BookingID, BookingDate, TenantID, Rate, Agency,
                CASE WHEN Confirmed = 1 THEN 'True' ELSE 'False' END AS Confirmed, Comments FROM thebijouvilla.Bookings WHERE BookingID = 
                (SELECT BookingID FROM thebijouvilla.Bookings WHERE BookingDate = '{0}');", selDate.ToString("yyyy-MM-dd HH:mm:ss"));
            cn.Open();
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            adr.Fill(ds); //opens and closes the DB connection automatically !! (fetches from pool)
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
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
        try
        {
            string sqlCmd = string.Format(@"SELECT DISTINCT t.TenantID, t.TenantName, t.Address1, t.Address2, t.Town, t.City, t.County,
                t.PostCode, t.Country, t.Email, t.Landline, t.Mobile, t.Comments, t.PreviousTenant 
                FROM thebijouvilla.Bookings b INNER JOIN thebijouvilla.Tenants t ON b.TenantID = t.TenantID
                WHERE t.TenantID = (SELECT TenantID FROM thebijouvilla.Bookings WHERE BookingDate = '{0}');", selDate.ToString("yyyy-MM-dd HH:mm:ss"));

            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)

            if (dt.Rows.Count > 0)
            {
                hdnTenantID.Value = dt.Rows[0]["TenantID"].ToString();
                txtName.Text = dt.Rows[0]["TenantName"].ToString();
                txtAddress1.Text = dt.Rows[0]["Address1"].ToString();
                txtAddress2.Text = dt.Rows[0]["Address2"].ToString();
                txtTown.Text = dt.Rows[0]["Town"].ToString();
                txtCity.Text = dt.Rows[0]["City"].ToString();
                txtCounty.Text = dt.Rows[0]["County"].ToString();
                txtPostcode.Text = dt.Rows[0]["PostCode"].ToString();
                txtCountry.Text = dt.Rows[0]["Country"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtLandline.Text = dt.Rows[0]["Landline"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtComments.Text = dt.Rows[0]["Comments"].ToString();
                chkPreviousTenant.Checked = dt.Rows[0]["Comments"].ToString() == "1";
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

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        Utils.SelectedDate = Calendar1.SelectedDate;
        GridView1.DataSource = null;
        FillHolidayDataset();
        if (Session["SelectedDates"] != null)
        {
            List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
            foreach (DateTime dt in newList)
            {
                if (Calendar1.SelectedDates.Contains(dt) || Calendar1.SelectedDate == dt)
                {
                    Calendar1.SelectedDates.Remove(dt);
                }
                else
                {
                    Calendar1.SelectedDates.Add(dt);
                }
            }
            selectedDates.Clear();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblRowID");
        cn.Open();
        MySqlCommand cmd = new MySqlCommand("delete FROM Bookings where RowID='" + Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString()) + "'", cn);
        cmd.ExecuteNonQuery();
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
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string textRowID = row.Cells[0].Text;
            TextBox textBookingID = (TextBox)row.Cells[1].Controls[0];
            TextBox textTenantID = (TextBox)row.Cells[2].Controls[0];
            TextBox textRate = (TextBox)row.Cells[3].Controls[0];
            TextBox textBookingDate = (TextBox)row.Cells[4].Controls[0];
            TextBox textAgency = (TextBox)row.Cells[5].Controls[0];
            CheckBox chkEditConfirmed = (CheckBox)row.FindControl("chkEditConfirmed");
            TextBox textComments = (TextBox)row.Cells[7].Controls[0];

            int bookingID = 0;
            int.TryParse(textBookingID.Text, out bookingID);
            DateTime bookingDate = DateTime.MinValue;
            DateTime.TryParse(textBookingDate.Text, out bookingDate);
            int tenantID = 0;
            int.TryParse(textTenantID.Text, out tenantID);
            Decimal rate = 0M;
            Decimal.TryParse(textRate.Text, out rate);
            string agency = textAgency.Text;
            //int confirmed = chkEditConfirmed.Checked == true ? 1 : 0;
            bool confirmed = chkEditConfirmed.Checked;
            string comments = textComments.Text;
            int rowID = 0;
            int.TryParse(textRowID, out rowID);

            GridView1.EditIndex = -1;
            cn.Open();
            string sqlCmd = @"UPDATE thebijouvilla.Bookings Set 
                BookingID = ?BookingID, 
                BookingDate = ?BookingDate, 
                TenantID = ?TenantID, 
                Rate = ?Rate, 
                Agency = ?Agency,
                Confirmed = ?Confirmed, 
                Comments = ?Comments 
                WHERE RowID = ?RowID ";
            MySqlCommand cmd = new MySqlCommand(sqlCmd, cn);
            cmd.Parameters.AddWithValue("BookingID", bookingID);
            cmd.Parameters.AddWithValue("BookingDate", bookingDate.Date);
            cmd.Parameters.AddWithValue("TenantID", tenantID);
            cmd.Parameters.AddWithValue("Rate", rate);
            cmd.Parameters.AddWithValue("Agency", agency);
            cmd.Parameters.AddWithValue("Confirmed", confirmed);
            cmd.Parameters.AddWithValue("Comments", comments);
            cmd.Parameters.AddWithValue("RowID", rowID);
            cmd.ExecuteNonQuery();
            cn.Close();

            LoadBookingsGrid(Utils.SelectedDate);
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
                TextBox txtBD = (TextBox)e.Row.Cells[4].Controls[0];
                DateTime bd = DateTime.Parse(drview[2].ToString());
                txtBD.Text = bd.ToString("dd/MM/yyyy");
                CheckBox chkb = (CheckBox)e.Row.FindControl("chkEditConfirmed");
                if (drview[6].ToString() == "True")
                { chkb.Checked = true; }
                else { chkb.Checked = false; }
            }
        }
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    DropDownList dp = (DropDownList)e.Row.FindControl("DrpDwnAddEmpDept");
        //    dp.DataSource = GetEmpDept();
        //    dp.DataTextField = "DepName";
        //    dp.DataValueField = "DepName";
        //    dp.DataBind();
        //}
    }
}
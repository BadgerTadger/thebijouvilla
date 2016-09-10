using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Admin_Admin : System.Web.UI.Page
{
    protected DataSet dsBookings;
    public static List<DateTime> selectedDates = new List<DateTime>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadRatesGrid();
            Calendar1.VisibleDate = DateTime.Today;
            Session["SelectedDates"] = selectedDates;
        }
        else if (Calendar1.SelectedDates.Contains(Calendar1.SelectedDate) || Calendar1.SelectedDate == Calendar1.SelectedDate)
        {
            Calendar1.SelectedDates.Remove(Calendar1.SelectedDate);
        }
        divTenant.Visible = false;
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
        MySqlConnection cn = new MySqlConnection(Utils.ConnString);
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

    private void LoadRatesGrid()
    {
        MySqlConnection cn = new MySqlConnection(Utils.ConnString);

        try
        {
            string sqlCmd = string.Format("SELECT * FROM thebijouvilla.Rates where Type = '{0}';", rblRateFrequency.SelectedValue.ToString());

            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)

            gvRates.DataSource = dt;
            gvRates.DataBind();
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

    private void LoadBookingsGrid(DateTime selDate)
    {
        MySqlConnection cn = new MySqlConnection(Utils.ConnString);

        try
        {
            string sqlCmd = string.Format(@"SELECT RowID, BookingID, BookingDate, TenantID, RateID, Agency,
                Confirmed, Comments FROM thebijouvilla.Bookings WHERE BookingID = 
                (SELECT BookingID FROM thebijouvilla.Bookings WHERE BookingDate = '{0}');", selDate.ToString("yyyy-MM-dd HH:mm:ss"));

            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            adr.Fill(dt); //opens and closes the DB connection automatically !! (fetches from pool)

            gvBookings.DataSource = dt;
            gvBookings.DataBind();
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
        MySqlConnection cn = new MySqlConnection(Utils.ConnString);

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

            if(dt.Rows.Count > 0)
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

    protected void rblRateFrequency_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadRatesGrid();
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        gvBookings.DataSource = null;
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
}
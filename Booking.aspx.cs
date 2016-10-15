using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Diagnostics;

public partial class Booking_Booking : System.Web.UI.Page
{
    protected DataSet dsBookings;
    private List<DateTimeConfirmed> bookedDates = null;
    DateTime startDate = DateTime.MinValue;
    DateTime endDate = DateTime.MinValue;
    int _bookingID = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Calendar1.VisibleDate = DateTime.Today;
        }
        else
        {
        }
        FillHolidayDataset();
    }

    protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        Context.GetOwinContext().Authentication.SignOut();
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
            @"SELECT b.BookingDate, b.Confirmed, t.TenantName
            FROM thebijouvilla.Bookings b
            INNER JOIN thebijouvilla.Tenants t 
            WHERE BookingDate >= '{0}' AND BookingDate < '{1}'",
            firstDate.ToString("yyyy-MM-dd HH:mm:ss"),
            lastDate.ToString("yyyy-MM-dd HH:mm:ss"));

        MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
        adr.SelectCommand.CommandType = CommandType.Text;
        try
        {
            adr.Fill(dsMonth); //opens and closes the DB connection automatically !! (fetches from pool)

            if (dsMonth != null && dsMonth.Tables.Count > 0)
            {
                bookedDates = new List<DateTimeConfirmed>();
                foreach (DataRow dr in dsMonth.Tables[0].Rows)
                {
                    DateTimeConfirmed dtc = new DateTimeConfirmed((DateTime)dr["BookingDate"], dr["Confirmed"].ToString() == "1");
                    bookedDates.Add(dtc);
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
            if (bookedDates != null)
            {
                foreach (DateTimeConfirmed dtc in bookedDates)
                {
                    if (dtc.BookedDate == e.Day.Date)
                    {
                        if (dtc.Confirmed)
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
        }
    }

    protected void Calendar1_VisibleMonthChanged(object sender,
        MonthChangedEventArgs e)
    {
        FillHolidayDataset();
    }

    protected void btnBook_Click(object sender, EventArgs e)
    {
        lblWarning.Text = "";
        lblWarning.Visible = false;

        if (ValidFields())
        {
            if (SaveBooking())
            {
                ClearFormFields();
                Response.Redirect("~/ThankYou.aspx", true);
            }
        }
        else
        {
            lblWarning.Visible = true;
        }
    }

    private bool SaveBooking()
    {
        Booking booking = new Booking(startDate, endDate, txtTenantName.Text, txtAddress1.Text, txtAddress2.Text, txtTown.Text,
            txtCity.Text, txtCounty.Text, txtPostcode.Text, txtCountry.Text, txtEmail.Text, txtLandline.Text, txtMobile.Text, txtComments.Text);

        if (booking.SaveBooking())
        {
            if (Debugger.IsAttached)
            {
                return true;
            }
            else if (booking.SendEmail())
            {
                return true;
            }
        }
        return false;
    }

    private bool ValidFields()
    {
        lblWarning.Text = "";
        lblWarning.Visible = false;
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
            if (bookedDates != null)
            {
                foreach (DateTimeConfirmed dtc in bookedDates)
                {
                    if (dtc.BookedDate == startDate)
                    {
                        retVal = false;
                        lblWarning.Text += "The selected Start Date is unavailable<br />";
                        break;
                    }
                }
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

        if (retVal)
        {
            txtEndDate.Value = startDate.AddDays(6).ToString("dd/MM/yyyy");
            string[] endDateSplit = txtEndDate.Value.Split('/');
            if (endDateSplit.Length == 3)
            {
                endDate = new DateTime(int.Parse(endDateSplit[2]), int.Parse(endDateSplit[1]), int.Parse(endDateSplit[0]));
            }
        }
        //if (endDate == DateTime.MinValue)
        //{
        //    retVal = false;
        //    lblWarning.Text += "End Date must be selected<br />";
        //}
        //else
        //{
        //    if (bookedDates != null && bookedDates.Contains(endDate))
        //    {
        //        lblWarning.Text += "The selected End Date is unavailable<br />";
        //    }
        //    else
        //    {
        //        if(endDate <= startDate.AddDays(2))
        //        {
        //            lblWarning.Text += "End Date must be at least 2 days after the Start Date<br />";
        //        }
        //    }
        //}

        if (startDate != DateTime.MinValue && endDate != DateTime.MinValue)
        {
            for (DateTime date = startDate.AddDays(1); date.Date <= endDate.AddDays(-1).Date; date = date.AddDays(1))
            {
                if (bookedDates != null)
                {
                    foreach (DateTimeConfirmed dtc in bookedDates)
                    {
                        if (dtc.BookedDate == date)
                        {
                            retVal = false;
                            lblWarning.Text += "The selected date range contains dates that are unavailable<br />";
                            break;
                        }
                    }
                }
            }
        }

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

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearFormFields();
    }

    private void ClearFormFields()
    {
        lblWarning.Text = "";
        lblWarning.Visible = false;
        txtStartDate.Text = "";
        txtEndDate.Value = "";
        txtTenantName.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtTown.Text = "";
        txtCity.Text = "";
        txtCounty.Text = "";
        txtPostcode.Text = "";
        txtCountry.Text = "";
        txtEmail.Text = "";
        txtLandline.Text = "";
        txtMobile.Text = "";
        txtComments.Text = "";
    }
}
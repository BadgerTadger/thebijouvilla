using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Booking_Booking : System.Web.UI.Page
{
    MySqlConnection conn;
    protected DataSet dsBookings;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Calendar1.VisibleDate = DateTime.Today;
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
    }

    protected void Calendar1_VisibleMonthChanged(object sender,
        MonthChangedEventArgs e)
    {
        FillHolidayDataset();
    }
}
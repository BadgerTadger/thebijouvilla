using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for Booking
/// </summary>
public class Booking
{
    private MySqlConnection cn = new MySqlConnection(Utils.ConnString);

    private int _rowID;
    public int RowID
    {
        get { return _rowID; }
        set { _rowID = value; }
    }

    private int _bookingID;
    public int BookingID
    {
        get { return _bookingID; }
        set { _bookingID = value; }
    }

    private DateTime _bookingDate;
    public DateTime BookingDate
    {
        get { return _bookingDate; }
        set { _bookingDate = value; }
    }

    private decimal _rate;
    public decimal Rate
    {
        get { return _rate; }
        set { _rate = value; }
    }

    private string _agency;
    public string Agency
    {
        get { return _agency; }
        set { _agency = value; }
    }

    private bool _confirmed;
    public bool Confirmed
    {
        get { return _confirmed; }
        set { _confirmed = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }

    private DateTime _startDate;
    public DateTime StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }

    private DateTime _endDate;
    public DateTime EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
    }

    private Tenant _tenant;

    public Tenant Tenant
    {
        get { return _tenant; }
        set { _tenant = value; }
    }


    public Booking(int bookingID)
    {
        _bookingID = bookingID;
        _tenant = new Tenant();
    }

    public Booking()
    {
        _tenant = new Tenant();
    }

    public Booking(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    public Booking(DateTime startDate, DateTime endDate, string tenantName, string address1, string address2, string town,
        string city, string county, string postcode, string country, string email, string landline, string mobile, string comments, string agency)
    {
        _startDate = startDate;
        _endDate = endDate;
        _agency = agency;
        _tenant = new Tenant();
        _tenant.TenantName = tenantName;
        _tenant.Address1 = address1;
        _tenant.Address2 = address2;
        _tenant.Town = town;
        _tenant.City = city;
        _tenant.County = county;
        _tenant.Postcode = postcode;
        _tenant.Country = country;
        _tenant.Email = email;
        _tenant.Landline = landline;
        _tenant.Mobile = mobile;
        _tenant.Comments = comments;
    }

    public bool SaveBooking()
    {
        bool retVal = false;

        _bookingID = GetNextBookingID();
        int tenantID = _tenant.Insert();
        if(InsertBooking(_bookingID, tenantID, _agency, _comments))
        {
            Utils.bookingID = _bookingID;
            retVal = true;
        }

        return retVal;
    }

    public void GetBooking()
    {
        try
        {
            string sqlCmd = @"SELECT RowID, TenantID, DATE_FORMAT(BookingDate,'%d/%m/%Y') as BookingDate, Rate, Agency,
                CASE WHEN Confirmed = 1 THEN 'True' ELSE 'False' END AS Confirmed, Comments FROM thebijouvilla.Bookings WHERE BookingID = 
                ?BookingID ORDER BY RowID;";

            cn.Open();
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            adr.SelectCommand.Parameters.AddWithValue("?BookingID", _bookingID);
            DataSet ds = new DataSet();
            adr.Fill(ds); //opens and closes the DB connection automatically !! (fetches from pool)
            if (ds.Tables[0].Rows.Count > 0)
            {
                {
                    _rowID = int.Parse(ds.Tables[0].Rows[0]["RowID"].ToString());
                    _tenant = new Tenant(int.Parse(ds.Tables[0].Rows[0]["TenantID"].ToString()));
                    _tenant.GetTenant();
                    _bookingDate = DateTime.Parse(ds.Tables[0].Rows[0]["BookingDate"].ToString());
                    _rate = decimal.Parse(ds.Tables[0].Rows[0]["Rate"].ToString());
                    _agency = ds.Tables[0].Rows[0]["Agency"].ToString();
                    _confirmed = ds.Tables[0].Rows[0]["Confirmed"].ToString() == "1";
                    _comments = ds.Tables[0].Rows[0]["Comments"].ToString();
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

    private int GetNextBookingID()
    {
        int retVal = -1;

        string query = "SELECT CASE WHEN MAX(Bookings.BookingID) IS NULL THEN 0 ELSE MAX(Bookings.BookingID) END AS BookingId FROM Bookings";
        string connString = Utils.ConnString;
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    connection.Open();
                    var bookingID = command.ExecuteScalar();
                    if (bookingID != null)
                    {
                        retVal = Convert.ToInt32(bookingID);
                    }
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            }
        }

        return retVal += 1;
    }

    public bool InsertBooking(int bookingId, int tenantID, string agency, string comments)
    {
        return InsertBooking(bookingId, tenantID, agency, comments, false);
    }

    public bool InsertBooking(int bookingId, int tenantID, bool confirm)
    {
        return InsertBooking(bookingId, tenantID, "", "", confirm);
    }

    public bool InsertBooking(int bookingId, int tenantID, string agency, string comments, bool confirm)
    {
        bool retVal = true;
        string query = @"INSERT INTO Bookings(BookingID,TenantID,Rate,BookingDate,Agency,Confirmed,Comments)
                    VALUES(?BookingID,?TenantID,?Rate,?BookingDate,?Agency,?Confirmed,?Comments)";

        string connString = Utils.ConnString;
        double days = (_endDate - _startDate).TotalDays;
        for (int i = 0; i <= (days); i++)
        {
            decimal rate = GetRate(_startDate.AddDays(i));
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("?BookingID", bookingId);
                    command.Parameters.AddWithValue("?TenantID", tenantID);
                    command.Parameters.AddWithValue("?Rate", rate);
                    command.Parameters.AddWithValue("?BookingDate", _startDate.AddDays(i));
                    command.Parameters.AddWithValue("?Agency", agency);
                    command.Parameters.AddWithValue("?Confirmed", confirm);
                    command.Parameters.AddWithValue("?Comments", comments);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        retVal = false;
                        throw ex;
                    }
                }
                connection.Close();
            }
        }

        return retVal;
    }

    public void ToggleConfirm(bool confirm)
    {
        string query = @"UPDATE Bookings SET Confirmed=?Confirmed WHERE BookingID=?BookingID";

        string connString = Utils.ConnString;
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("?Confirmed", confirm);
                command.Parameters.AddWithValue("?BookingID", _bookingID);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            }
        }
    }

    public void Delete()
    {
        string query = @"DELETE FROM Bookings WHERE BookingID=?BookingID";

        string connString = Utils.ConnString;
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("?BookingID", _bookingID);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            }
        }
    }

    private decimal GetRate(DateTime bookingDate)
    {
        Rates rates = new Rates();
        return rates.GetRateForBooking(bookingDate);
    }

    private string EmailBody()
    {
        string retVal = "";

        retVal = string.Format(@"Booking Dates: {0} to {1}<br />Name: {2}<br />Email: {3}",
            _startDate.ToString("dd/MM/yyyy"), _endDate.ToString("dd/MM/yyyy"), _tenant.TenantName, _tenant.Email);

        return retVal;
    }

    public bool SendEmail()
    {
        bool retVal = false;

        try
        {
            MailAddress fAddress = new MailAddress("bookings@thebijouvilla.com");
            MailAddress tAddress = new MailAddress("darencantrell@gmail.com");
            MailMessage message = new MailMessage(fAddress, tAddress);
            message.IsBodyHtml = true;
            message.Subject = "Online Booking Request";
            message.Body = EmailBody();

            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25);
            client.Send(message);

            retVal = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return retVal;
    }
}
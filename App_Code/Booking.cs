using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Booking
/// </summary>
public class Booking
{
    private int _bookingID;
    public int BookingID
    {
        get { return _bookingID; }
        set { _bookingID = value; }
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

    private string _tenantName;
    public string TenantName
    {
        get { return _tenantName; }
        set { _tenantName = value; }
    }

    private string _address1;
    public string Address1
    {
        get { return _address1; }
        set { _address1 = value; }
    }

    private string _address2;
    public string Address2
    {
        get { return _address2; }
        set { _address2 = value; }
    }

    private string _town;
    public string Town
    {
        get { return _town; }
        set { _town = value; }
    }

    private string _city;
    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    private string _county;
    public string County
    {
        get { return _county; }
        set { _county = value; }
    }

    private string _postcode;
    public string Postcode
    {
        get { return _postcode; }
        set { _postcode = value; }
    }

    private string _country;
    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    private string _landline;
    public string Landline
    {
        get { return _landline; }
        set { _landline = value; }
    }

    private string _mobile;
    public string Mobile
    {
        get { return _mobile; }
        set { _mobile = value; }
    }

    private string _comments;
    public string Comments
    {
        get { return _comments; }
        set { _comments = value; }
    }

    public Booking(int bookingID)
    {
        _bookingID = bookingID;
    }

    public Booking(DateTime startDate, DateTime endDate)
    {
        _startDate = startDate;
        _endDate = endDate;
    }

    public Booking(DateTime startDate, DateTime endDate, string tenantName, string address1, string address2, string town,
        string city, string county, string postcode, string country, string email, string landline, string mobile, string comments)
    {
        _startDate = startDate;
        _endDate = endDate;
        _tenantName = tenantName;
        _address1 = address1;
        _address2 = address2;
        _town = town;
        _city = city;
        _county = county;
        _postcode = postcode;
        _country = country;
        _email = email;
        _landline = landline;
        _mobile = mobile;
        _comments = comments;
    }

    public bool SaveBooking()
    {
        bool retVal = false;

        int bookingId = GetNextBookingID();
        int tenantID = InsertTenant();
        retVal = InsertBooking(bookingId, tenantID, "", "");

        return retVal;
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

    private int InsertTenant()
    {
        int retVal = -1;

        string query = @"INSERT INTO Tenants(TenantName,Address1,Address2,Town,City,County,PostCode,Country,Email,Landline,Mobile,Comments)
                VALUES(?TenantName,?Address1,?Address2,?Town,?City,?County,?PostCode,?Country,?Email,?Landline,?Mobile,?Comments)";

        string connString = Utils.ConnString;
        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("?TenantName", _tenantName);
                command.Parameters.AddWithValue("?Address1", _address1);
                command.Parameters.AddWithValue("?Address2", _address2);
                command.Parameters.AddWithValue("?Town", _town);
                command.Parameters.AddWithValue("?City", _city);
                command.Parameters.AddWithValue("?County", _county);
                command.Parameters.AddWithValue("?Postcode", _postcode);
                command.Parameters.AddWithValue("?Country", _country);
                command.Parameters.AddWithValue("?Email", _email);
                command.Parameters.AddWithValue("?Landline", _landline);
                command.Parameters.AddWithValue("?Mobile", _mobile);
                command.Parameters.AddWithValue("?Comments", _comments);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    retVal = Convert.ToInt32(command.LastInsertedId);
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            }
        }

        return retVal;
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
}
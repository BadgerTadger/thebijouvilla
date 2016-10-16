using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Tenant
/// </summary>
public class Tenant
{
    private MySqlConnection cn = new MySqlConnection(Utils.ConnString);

    private int _tenantID;
    public int TenantID
    {
        get { return _tenantID; }
        set { _tenantID = value; }
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

    private bool _previousTenant = false;
    public bool PreviousTenant
    {
        get { return _previousTenant; }
        set { _previousTenant = value; }
    }

    public Tenant()
    {

    }

    public Tenant(int tenantID)
    {
        _tenantID = tenantID;
    }

    public void GetTenant()
    {
        try
        {
            string sqlCmd = @"SELECT TenantName, Address1, Address2, Town, City, County,
                PostCode, Country, Email, Landline, Mobile, Comments, PreviousTenant FROM thebijouvilla.Tenants
                WHERE TenantID = ?TenantID";

            cn.Open();
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            adr.SelectCommand.Parameters.AddWithValue("?TenantID", _tenantID);
            DataSet ds = new DataSet();
            adr.Fill(ds); //opens and closes the DB connection automatically !! (fetches from pool)
            if (ds.Tables[0].Rows.Count > 0)
            {
                {
                    _tenantName = ds.Tables[0].Rows[0]["TenantName"].ToString();
                    _address1 = ds.Tables[0].Rows[0]["Address1"].ToString();
                    _address2 = ds.Tables[0].Rows[0]["Address2"].ToString();
                    _town = ds.Tables[0].Rows[0]["Town"].ToString();
                    _city = ds.Tables[0].Rows[0]["City"].ToString();
                    _county = ds.Tables[0].Rows[0]["County"].ToString();
                    _postcode = ds.Tables[0].Rows[0]["PostCode"].ToString();
                    _country = ds.Tables[0].Rows[0]["Country"].ToString();
                    _email = ds.Tables[0].Rows[0]["Email"].ToString();
                    _landline = ds.Tables[0].Rows[0]["Landline"].ToString();
                    _mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    _comments = ds.Tables[0].Rows[0]["Comments"].ToString();
                    _previousTenant = ds.Tables[0].Rows[0]["Comments"].ToString() == "1";
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

    public DataSet GetTenantData()
    {
        DataSet retVal = null;
        try
        {
            string sqlCmd = @"SELECT TenantID, TenantName, Address1, Address2, Town, City, County,
                PostCode, Country, Email, Landline, Mobile, Comments, PreviousTenant FROM thebijouvilla.Tenants";

            cn.Open();
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            adr.Fill(ds); //opens and closes the DB connection automatically !! (fetches from pool)
            if (ds.Tables[0].Rows.Count > 0)
            {
                {
                    retVal = ds;
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
        return retVal;
    }

    public List<DateTimeConfirmed> HasBookings()
    {
        List<DateTimeConfirmed> dtcList = new List<DateTimeConfirmed>();

        try
        {
            string sqlCmd = @"SELECT BookingDate, Confirmed FROM thebijouvilla.Bookings
                            WHERE TenantID = ?TenantID ORDER BY BookingDate";

            cn.Open();
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            adr.SelectCommand.Parameters.AddWithValue("?TenantID", _tenantID);
            DataSet ds = new DataSet();
            adr.Fill(ds); //opens and closes the DB connection automatically !! (fetches from pool)
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    DateTimeConfirmed dtc = new DateTimeConfirmed((DateTime)row["BookingDate"], row["Confirmed"].ToString() == "1");
                    dtcList.Add(dtc);
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

        return dtcList;
    }

    public void DeleteTenant()
    {
        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("delete FROM Tenants where TenantID='" + _tenantID + "'", cn);
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
    }

    public int Insert()
    {
        int retVal = -1;
        int tenantId = GetNextTenantID();

        string query = @"INSERT INTO Tenants(TenantName,Address1,Address2,Town,City,County,PostCode,Country,Email,Landline,Mobile,Comments,PreviousTenant)
                VALUES(?TenantName,?Address1,?Address2,?Town,?City,?County,?PostCode,?Country,?Email,?Landline,?Mobile,?Comments,?PreviousTenant)";

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
                command.Parameters.AddWithValue("?PreviousTenant", _previousTenant);
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

    private int GetNextTenantID()
    {
        int retVal = 0;

        string query = "SELECT CASE WHEN MAX(Tenants.TenantID) IS NULL THEN 0 ELSE MAX(Tenants.TenantID) END AS TenantID FROM Tenants";
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

    public void UpdateTenant()
    {
        cn.Open();
        string sqlCmd = @"UPDATE Tenants Set                 
                TenantName = ?TenantName,
                Address1 = ?Address1,
                Address2 = ?Address2,
                Town = ?Town,
                City = ?City,
                County = ?County,
                Postcode = ?Postcode,
                Country = ?Country,
                Email = ?Email,
                Landline = ?Landline,
                Mobile = ?Mobile,
                Comments = ?Comments,
                PreviousTenant = ?PreviousTenant
                WHERE TenantID = ?TenantID ";
        MySqlCommand cmd = new MySqlCommand(sqlCmd, cn);
        cmd.Parameters.AddWithValue("TenantName", _tenantName);
        cmd.Parameters.AddWithValue("Address1", _address1);
        cmd.Parameters.AddWithValue("Address2", _address2);
        cmd.Parameters.AddWithValue("Town", _town);
        cmd.Parameters.AddWithValue("City", _city);
        cmd.Parameters.AddWithValue("County", _county);
        cmd.Parameters.AddWithValue("Postcode", _postcode);
        cmd.Parameters.AddWithValue("Country", _country);
        cmd.Parameters.AddWithValue("Email", _email);
        cmd.Parameters.AddWithValue("Landline", _landline);
        cmd.Parameters.AddWithValue("Mobile", _mobile);
        cmd.Parameters.AddWithValue("Comments", _comments);
        cmd.Parameters.AddWithValue("PreviousTenant", _previousTenant);
        cmd.Parameters.AddWithValue("TenantID", _tenantID);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw ex;
        }
        cn.Close();
    }
}
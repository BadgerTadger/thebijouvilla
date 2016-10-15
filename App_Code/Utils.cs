using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Utils
/// </summary>
public static class Utils
{
    //public static Utils()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    public const string ConnString = "Server = 50.62.209.119; Port = 3306; Database = thebijouvilla; Uid = badgertadger; Pwd = Motorhome99";

    public static MySqlConnection GetDBConnection()
    {
        MySqlConnection mySqlConnection = new MySqlConnection();
        mySqlConnection.ConnectionString = ConnString;

        try
        {
            mySqlConnection.Open();

            switch (mySqlConnection.State)
            {
                case System.Data.ConnectionState.Open:
                    // Connection has been made
                    break;
                case System.Data.ConnectionState.Closed:
                    // Connection could not be made, throw an error
                    throw new Exception("The database connection state is Closed");
                default:
                    // Connection is actively doing something else
                    break;
            }

            // Place Your Code Here to Process Data //
        }
        catch (MySqlException mySqlException)
        {
            throw mySqlException;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            // Make sure to only close connections that are not in a closed state
            if (mySqlConnection.State != System.Data.ConnectionState.Closed)
            {
                // Close the connection as a good Garbage Collecting practice
                mySqlConnection.Close();
            }
        }

        return mySqlConnection;
    }

    public static DateTime SelectedDate { get; set; }
    public static int bookingID { get; set; }
    public static int tenantID { get; set; }

    public static bool IsValidEmail(string emailaddress)
    {
        return Regex.IsMatch(emailaddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    }
}
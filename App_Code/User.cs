using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private string _userName;
    public string UserName
    {
        get { return _userName; }
        set { _userName = value; }
    }

    private string _password;

    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }

    private bool _loggedIn;
    public bool LoggedIn
    {
        get { return _loggedIn; }
        set { _loggedIn = value; }
    }

    public User(string username, string password)
    {
        _userName = username;
        _password = password;
    }

    public bool Login()
    {
        bool retVal = false;

        string query = @"SELECT COUNT(UserName) FROM Users WHERE UserName=?UserName AND Password=?Password";

        string connString = Utils.ConnString;

        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("?UserName", _userName);
                command.Parameters.AddWithValue("?Password", _password);
                try
                {
                    connection.Open();
                    var rowCount = command.ExecuteScalar();
                    if (rowCount != null)
                    {
                        _loggedIn = Convert.ToInt32(rowCount) == 1;
                    }
                    retVal = _loggedIn;
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            }
        }
        return retVal;
    }
}
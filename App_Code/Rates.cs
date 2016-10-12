using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Rates
/// </summary>
public class Rates
{
    public Rates()
    {
    }

    public decimal GetRateForBooking(DateTime bookingDate)
    {
        decimal retVal = 0M;

        string query = @"SELECT Rate FROM Rates WHERE StartDate<=?BookingDate AND EndDate>=?BookingDate";

        string connString = Utils.ConnString;

        using (MySqlConnection connection = new MySqlConnection(connString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("?BookingDate", bookingDate);
                try
                {
                    connection.Open();
                    var rate = command.ExecuteScalar();
                    if (rate != null)
                    {
                        retVal = Convert.ToDecimal(rate);
                    }
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            }
        }
        return retVal;
    }

    public void Insert(DateTime startDate, DateTime endDate, decimal rate)
    {
        int rateId = GetNextRateID();

        string query = @"INSERT INTO Rates(RateID,StartDate,EndDate,Rate)
                    VALUES(?RateID,?StartDate,?EndDate,?Rate)";

        string connString = Utils.ConnString;
        double days = (endDate - startDate).TotalDays;
        for (int i = 0; i <= (days); i++)
        {
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("?RateID", rateId);
                    command.Parameters.AddWithValue("?StartDate", startDate);
                    command.Parameters.AddWithValue("?EndDate", endDate);
                    command.Parameters.AddWithValue("?Rate", rate);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (MySqlException ex)
                    {
                        throw ex;
                    }
                }
                connection.Close();
            }
        }
    }

    private int GetNextRateID()
    {
        int retVal = -1;

        string query = "SELECT CASE WHEN MAX(Rates.RateID) IS NULL THEN 0 ELSE MAX(Rates.RateID) END AS RateID FROM Rates";
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
}
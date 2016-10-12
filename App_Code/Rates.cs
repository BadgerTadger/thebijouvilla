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
}
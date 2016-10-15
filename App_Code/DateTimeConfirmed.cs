using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DateTimeConfirmed
/// </summary>
public class DateTimeConfirmed
{
    private DateTime _bookedDate;
    public DateTime BookedDate
    {
        get { return _bookedDate; }
        set { _bookedDate = value; }
    }

    private bool _confirmed;
    public bool Confirmed
    {
        get { return _confirmed; }
        set { _confirmed = value; }
    }


    public DateTimeConfirmed(DateTime bookedDate, bool confirmed)
    {
        _bookedDate = bookedDate;
        _confirmed = confirmed;
    }
}
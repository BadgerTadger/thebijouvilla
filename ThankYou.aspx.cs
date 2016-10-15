using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ThankYou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblBookingID.Text = string.Format("If you need to contact us, please quote your booking reference: {0}{1}{2}-{3}",
            DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Utils.bookingID);
    }
}
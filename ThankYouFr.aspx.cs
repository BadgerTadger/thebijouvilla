using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ThankYouFr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblBookingID.Text = string.Format("Si vous avez besoin de nous contacter, veuillez indiquer votre référence de réservation: {0}{1}{2}-{3}",
            DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Utils.bookingID);
    }
}
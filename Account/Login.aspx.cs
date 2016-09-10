using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using System.Web.UI;
using thebijouvilla;

public partial class Account_Login : Page
{
    private string _logout = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["LoggedIn"] = false;
        if (Request.QueryString.Keys.Count > 0)
        {
            _logout = Request.QueryString["l"].ToString();
            if (_logout == "1")
            {
                Response.Redirect("~/Default.aspx", true);
            }
        }
    }

    protected void LogIn(object sender, EventArgs e)
    {
        if (IsValid)
        {
            // Validate the user password
            User user = new User(UserName.Text, Password.Text);
            if (user != null)
            {
                user.Login();
                Session["LoggedIn"] = user.LoggedIn;
                Response.Redirect("~/Default.aspx", true);
            }
            else
            {
                FailureText.Text = "Invalid username or password.";
                ErrorMessage.Visible = true;
            }
        }
    }
}
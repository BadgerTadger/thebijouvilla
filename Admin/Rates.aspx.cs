using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Rates : System.Web.UI.Page
{
    private MySqlConnection cn = new MySqlConnection(Utils.ConnString);
    DateTime startDate = DateTime.MinValue;
    DateTime endDate = DateTime.MinValue;
    decimal rate = 0M;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["LoggedIn"]) == false)
        {
            Response.Redirect("~/Default.aspx", true);
        }
        if(!Page.IsPostBack)
        {
            LoadRatesGrid();
        }
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Admin.aspx", true);
    }

    protected void btnSaveRate_Click(object sender, EventArgs e)
    {
        lblWarning.Text = "";
        lblWarning.Visible = false;

        if (ValidFields())
        {
            Rates rates = new Rates();
            rates.Insert(startDate, endDate, rate);
            divAddRates.Visible = false;
        }
        else
        {
            lblWarning.Visible = true;
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lblWarning.Text = "";
        lblWarning.Visible = false;
        txtStartDate.Text = "";
        txtEndDate.Text = "";
        startDate = new DateTime();
        endDate = new DateTime();
        txtRate.Text = "";
        divAddRates.Visible = false;
    }

    protected void btnAddRates_Click(object sender, EventArgs e)
    {
        divAddRates.Visible = true;
    }

    private bool ValidFields()
    {
        bool retVal = true;

        string[] startDateSplit = txtStartDate.Text.Split('-');
        if (startDateSplit.Length == 3)
        {
            startDate = new DateTime(int.Parse(startDateSplit[2]), int.Parse(startDateSplit[1]), int.Parse(startDateSplit[0]));
        }
        if (startDate == DateTime.MinValue)
        {
            retVal = false;
            lblWarning.Text += "Start Date must be selected<br />";
        }
        else
        {
            if (startDate < DateTime.Now)
            {
                retVal = false;
                lblWarning.Text += "Start Date cannot be in the past<br />";
            }
        }

        string[] endDateSplit = txtEndDate.Text.Split('-');
        if (endDateSplit.Length == 3)
        {
            endDate = new DateTime(int.Parse(endDateSplit[2]), int.Parse(endDateSplit[1]), int.Parse(endDateSplit[0]));
        }
        if (endDate == DateTime.MinValue)
        {
            endDate = startDate;
        }
        else
        {
            if (endDate < startDate)
            {
                retVal = false;
                lblWarning.Text += "End Date must be on or after the Start Date<br />";
            }
        }

        decimal newRate = 0M;
        decimal.TryParse(txtRate.Text, out newRate);
        if(newRate<=0)
        {
            retVal = false;
            lblWarning.Text += "Invalid Rate entered";
        }
        else
        {
            rate = newRate;
        }

        return retVal;
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        LoadRatesGrid();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LoadRatesGrid();
        int rateid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());

        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("delete FROM Rates where RateID='" + rateid + "'", cn);
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

        LoadRatesGrid();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        LoadRatesGrid();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string textRateID = row.Cells[0].Text;
            TextBox textRate = (TextBox)row.Cells[3].Controls[0];

            decimal rate = 0M;
            decimal.TryParse(textRate.Text, out rate);
            int rateID = 0;
            int.TryParse(textRateID, out rateID);

            GridView1.EditIndex = -1;
            cn.Open();
            string sqlCmd = @"UPDATE Rates Set                 
                Rate = ?Rate
                WHERE RateID = ?RateID ";
            MySqlCommand cmd = new MySqlCommand(sqlCmd, cn);
            cmd.Parameters.AddWithValue("Rate", rate);
            cmd.Parameters.AddWithValue("RateID", rateID);
            cmd.ExecuteNonQuery();
            cn.Close();

            LoadRatesGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drview = e.Row.DataItem as DataRowView;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DateTime sd = DateTime.Parse(drview[1].ToString());
                e.Row.Cells[1].Text = sd.ToString("yyyy-MM-dd");
                DateTime ed = DateTime.Parse(drview[2].ToString());
                e.Row.Cells[2].Text = ed.ToString("yyyy-MM-dd");
            }
            else
            {
                //Literal lblBD = (Literal)e.Row.Cells[4].Controls[0];
                DateTime sd = DateTime.MinValue;
                DateTime.TryParse(drview[1].ToString(), out sd);
                if (sd != DateTime.MinValue)
                {
                    e.Row.Cells[1].Text = sd.ToString("yyyy-MM-dd");
                }
                DateTime ed = DateTime.MinValue;
                DateTime.TryParse(drview[2].ToString(), out ed);
                if (ed != DateTime.MinValue)
                {
                    e.Row.Cells[2].Text = ed.ToString("yyyy-MM-dd");
                }
            }
        }
    }

    private void LoadRatesGrid()
    {
        try
        {
            string sqlCmd = @"SELECT RateID, StartDate, EndDate, Rate FROM Rates ORDER BY StartDate";
            cn.Open();
            MySqlDataAdapter adr = new MySqlDataAdapter(sqlCmd, cn);
            adr.SelectCommand.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            adr.Fill(ds); //opens and closes the DB connection automatically !! (fetches from pool)
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                divGrid.Visible = true;
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
                divGrid.Visible = false;
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
}
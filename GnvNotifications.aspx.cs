using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    SQLContext DBContext;
    string userID;
    public string cookieAdminId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DBContext = new SQLContext();
        HttpCookie DivineAdmin = Request.Cookies["DivineAdmin"];
        try
        {
            if (DivineAdmin["AdminId"].ToString().Length > 0)
            {
                cookieAdminId = DivineAdmin["AdminId"].ToString();
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx", false);
        }

    }

    protected void BtnRaise_Click(object sender, EventArgs e)
    {

        try
        {
            userID = TextBox1.Text;
            String CompId = getNotIDVendor();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Vendor_Notifications values('" + CompId + "','" + userID + "','" + TxtAreaComplaint.Text + "')", DBContext._SqlConnection);
            cmd.ExecuteNonQuery();
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' style='margin-top:8px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("Your notification has been <strong> sent.</strong>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        catch (Exception ex)
        {
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' style='margin-top:8px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Vendor Id Invalid! </strong>please lookup Db."));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }

    }
    public string getNotIDCust()
    {
        string count = "0";
        SqlCommand cmd = new SqlCommand("select count(*) from tbl_user_notifications", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string CompId = "DivineNotif00" + ncount;
        dr.Close();
        return CompId;
    }
    public string getNotIDVendor()
    {
        string count = "0";
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Vendor_Notifications", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string CompId = "DivineVNDRNot00" + ncount;
        dr.Close();
        return CompId;
    }
}
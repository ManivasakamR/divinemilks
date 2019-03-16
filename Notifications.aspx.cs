using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    SQLContext DBContext;
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
                getNotifications();
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
    public void getNotifications()
    {
        SqlCommand cmd = new SqlCommand("select Var_Anot_VendorId,Var_Anot_ANotification from Tbl_Admin_Notifications", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        int i = 0;
        while (dr.Read())
        {
            i++;
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Vendor Id: </strong>" + dr.GetValue(0).ToString() + "<br/><hr>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Description: </strong>"+dr.GetValue(1).ToString()+"."));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));            
        }
        if (i == 0)
        {
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-success alert-dismissible' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> No notifications Yet! </strong>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        dr.Close();
    }
}
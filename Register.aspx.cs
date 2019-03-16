using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Register : System.Web.UI.Page
{

    public SQLContext DBContext;
    public SqlCommand _SqlCommand;
    public SqlDataAdapter _SqlDataAdapter;
    public SqlDataReader _SqlDataReader;
    public DataTable _DataTable;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBContext = new SQLContext();
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void BtnRegister_Click1(object sender, EventArgs e)
    {
        if (TxtKey.Text!="00xAAAA")
        {
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-danger alert-dismissible' style='margin-top:5px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Secure Registration key is invalid! </strong>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        else
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Admin_Details where Var_Adm_Email='" + TxtEmail.Text + "'", DBContext._SqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                count = dr.GetInt32(0);
            }
            dr.Close();

            if (count == 1)
            {
                MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-danger alert-dismissible' style='margin-top:5px;' role='alert'>"));
                MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
                MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Email already exists! </strong> Please try to register with another one. "));
                MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
            }
            else
            {
                try
                {
                    _SqlCommand = new SqlCommand();
                    string adminID = getAdminID();
                    string qry = "insert into Tbl_Admin_Details "
                        + "values('" + adminID + "','" + TxtUsername.Text + "'," + TxtMobile.Text + ",'" + TxtAddress.Text + "'," + TxtPin.Text + ",'" + TxtEmail.Text + "','" + TxtPassword.Text + "')";
                    _SqlCommand = new SqlCommand(qry, DBContext._SqlConnection);
                    _SqlCommand.ExecuteNonQuery();
                    HttpCookie DivineAdmin = new HttpCookie("DivineAdmin");
                    DivineAdmin["AdminId"] = adminID;
                    DivineAdmin.Expires.Add(new TimeSpan(762, 0, 0));
                    Response.Cookies.Add(DivineAdmin);
                    Response.Redirect("Index.aspx", false);
                }
                catch (Exception exc)
                {
                    Response.Redirect("ReqError.aspx");
                }
            }
        }
    }    
    private string getAdminID()
    {
        string count="0";
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_Admin_Details", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string vendorID = "DivineAdmin00"+ncount;
        dr.Close();
        return vendorID;
    }
    
}


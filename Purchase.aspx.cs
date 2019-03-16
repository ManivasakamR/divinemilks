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
    public SQLContext DBContext;
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
                getDetails();
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
    public void gethdr()
    {
        divTblPurDtl.Controls.Add(new LiteralControl("<div style='margin-top:10px;' id='cltaltdiv' class='alert alert-info' role='alert'>"));        
    }
    public void getHead()
    {        
        divTblPurDtl.Controls.Add(new LiteralControl("<h4 style='margin-top:2%; margin-left:39%; padding-bottom:10px; color:#e0e0e0 !important' class='text-primary'>Purchase details</h4>"));
        //
        divTblPurDtl.Controls.Add(new LiteralControl("<table style='margin-top:8px; margin-bottom:8px;'>"));
        divTblPurDtl.Controls.Add(new LiteralControl("<tr><th>Id</th><th>User Id</th><th>Date</th><th>Morning</th><th>Evening</th><th>status</th></tr>"));
    }
    public void getftr()
    {
        divTblPurDtl.Controls.Add(new LiteralControl("</div>"));
    }
    public void clsTbl()
    {
        divTblPurDtl.Controls.Add(new LiteralControl("</table>"));
    }
    public void getDetails()
    {

        SqlCommand cmd = new SqlCommand("select Var_Purdtl_PrId,Var_Purdtl_UId,Dt_Purdtl_Date,Flt_Purdtl_Morning,Flt_Purdtl_Evening,Var_Purdtl_PayFlag from Tbl_Purchase_Details  order by Var_Purdtl_PayFlag desc", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        int i = 0;        
        gethdr();
        while (dr.Read())
        {
            i++;
            if (i == 1)
            {
                getHead();
            }
            divTblPurDtl.Controls.Add(new LiteralControl("<tr>"));
            divTblPurDtl.Controls.Add(new LiteralControl("<td>" + dr.GetValue(0).ToString() + " </td> "));
            divTblPurDtl.Controls.Add(new LiteralControl("<td>" + dr.GetValue(1).ToString() + " </td> "));
            divTblPurDtl.Controls.Add(new LiteralControl("<td>" + DateTime.Parse(dr.GetValue(2).ToString()).ToString("dd-MM-yyyy") + "</td>"));
            divTblPurDtl.Controls.Add(new LiteralControl("<td>" + dr.GetValue(3).ToString() + " </td> "));
            divTblPurDtl.Controls.Add(new LiteralControl("<td>" + dr.GetValue(4).ToString() + "</td>"));
            if (dr.GetValue(5).ToString() == "P")
            { divTblPurDtl.Controls.Add(new LiteralControl("<td style='color:#76ff03 !important;'>" + "Paid" + "</td>")); }
            else {                
                    divTblPurDtl.Controls.Add(new LiteralControl("<td style='color:#ff3d00 !important;'>" + "Not Paid " +"</td>")); } 
            divTblPurDtl.Controls.Add(new LiteralControl("</tr>"));
        }       
        if (i == 0)
        {
            divTblPurDtl.Controls.Add(new LiteralControl("<strong> No records! </strong>"));
        }        
        dr.Close();
        getftr();
    }    
}
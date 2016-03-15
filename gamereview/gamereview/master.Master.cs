using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace gamereview
{
    public partial class master : System.Web.UI.MasterPage
    {
        SqlConnection com1 = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string session = Session["member_id"].ToString();
            com1.Open();
            string checkmembershipquery = "select membership_type from Members where e_mail='" + session + "'";
            SqlCommand cmd = new SqlCommand(checkmembershipquery, com1);
            string checkmembership = cmd.ExecuteScalar().ToString();
            if (checkmembership == "Normal User")
            {
                Response.Redirect("/Users/NormalUser.aspx");
            }
            else
            {
                if (checkmembership == "Verified Reviewer")
                {

                    Response.Redirect("/Users/VerifiedUser.aspx");
                }
                else if (checkmembership == "Development Teams")
                    Response.Redirect("/Users/developmentteams.aspx");


            }

            com1.Close();

        }
protected void  Button5_Click(object sender, EventArgs e)
{         Session.RemoveAll();
          Response.Redirect("/Users/WebForm1.aspx");

}
protected void  Button3_Click(object sender, EventArgs e)
{
    Response.Redirect("/create community.aspx");

}
protected void  Button4_Click(object sender, EventArgs e)
{
    Response.Redirect("/Games/ChooseGame1.aspx");
}
protected void Button2_Click(object sender, EventArgs e)
{
    Response.Redirect("/Conferences/AttendedConferences.aspx");
}
}
}
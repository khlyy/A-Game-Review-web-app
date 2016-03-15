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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                    );
                con.Open();
                String checkUser = "select count(*) from Members where e_mail='" + TextBoxEmail.Text + "'";
                SqlCommand com = new SqlCommand(checkUser, con);
                int count = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (count == 1)
                {

                    Response.Write("email already exists");
                
                }
            

                con.Close();
            }
        }

        protected void register_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                   );
                con.Open();
                SqlCommand cmd = new SqlCommand("Members_Sign_Up", con);
               cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = TextBoxEmail.Text;
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = TextBoxPassword.Text;
                cmd.Parameters.Add("@prefered_game", SqlDbType.VarChar, 50).Value = TextBoxPreferedGame.Text;
                cmd.Parameters.Add("@membership_type", SqlDbType.VarChar, 50).Value = DropDownList1.SelectedValue;
                cmd.ExecuteNonQuery();
                con.Close();
       
            }
            catch(Exception ex) {
          
            
            }



        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                   );
                con.Open();
                String checkUser = "select count(*) from Members where e_mail='" + TextBoxlogin.Text + "' and password ='"
                  + TextBoxLoginPassword.Text + "'";
                SqlCommand com = new SqlCommand(checkUser, con);
                int count = Convert.ToInt32(com.ExecuteScalar().ToString());
                con.Close();
                if (count == 1)
                {
                    SqlConnection com1 = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                   );
                    Session["member_id"] = TextBoxlogin.Text;
                    com1.Open();
                    string checkmembershipquery = "select membership_type from Members where e_mail='" + TextBoxlogin.Text + "' and password ='"
                    + TextBoxLoginPassword.Text + "'";
                    SqlCommand cmd = new SqlCommand(checkmembershipquery,com1);
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
                else
                {
                    Response.Write("Invalid mail or Password");
                }
            }
            catch (Exception ex)
            {
                Response.Write("error message" + ex.ToString());
            }
        }

       
    }
}
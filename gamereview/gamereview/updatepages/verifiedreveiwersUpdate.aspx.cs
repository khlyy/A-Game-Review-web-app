using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace gamereview.updatepages
{
    public partial class verifiedreveiwersUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                      );
                con.Open();
                SqlCommand cmd = new SqlCommand("Verified_Reviewer_Ubdate_Info", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string email = Session["member_id"].ToString();
                cmd.Parameters.Add("@first_name", SqlDbType.VarChar, 50).Value = firstnameTextBox.Text;
                cmd.Parameters.Add("@last_name", SqlDbType.VarChar, 50).Value = lastnameTextBox.Text;
                cmd.Parameters.Add("@year_of_experience", SqlDbType.VarChar, 50).Value = yearsofexperiencetextbox.Text;
                cmd.Parameters.Add("@member_id", SqlDbType.VarChar, 50).Value = email;

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception EX)
            {

                Response.Write("error messsage :" + EX.ToString());

            }
        }
    }
}
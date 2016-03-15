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
    public partial class normaluserupdate : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("Update_My_Account", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string email = Session["member_id"].ToString();
                cmd.Parameters.Add("@first_name", SqlDbType.VarChar, 50).Value = firstnameTextBox.Text;
                cmd.Parameters.Add("@last_name", SqlDbType.VarChar, 50).Value = lastnameTextBox.Text;
                cmd.Parameters.Add("@date_of_birth", SqlDbType.VarChar, 50).Value = dateofbirthtextbox.Text;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;

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
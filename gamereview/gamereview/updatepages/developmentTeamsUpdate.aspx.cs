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
    public partial class developmentTeamsUpdate : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("Development_Teams_Update_Account", con);
                cmd.CommandType = CommandType.StoredProcedure;
                string email = Session["member_id"].ToString();
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
                cmd.Parameters.Add("@team_nameUP", SqlDbType.VarChar, 50).Value =teamnameTextBox.Text;
                cmd.Parameters.Add("@companyUP", SqlDbType.VarChar, 50).Value = companynameTextBox.Text;
                cmd.Parameters.Add("@formation_dateUP", SqlDbType.VarChar, 50).Value =dateofformationtextbox.Text;
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

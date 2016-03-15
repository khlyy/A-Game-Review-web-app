using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Game
{
    
    public partial class AddReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
                SqlCommand com = new SqlCommand("Memers_Add_Game_Reviews", con);
                con.Open();
                SqlCommand com1 = new SqlCommand("select e_mail from Verified_Reviewers where e_mail ='" + (Session["member_id"].ToString()) + "'", con);
                String name = com1.ExecuteScalar().ToString();
                Response.Write(name);
                con.Close();

                if (name != Session["member_id"].ToString())
                {
                    Response.Write("Not a verified reviewer");

                }
                else
                {
                    con.Open();
                    SqlCommand com6 = new SqlCommand("Select game_ID from Games where name='" + (Request.QueryString["GameName"].ToString()) + "'", con);
                    int id = Convert.ToInt32(com6.ExecuteScalar().ToString());
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@game_id", SqlDbType.Int).Value = id;
                    com.Parameters.Add("@member_id", SqlDbType.VarChar).Value = Session["member_id"].ToString();
                    com.Parameters.Add("@contet", SqlDbType.Text).Value = TextBox_Content.Text;


                    com.Parameters.Add("@title", SqlDbType.VarChar).Value = TextBox_Title.Text;
                    com.ExecuteNonQuery();
                    con.Close();
                    string GameName = Request.QueryString["GameName"].ToString();
                    Response.Redirect("/Games/GameInformation.aspx?GameName="+GameName);
                }
            }
            catch (NullReferenceException)
            {
                Response.Write("you are not a verified reviewer");
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }
    }
}
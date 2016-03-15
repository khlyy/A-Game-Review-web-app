using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace Game
{
    public partial class Rate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button_Back_Click(object sender, EventArgs e)
        {
            String GameName = Request.QueryString["GameName"].ToString();
           
            Response.Redirect("/Games/GameInformation.aspx?GameName="+GameName);
        }

        protected void Button_Done_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
            con.Open();
                int graphics = Convert.ToInt32(RadioButtonList_Graphics.SelectedValue.ToString());
            int interactivity=Convert.ToInt32(RadioButtonList_Interactivity.SelectedValue.ToString());
            int leveldesign = Convert.ToInt32(RadioButtonList_LevelDesign.SelectedValue.ToString());
                int uniqueness = Convert.ToInt32(RadioButtonList_Uniqueness.SelectedValue.ToString());
             String gamename = Request.QueryString["GameName"].ToString();
            SqlCommand com6 = new SqlCommand("Select game_ID from Games where name='" + gamename + "'", con); 
                int id = Convert.ToInt32(com6.ExecuteScalar().ToString());
   
            
            SqlCommand com=new SqlCommand("Members_Rate_Games",con);
            com.CommandType =CommandType.StoredProcedure;
            com.Parameters.Add("@game_id", SqlDbType.Int).Value = id;

            com.Parameters.Add("@member_email", SqlDbType.VarChar).Value = Session["member_id"].ToString();
            com.Parameters.Add("@graphics", SqlDbType.Int).Value = graphics;
            com.Parameters.Add("@level_design", SqlDbType.Int).Value = leveldesign;
            com.Parameters.Add("@interactivity", SqlDbType.Int).Value = interactivity;
            com.Parameters.Add("@uniqueness", SqlDbType.Int).Value = uniqueness;
            SqlCommand com0 = new SqlCommand("Overall_Rating", con);
            com0.CommandType = CommandType.StoredProcedure;
            com0.Parameters.Add("@game_id", SqlDbType.Int).Value = id;
      com.ExecuteNonQuery();
            com0.ExecuteNonQuery();
            con.Close();
                 String GameName=Request.QueryString["GameName"].ToString();
           
            Response.Redirect("/Games/GameInformation.aspx?GameName="+GameName);
        }
    }
}
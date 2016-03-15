using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace Game
{
    public partial class GameInformation : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["GameName"] == null)
            //{

            //   Response.Redirect("ChooseGame1.aspx"); ;
            // }
            //else
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
                // Label_Name.Text = Session["GameName"].ToString();
                Label_Name.Text = Request.QueryString["GameName"].ToString();

                SqlCommand com1 = new SqlCommand("Select release_date from Games where name = '" + Label_Name.Text + "'", con);
                SqlCommand com2 = new SqlCommand("Select rating from Games where name = '" + Label_Name.Text + "'", con);
                SqlCommand com3 = new SqlCommand("Select age_limit from Games where name = '" + Label_Name.Text + "'", con);
                SqlCommand com4 = new SqlCommand("Select development_team_email from Games where name = '" + Label_Name.Text + "'", con);
                SqlCommand com6 = new SqlCommand("Select game_ID from Games where name='" + Label_Name.Text + "'", con);

                con.Open();
                int temp = Convert.ToInt32(com6.ExecuteScalar().ToString());
                SqlCommand com5 = new SqlCommand("Select * from Screenshots where game_id='" + temp + "'", con);
                SqlCommand com7 = new SqlCommand("Select * from Videos where game_id='" + temp + "'", con);
                SqlCommand com8 = new SqlCommand("Select * from Strategies where game_id='" + temp + "'", con);
                if (com8.ExecuteScalar() != null)
                {
                    Label_Type.Text = "Strategy";
                }
                SqlCommand com9 = new SqlCommand("Select * from Actions where game_id='" + temp + "'", con);
                if (com9.ExecuteScalar() != null)
                {
                    Label_Type.Text = "Action";
                }
                SqlCommand com10 = new SqlCommand("Select * from Sports where game='" + temp + "'", con);
                if (com10.ExecuteScalar() != null)
                {
                    Label_Type.Text = "Sport";
                }
                SqlCommand com11 = new SqlCommand("Select * from RPG where game_id='" + temp + "'", con);
                if (com11.ExecuteScalar() != null)
                {
                    Label_Type.Text = "RPG";
                }
                Label_Release.Text = com1.ExecuteScalar().ToString();
                Label_Rating.Text = com2.ExecuteScalar().ToString();
                Label_Age.Text = com3.ExecuteScalar().ToString();
                Label_Team.Text = com4.ExecuteScalar().ToString();


                GridView_ScreenShots.DataSource = com5.ExecuteReader();
                GridView_ScreenShots.DataBind();
                con.Close();
                con.Open();
                GridView_Videos.DataSource = com7.ExecuteReader();
                GridView_Videos.DataBind();
                con.Close();
                if (!IsPostBack)
                {
                    con.Open();

                    SqlCommand com12 = new SqlCommand("Select title,game_review_id from Game_Reviews where game_id='" + temp + "'", con);
                    DropDownList_Show_Review.DataSource = com12.ExecuteReader();
                    DropDownList_Show_Review.DataTextField = "title";
                    DropDownList_Show_Review.DataValueField = "game_review_id";

                    DropDownList_Show_Review.DataBind();
                    con.Close();
                }
                if (!IsPostBack)
                {
                    con.Open();
                    SqlCommand com13 = new SqlCommand("Select e_mail1 from Members_Add_Members where e_mail2 ='" + Session["member_id"].ToString() + "' And accept= 1 Union Select e_mail2 from Members_Add_Members where e_mail1='" + Session["member_id"].ToString() + "'And accept = 1", con);
                    try
                    {
                        if (com13.ExecuteScalar().ToString() == Session["member_id"].ToString())
                        {
                            DropDownList_Recommend.DataSource = com13.ExecuteReader();
                            DropDownList_Recommend.DataTextField = "e_mail2";//setting datatextfield according to the user we want to sent a recommendation
                            DropDownList_Recommend.DataValueField = "e_mail2";
                            DropDownList_Recommend.DataBind();
                        }

                        else
                        {
                            DropDownList_Recommend.DataSource = com13.ExecuteReader();
                            DropDownList_Recommend.DataTextField = "e_mail1";//setting datatextfield according to the user we want to sent a recommendation
                            DropDownList_Recommend.DataValueField = "e_mail1";
                            DropDownList_Recommend.DataBind();

                        }

                        con.Close();
                    }catch(Exception ex)
                    {
                        Response.Write("You don't have friends!");
                    }

                }
            }
        }

        protected void SqlDataSource_Screenshots_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
        }

        protected void SqlDataSource_Videos_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
        }

        protected void DropDownList_Show_Review_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // Session["title"] = DropDownList_Show_Review.SelectedValue;
            String title = DropDownList_Show_Review.SelectedValue;
            String GameName = Request.QueryString["GameName"].ToString();
            Response.Redirect("/Games/Preview.aspx?title="+title+"&GameName="+GameName);

        }

        protected void Button_Rate_Click(object sender, EventArgs e)
        {

            String GameName=Request.QueryString["GameName"].ToString();
            
            Response.Redirect("/Games/Rate.aspx?GameName="+GameName);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/Games/ChooseGame1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String GameName = Request.QueryString["GameName"].ToString();
           
            Response.Redirect("/Games/AddReview.aspx?GameName="+GameName);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {



            String r = DropDownList_Recommend.SelectedItem.ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);

            con.Open();
            SqlCommand com1 = new SqlCommand("select e_mail from Normal_Users where e_mail ='" + (Session["member_id"].ToString()) + "'", con);
            String name = com1.ExecuteScalar().ToString();
            con.Close();
            if (name != Session["member_id"].ToString())
            {
                Response.Write("you are not a normal user to recommend a game");
            }
            else
            {

                try
                {

                    con.Open();
                    SqlCommand com = new SqlCommand("Recommend_Game", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add("@email1", SqlDbType.VarChar).Value = Session["member_id"].ToString();
                    com.Parameters.Add("@email2", SqlDbType.VarChar).Value = r;
                    SqlCommand com6 = new SqlCommand("Select game_ID from Games where name='" + Label_Name.Text + "'", con);
                    int temp = Convert.ToInt32(com6.ExecuteScalar().ToString());
                    com.Parameters.Add("@gameid", SqlDbType.Int).Value = temp;
                    com.ExecuteNonQuery();
                    con.Close();
                    Response.Write("Recommendation done!");
                }
                catch (Exception)
                {
                    Response.Write("You already sent a recommendation to this user!");//duplicates
                }
            }
        }

        protected void DropDownList_Recommend_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String GameName = Request.QueryString["GameName"].ToString();

            Response.Redirect("/Games/Rate.aspx?GameName=" + GameName);
        
        }
    }
}
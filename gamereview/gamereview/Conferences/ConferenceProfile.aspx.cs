using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Game.Conferences
{
    public partial class ConferenceProfile : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
        string id;
        string member_id;
        SqlDataReader rdr;
        SqlCommand com;

        protected void Conference_Info()
        {
            com = new SqlCommand("Conferences_Views_By_Members ", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@conference_id",id);
            conn.Open();
            rdr = com.ExecuteReader();
            if (rdr.Read())
            {
                ConferenceNameLable.Text = rdr.GetString(1);
                DurationLabel.Text = "Duration: " + rdr.GetInt32(4).ToString() + " days";
                DateLabel.Text = "Date: " + rdr.GetDateTime(3).ToString();
                LocationLabel.Text += "Location: " + rdr.GetString(2);
            }
            conn.Close();
        }

        protected void Debuted_Games()
        {
            com = new SqlCommand("Debuted_Games_Views_At_Conferences", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@conference_id", id);
            conn.Open();
            rdr = com.ExecuteReader();

            Label Line = new Label();
            Line.Text = "<br/> <br/>";
            form1.Controls.Add(Line);

            Label DGheader = new Label();
            DGheader.ID = "DGheader";
            DGheader.Text = "Debuted Games: <br/> <br/>";
            form1.Controls.Add(DGheader);

            while (rdr.Read())
            {
                string DevelopmentTeam = rdr.GetString(0);
                string Game = rdr.GetString(1);

                Label DevelopmentTeamLabel = new Label();
                DevelopmentTeamLabel.ID = "DevelopmentTeamLabel";
                DevelopmentTeamLabel.Text = "-" + DevelopmentTeam + "  Debutes: ";
                form1.Controls.Add(DevelopmentTeamLabel);


                HyperLink GameLink = new HyperLink();
                GameLink.Text = Game + " <br/>";
                GameLink.ID = "GameLink";
                GameLink.NavigateUrl = "/Games/GameInformation.aspx?GameName="+Game;
                form1.Controls.Add(GameLink);
            }

            form1.Controls.Add(Line);

            conn.Close();
        }

        protected void Presented_Games() 
        {
            com = new SqlCommand("Presented_Games_Views_At_Conferences", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@conference_id", id);
            conn.Open();
            rdr = com.ExecuteReader();

            Label DGheader = new Label();
            DGheader.ID = "DGheader";
            DGheader.Text = "Presented Games: <br/> <br/>";
            form1.Controls.Add(DGheader);

            while (rdr.Read())
            {
                string DevelopmentTeam = rdr.GetString(0);
                string Game = rdr.GetString(1);

                Label DevelopmentTeamLabel = new Label();
                DevelopmentTeamLabel.ID = "DevelopmentTeamLabel";
                DevelopmentTeamLabel.Text = "-" + DevelopmentTeam + "  Presents: ";
                form1.Controls.Add(DevelopmentTeamLabel);


                HyperLink GameLink = new HyperLink();
                GameLink.Text = Game + " <br/>";
                GameLink.ID = "GameLink";
                GameLink.NavigateUrl = "/Games/GameInformation.aspx?GameName=" + Game;
                form1.Controls.Add(GameLink);
            }

            Label Line = new Label();
            Line.Text = "<br/> <br/>";
            form1.Controls.Add(Line);

            conn.Close();
        }

        protected void List_Of_Reviews()
        {
            com = new SqlCommand("Reviews_Views_At_Conferences", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@conference_id" , id);
            conn.Open();
            rdr = com.ExecuteReader();
            Label ReviewsHeader = new Label();
            ReviewsHeader.ID = "ReviewsHeader";
            ReviewsHeader.Text = "Conference Reviews: <br/> <br/>";
            form1.Controls.Add(ReviewsHeader);

            while (rdr.Read())
            {
                string review = rdr.GetString(0);
                string review_id = rdr.GetInt32(1).ToString();
                string reviewer_id = rdr.GetString(2).ToString();
                string content = rdr.GetString(3).ToString();
                HyperLink ReviewLink = new HyperLink();
                ReviewLink.Text = "-" + review + " <br/>";
                ReviewLink.ID = "ReviewLink";
                ReviewLink.NavigateUrl = "/Conferences/ConferenceReviews.aspx?review=" + review + "&review_id=" + review_id + "&reviewer_id=" + reviewer_id + "&content=" + content + "&conference_id=" + id;
                form1.Controls.Add(ReviewLink);
            }
            conn.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            id =Request.QueryString["id"].ToString();
            member_id = Session["member_id"].ToString();

            DurationLabel.Text = "";
            DateLabel.Text = "";
            LocationLabel.Text = "";

            Conference_Info();
            
            Debuted_Games();

            Presented_Games();

            List_Of_Reviews();

        }

        protected void AttendButton_Click(object sender, EventArgs e)
        {
            try
            {
                com = new SqlCommand("Members_Adding_attended_Conferences", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@member_id", member_id);
                com.Parameters.AddWithValue("@conference_id", id);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex) 
            {
                Response.Write("You have alredy registered!");
            }
        }

        protected void DebuteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string gameName = GameNameTextBox.Text;
                string ageLimit = AgeLimitTextBox.Text;
                if (ageLimit != "" && gameName != "")
                {
                    com = new SqlCommand("INSERT INTO Games (name,release_date,age_limit,development_team_email,release_conference) VALUES('" + gameName + "','" + DateTime.Today + "' ,'" + ageLimit + "', '" + member_id + "' , '" + id + "')", conn);
                    conn.Open();
                    com.ExecuteNonQuery();
                    conn.Close();
                    com = new SqlCommand("SELECT game_ID FROM Games WHERE name = '" + gameName + "' AND development_team_email = '" + member_id + "'", conn);
                    conn.Open();
                    string game_id = com.ExecuteScalar().ToString();
                    conn.Close();
                    com = new SqlCommand("INSERT INTO Development_Teams_Present_Games VALUES('" + id + "' , '" + game_id + "' , '" + member_id + "')", conn);
                    conn.Open();
                    com.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("/Conferences/ConferenceProfile.aspx?id=" + id);
                }
                else {
                    Response.Write("Please fill all the information!");
                }
            }
            catch(Exception ex)
            {
                Response.Write("This game is already debuted!");
            }

        }

        protected void PresentButton_Click(object sender, EventArgs e)
        {
            try
            {
                string gameName = GameNameTextBox2.Text;
                com = new SqlCommand("SELECT game_ID FROM Games WHERE name = '" + gameName + "' AND development_team_email = '" + member_id + "'", conn);
                conn.Open();
                string game_id = com.ExecuteScalar().ToString();
                conn.Close();
                com = new SqlCommand("Development_Team_Add_Game", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@game_ID", game_id);
                com.Parameters.AddWithValue("@release_conference", id);
                com.Parameters.AddWithValue("@development_team_email", member_id);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Conferences/ConferenceProfile.aspx?id="+id);
            }
            catch (Exception ex) {
                Response.Write("This game is already presented!");
            }
        }

        protected void AddReviewButton_Click(object sender, EventArgs e)
        {
            string content = ReviewTextBox.Text;
            string title = TitleTextBox.Text;
            com = new SqlCommand("Conference_Review_Added_By_Members",conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@member_id" , member_id);
            com.Parameters.AddWithValue("@conference_id", id);
            com.Parameters.AddWithValue("@content", content);
            com.Parameters.AddWithValue("@date",DateTime.Today);
            com.Parameters.AddWithValue("@title", title);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("/Conferences/ConferenceProfile.aspx?id="+id);
            
        }
    }
}
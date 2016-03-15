using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

namespace Game.Conferences
{
    public partial class ConferenceReviews : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
        SqlDataReader rdr;
        SqlCommand com;
        string id;
        string member_id ;
        string conference_id;
        string review;
        string reviewer_id;
        string content;

        protected void Review_Info() 
        {
            ReviewTitleLabel.Text = review;
            ReviewerNameLable.Text = reviewer_id;
            ReviewContentLabel.Text = content;
            com = new SqlCommand("SELECT membership_type FROM Members WHERE e_mail = '" + reviewer_id + "'", conn);
            conn.Open();
            string type = com.ExecuteScalar().ToString();
            conn.Close();
            if (type == "Normal User")
            {
                ReviewerNameLable.NavigateUrl = "/Users/NormalUsersView.aspx?id="+reviewer_id;
            }
            else if (type == "Development Teams")
            {
                ReviewerNameLable.NavigateUrl = "/Users/DevelpomentTeamsView.aspx?id="+reviewer_id;
            }
            else if (type == "Verified Reviewer")
            {
                ReviewerNameLable.NavigateUrl = "/Users/verifiedviews.aspx?id=" + reviewer_id;
            }
        }

        protected void View_Comments()
        {
            com = new SqlCommand("Members_View_Conference_Review_Comments", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@conference_review_id", id);
            com.Parameters.AddWithValue("@conference_id", conference_id);
            conn.Open();
            rdr = com.ExecuteReader();
            while (rdr.Read())
            {
                string comment = rdr.GetString(0);
                string member = rdr.GetString(1);
                string comment_id = rdr.GetInt32(2).ToString();

                if (member == member_id)
                {
                    Label memberLabel = new Label();
                    // memberLabel.ID = "memberLabel";
                    memberLabel.Text = member + ":  ";
                    form1.Controls.Add(memberLabel);

                    Label commentLabel = new Label();
                    //commentLabel.ID = "commentLabel";
                    commentLabel.Text = comment + "   ";
                    form1.Controls.Add(commentLabel);

                    Button deleteButton = new Button();
                    //deleteButton.ID = "deleteButton";
                    deleteButton.Text = "Delete";
                    deleteButton.Click += new EventHandler((s, e1) => deleteButton_Click(s, e1, comment_id));
                    form1.Controls.Add(deleteButton);

                    Label Line = new Label();
                    Line.Text = "<br/>";
                    form1.Controls.Add(Line);

                    Label Line1 = new Label();
                    Line1.Text = "<br/>";
                    form1.Controls.Add(Line1);

                }
                else
                {
                    Label memberLabel = new Label();
                    //  memberLabel.ID = "memberLabel";
                    memberLabel.Text = member + ":  ";
                    form1.Controls.Add(memberLabel);

                    Label commentLabel = new Label();
                    //commentLabel.ID = "commentLabel";
                    commentLabel.Text = comment + "<br/>";
                    form1.Controls.Add(commentLabel);

                    Label Line = new Label();
                    Line.Text = "<br/>";
                    form1.Controls.Add(Line);
                }
            }
            conn.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            id = Request.QueryString["review_id"].ToString();
            member_id = Session["member_id"].ToString();
            conference_id = Request.QueryString["conference_id"].ToString();
            review = Request.QueryString["review"].ToString();
            reviewer_id = Request.QueryString["reviewer_id"].ToString();
            content = Request.QueryString["content"].ToString();

            Review_Info();

            View_Comments();

        }

        protected void deleteButton_Click(object sender, EventArgs e , string comment_id)
        {
            SqlCommand com = new SqlCommand("Members_Delete_Conference_Reviews_Comment", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@member_id", member_id);
            com.Parameters.AddWithValue("@comment_id", comment_id);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("/Conferences/ConferenceReviews.aspx?review=" + review + "&review_id=" + id + "&reviewer_id=" + reviewer_id + "&content=" + content + "&conference_id=" + conference_id);
        }

        protected void CommentButton_Click(object sender, EventArgs e)
        {
            string CommentContent = CommentTextBox.Text;
            SqlCommand com = new SqlCommand("Members_Add_Comment_On_Conference_Review", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@member_id", member_id);
            com.Parameters.AddWithValue("@conference_review_id", id);
            com.Parameters.AddWithValue("@conference_id", conference_id);
            com.Parameters.AddWithValue("@content", CommentContent);
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("/Conferences/ConferenceReviews.aspx?review="+review+"&review_id="+id+"&reviewer_id="+reviewer_id+"&content="+content+"&conference_id="+ conference_id);

        }
    }
}
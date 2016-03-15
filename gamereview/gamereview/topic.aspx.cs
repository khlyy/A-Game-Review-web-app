using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public partial class topic : System.Web.UI.Page
{
    String member_id;
    protected void Page_Load(object sender, EventArgs e)
    {

        member_id = Session["member_id"].ToString();
        String topicid = Request.QueryString["topic_id"].ToString();
        String communityid = Request.QueryString["community_theme"].ToString();
        string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(connStr);
        String comm = "select title,topic_id,description ,member_id from Members_Post_Topic_On_Communities  where theme='" + communityid + "' AND topic_id='" + topicid + "' ";


        SqlCommand cm1 = new SqlCommand(comm, conn);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(comm, conn);
        conn.Open();
        da.Fill(dt);
        conn.Close();

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        SqlCommand cm = new SqlCommand(comm, conn);
        conn.Open();
        SqlDataReader rdr = cm.ExecuteReader();

        if (rdr.Read())
        {
            string memberid = rdr.GetString(3);
            conn.Close();
            SqlCommand com = new SqlCommand("SELECT membership_type FROM Members WHERE e_mail = '" + memberid + "'", conn);
            conn.Open();
            string type = com.ExecuteScalar().ToString();


            HyperLink1.Text = "  profile of the writer : " + memberid + "<br/>" + "<br/>" + "<br/>";

            if (type == "Normal User")
            {
                HyperLink1.NavigateUrl = "/Users/NormalUsersView.aspx?id=" + memberid;
            }
            else if (type == "Development Teams")
            {
                HyperLink1.NavigateUrl = "/Users/DevelpomentTeamsView.aspx?id=" + memberid;
            }
            else if (type == "Verified Reviewer")
            {
                HyperLink1.NavigateUrl = "/Users/verifiedviews.aspx?id=" + memberid;
            }

            conn.Close();


        }
        

        SqlCommand cmd = new SqlCommand("Members_View_Community_Topics_Comments", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@community_theme", communityid);
        cmd.Parameters.AddWithValue("@member_id", member_id);
        cmd.Parameters.AddWithValue("@topic_id", topicid);
        conn.Open();

        GridView2.DataSource = cmd.ExecuteReader();
        GridView2.DataBind();
        conn.Close();


    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox1.Text == String.Empty)
            {
                Response.Write("the comment can not be empty  ");
            }
            else
            {

                String topicid = Request.QueryString["topic_id"].ToString();
                String communityid = Request.QueryString["community_theme"].ToString();

                string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand("Members_Add_Comment_On_Topic", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@theme", communityid);
                cmd.Parameters.AddWithValue("@topic_id", topicid);
                cmd.Parameters.AddWithValue("@member_id", member_id);
                cmd.Parameters.AddWithValue("@content", TextBox1.Text);
                cmd.Parameters.AddWithValue("@date", DateTime.Today);

                int check = cmd.ExecuteNonQuery();
                if (check >= 1)
                {
                    Response.Write("the comment is successfully added");
                    Response.Redirect("/thetopic.aspx?topic_id=" + topicid + "&community_theme=" + communityid);
                    Response.Write("the comment is successfully added");
                }
                else
                {
                    Response.Write("you should join the community to write a comment ");
                }

                conn.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("error" + ex.ToString());
        }
    }


    public void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBox2.Text == String.Empty)
            {
                Response.Write("please enter the id ");
            }
            else
            {

                String topicid = Request.QueryString["topic_id"].ToString();
                String communityid = Request.QueryString["community_theme"].ToString();

                string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand("Members_Delete_Topics_Comment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@theme", communityid);
                cmd.Parameters.AddWithValue("@member_id", member_id);
                cmd.Parameters.AddWithValue("@comment_id", TextBox2.Text);
                int check = cmd.ExecuteNonQuery();
                if (check >= 1)
                {

                    Response.Redirect("/thetopic.aspx?topic_id=" + topicid + "&community_theme=" + communityid);
                    Response.Write("the comment is deleted ");
                }
                else
                {
                    Response.Write("you should be the writer of the comment to delete it ");
                }
                conn.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write("error" + ex.ToString());
        }


    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
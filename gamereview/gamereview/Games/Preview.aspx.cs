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
    public partial class Preview : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
      //     if (Session["title"] == null)
    //        {
  //              Response.Redirect("GameInformation");
//            }
          //  else
          {

              SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
                con.Open();

                id = Convert.ToInt32(Request.QueryString["title"].ToString());
                SqlCommand com = new SqlCommand("select [content] from Game_Reviews where game_review_id= " + id, con);
                Label_Content.Text = com.ExecuteScalar().ToString();

                Label_Game_Name.Text = Request.QueryString["GameName"].ToString();

                SqlCommand com4 = new SqlCommand("select verified_reviewer from Game_Reviews where game_review_id= '" + id + "'", con);
                Session["Reviewer"] = com4.ExecuteScalar().ToString();
                SqlCommand com5 = new SqlCommand("select member_id,[content] from Game_Reviews_Commented_On_By_Members where  game_review_id =" + id, con);
                GridView_Comments.DataSource = com5.ExecuteReader();
                GridView_Comments.DataBind();
                con.Close();
                con.Open();
                SqlCommand com9 = new SqlCommand("select game_ID from Games where name='" + Request.QueryString["GameName"].ToString() + "'", con);
                int game_id=Convert.ToInt32(com9.ExecuteScalar().ToString());
                if (!IsPostBack)
                {
                    SqlCommand com10 = new SqlCommand("select comment_id,content from Game_Reviews_Commented_On_By_Members where game_review_id=" + id + " And game_id =" + game_id + " And member_id ='" + Session["member_id"].ToString() + "'", con);

                    DropDownList_Delete_Comments.DataSource = (com10.ExecuteReader());
                    DropDownList_Delete_Comments.DataTextField = "content";
                    DropDownList_Delete_Comments.DataValueField = "comment_id";
                    DropDownList_Delete_Comments.DataBind();
                }
                con.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("Members_Add_Comment_On_Game_Review", con);
            con.Open();
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@member_id", SqlDbType.VarChar).Value = Session["member_id"].ToString();
            SqlCommand com1 = new SqlCommand("Select game_id from Games where name = '" + Request.QueryString["GameName"].ToString() + "'", con);
            com.Parameters.Add("@game_review_id", SqlDbType.Int).Value = id;
            com.Parameters.Add("@game_id", SqlDbType.Int).Value = com1.ExecuteScalar();
            com.Parameters.Add("@content", SqlDbType.Text).Value = TextBox_Add_Comment.Text;
            com.ExecuteNonQuery();
            con.Close();
            String title = Request.QueryString["title"].ToString();
            String GameName = Request.QueryString["GameName"].ToString();
            Response.Redirect("/Games/Preview.aspx?title=" + title + "&GameName=" + GameName);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
            SqlCommand com = new SqlCommand("Members_Delete_Games_Reviews_Comment", con);
            con.Open();
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add("@member_id", SqlDbType.VarChar).Value = Session["member_id"].ToString();
            com.Parameters.Add("@comment_id", SqlDbType.Int).Value = DropDownList_Delete_Comments.SelectedValue;
            com.ExecuteNonQuery();
            con.Close();
            String title = Request.QueryString["title"].ToString();
            String GameName = Request.QueryString["GameName"].ToString();
            Response.Redirect("/Games/Preview.aspx?title=" + title + "&GameName=" + GameName);

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_Add_Comment_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList_Delete_Comments_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
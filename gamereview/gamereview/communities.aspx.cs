using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public partial class communities : System.Web.UI.Page
{
    string theme;
    string mail;
    protected void Page_Load(object sender, EventArgs e)
    {
        mail = Session["member_id"].ToString();
        theme = Request.QueryString["theme"].ToString();
        string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(connStr);

        String fill = "select theme ,name ,description from Communities where theme='" + theme + "' ";
        SqlCommand cm1 = new SqlCommand(fill, conn);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(fill, conn);
        conn.Open();
        da.Fill(dt);
        conn.Close();

        if (dt.Rows.Count > 0)
        {
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        DataTable dtt = new DataTable();

        String comm = "select title,topic_id,member_id ,theme   from Members_Post_Topic_On_Communities  where theme='" + theme + "' ";
        SqlDataAdapter daa = new SqlDataAdapter(comm, conn);




        conn.Open();

        daa.Fill(dtt);
        conn.Close();
        if (dt.Rows.Count > 0)
        {
            GridView2.DataSource = dtt;
            GridView2.DataBind();
        }



        SqlCommand cm = new SqlCommand(comm, conn);
        conn.Open();
        SqlDataReader rdr = cm.ExecuteReader();
        int i = 0;
        while (rdr.Read())
        {
            string titleofthetopic = rdr.GetString(0);

            String user = Session["member_id"].ToString();
            String tpid = rdr.GetInt32(1).ToString();

            HyperLink title = new HyperLink();
            title.Text = titleofthetopic + "<br/>" + "<br/>";
            title.NavigateUrl = "/thetopic.aspx?topic_id=" + tpid + "&community_theme=" + theme + "";
            GridView2.Rows[i].Cells[0].Controls.Add(title);


            /*     if (user == rdr.GetString(2))
                 {
                     Button delete = new Button();
                     delete.Text = "delete";
                     GridView2.Rows[i].Cells[3].Controls.Add(delete);

                 }
                 else
                 {
                     Label a = new Label();
                     GridView2.Rows[i].Cells[3].Controls.Add(a);

                 }*/

            i++;

        }
    }







    protected void Button3_Click(object sender, EventArgs e)
    {

        try
        {
            string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String mail = Session["member_id"].ToString();


            connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
            conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("Members_Join_Community", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.AddWithValue("@theme", theme);
            cmd.Parameters.AddWithValue("@member_id", mail);

            cmd.ExecuteNonQuery();
            Response.Write("you have been successfully joined the community  ");
            conn.Close();
        }


        catch (Exception ex)
        {
            string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String check = "select count(*) from Members_Join_Communities where member_id='" + mail + "' And theme='" + theme + "' ";
            SqlCommand c = new SqlCommand(check, conn);
            conn.Open();
            int a = Convert.ToInt32(c.ExecuteScalar().ToString());

            if (a >= 1)
            {
                Response.Write("you are already joined this community ");
            }
            else
            {
                Response.Write(ex.ToString() + a);
            }
        }




    }



    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox2_TextChanged1(object sender, EventArgs e)
    {

    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {


            if (TextBox1.Text == String.Empty)
            {
                Response.Write("you should enter a title for the topic ");
            }
            else
            {
                string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand("Members_Post_Topic_On_Community", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@theme", theme);
                cmd.Parameters.AddWithValue("@member_id", mail);
                cmd.Parameters.AddWithValue("@description", TextBox2.Text);
                cmd.Parameters.AddWithValue("@title", TextBox1.Text);

                int dataaffect = cmd.ExecuteNonQuery();

                if (dataaffect >= 1)
                {
                    Response.Redirect("/communities.aspx?theme=" + theme);
                    Response.Write("your topic is added ");

                }
                else
                {
                    Response.Write("you should be member in the community to post topics  ");
                }
                conn.Close();
            }

        }
        catch (Exception ex)
        {
            Response.Write("error" + ex.ToString());
        }
    }



    protected void Button4_Click1(object sender, EventArgs e)
    {



        string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(connStr);
        String deletecomment = " delete from Members_Comment_On_Topics  where topic_id='" + TextBox3.Text + "' and theme='" + theme + "'";

        SqlCommand cm = new SqlCommand(deletecomment, conn);
        conn.Open();
        cm.ExecuteNonQuery();
        conn.Close();
        SqlCommand cmd = new SqlCommand("Members_Delete_Community_Topics", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        conn.Open();

        cmd.Parameters.AddWithValue("@member_id", mail);
        cmd.Parameters.AddWithValue("@topic_id", TextBox3.Text);
        int check = cmd.ExecuteNonQuery();
        if (check >= 1)
        {

            Response.Redirect("/communities.aspx?theme=" + theme);
        }
        else
        {
            Response.Write("you should be the writer of the topic to delete it ");
        }
        conn.Close();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
public partial class Default2 : System.Web.UI.Page
{
    String memberid;
    protected void Page_Load(object sender, EventArgs e)
    {
        memberid = Session["member_id"].ToString();

        DataTable dt = new DataTable();
        string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(connStr);
        String fill = "select theme ,name ,description from Communities where accept =1 ";
        SqlCommand cmd = new SqlCommand(fill, conn);

        SqlDataAdapter da = new SqlDataAdapter(fill, conn);
        conn.Open();
        da.Fill(dt);
        conn.Close();

        if (dt.Rows.Count > 0)
        {
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        conn.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        int i = 0;
        while (rdr.Read())
        {
            String commtheme = rdr.GetString(0);
            String commname = rdr.GetString(1);
            String commdes = rdr.GetString(2);
            HyperLink title = new HyperLink();
            title.Text = commtheme;
            title.NavigateUrl = "communities.aspx?theme=" + commtheme;
            GridView2.Rows[i].Cells[1].Controls.Add(title);
            i++;


        }
        conn.Close();
        GridView2.Visible = false;
        Label5.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            if (TextBox4.Text == String.Empty)
            {
                Response.Write("you should enter a theme ");
            }
            else
            {

                string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
                SqlConnection conn = new SqlConnection(connStr);


                SqlCommand cmd = new SqlCommand("Request_To_Create_Community", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.Parameters.AddWithValue("@theme", TextBox4.Text);
                cmd.Parameters.AddWithValue("@email", memberid);
                cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                cmd.Parameters.AddWithValue("@description", TextBox5.Text);

                // cmd.ExecuteNonQuery();
                int i = cmd.ExecuteNonQuery();

                conn.Close();

                if (i >= 1)
                {
                    Response.Write("the request is sucessfully sent  ");
                }
                else
                {

                    String check = "select count(*) from Normal_Users where e_mail='" + memberid + "' ";
                    SqlCommand c = new SqlCommand(check, conn);
                    conn.Open();
                    int a = Convert.ToInt32(c.ExecuteScalar().ToString());

                    if (a < 1)
                        Response.Write("you should be a normal user to create a community ");

                }
            }
        }
        catch (Exception ex)
        {

            string connStr = ConfigurationManager.ConnectionStrings["gameConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String check = "select count(*) from Communities  where theme='" + TextBox4.Text + "' And accept='" + 1 + "' ";
            SqlCommand cmd = new SqlCommand(check, conn);

            conn.Open();
            int a = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            if (a >= 1)
                Response.Write("there is a community with the same theme ,please choose another theme ");
            else
                Response.Write(ex.ToString());
            conn.Close();
        }
    }






    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView2.Visible = true;
        Label5.Visible = true;
    }


    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
}
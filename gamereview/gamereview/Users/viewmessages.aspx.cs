using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace gamereview
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            string session = Session["member_id"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                    );
            SqlCommand cmd = new SqlCommand("View_My_Messages", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = session;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {   string email = rdr.GetString(1);
                string message = rdr.GetString(4);
                Label friend = new Label();
                friend.ID = "friends" + email;
                friend.Text =email+"   send you message :   "+message;
                form1.Controls.Add(friend);
                Label break1 = new Label();

                break1.ID = "break";
                break1.Text = "<br/>";
                form1.Controls.Add(break1);


            }
            con.Close();
        }
    }
}
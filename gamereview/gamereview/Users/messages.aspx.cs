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
    public partial class messages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string session = Session["member_id"].ToString();
            SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                    );
            SqlCommand cmd = new SqlCommand("View_Friend_List", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value=session;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
        

            while (rdr.Read()) {

                string email = rdr.GetString(0);
                Label friend = new Label();
                friend.ID = "friends"+email;
                friend.Text = email;
                form1.Controls.Add(friend);
                Label break1 = new Label();

                break1.ID = "break" ;
                break1.Text = "<br/>";
                form1.Controls.Add(break1);


            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           try
            {
                string session = Session["member_id"].ToString();
                string messagebody = message.Text;
                string emailbody = email.Text;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                        );

                con.Open();
                SqlCommand cmd = new SqlCommand("Send_Message_To_Friends", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@sender", SqlDbType.VarChar, 50).Value = session;
                cmd.Parameters.Add("@reciever", SqlDbType.VarChar, 50).Value = emailbody;
                cmd.Parameters.Add("@content ", SqlDbType.VarChar, 50).Value = messagebody;
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("/Users/messages.aspx");
            }
            catch (Exception ex) {

                Response.Write("messages" + ex.ToString());
            
            }
        }
    }
}
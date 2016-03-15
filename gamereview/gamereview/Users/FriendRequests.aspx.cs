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
    public partial class FriendRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string session = Session["member_id"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                    );
                con.Open();
                SqlCommand cmd = new SqlCommand("View_Pending_Requests", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = session;
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {

                    string friendrequest = rdr.GetString(rdr.GetOrdinal("e_mail1"));
                    Label friendlabel = new Label();
                    friendlabel.ID = "friendlabel"+friendrequest;
                    friendlabel.Text = "-" + friendrequest + " send you friend request";
                    form1.Controls.Add(friendlabel);

                    Button acceptbutton = new Button();
                    acceptbutton.ID = "accept"+friendrequest;
                    acceptbutton.Text = "Accept";
                    acceptbutton.Click += new EventHandler((s, e1) => acceptbutton_Click(s, e1,friendrequest));
                    //acceptbutton.CommandArgument = friendrequest;
                    form1.Controls.Add(acceptbutton);
                    Button rejectbutton = new Button();
                    rejectbutton.ID ="reject"+friendrequest;;
                    rejectbutton.Text = "reject";
                    rejectbutton.Click += new EventHandler((s, e1) => rejectbutton_Click(s, e1, friendrequest));
                form1.Controls.Add(rejectbutton);
                Label break1 = new Label();
                break1.ID = "break" + friendrequest;
                break1.Text = "<br/>";
                form1.Controls.Add(break1);


                }
                con.Close();
            }catch(Exception ex){
                Response.Write("labels"+ex.ToString());

            
            
            }
        }
        void rejectbutton_Click(object sender, EventArgs e,string name)
        {
                try
            {
             //   Button btn = (Button)sender;
               // string id = btn.CommandArgument;
                string session = Session["member_id"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                    );
                con.Open();
                SqlCommand cmd = new SqlCommand("Reject_Friend_Request", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email1", SqlDbType.VarChar, 50).Value = name;
                cmd.Parameters.Add("@email2", SqlDbType.VarChar, 50).Value = session;
                cmd.ExecuteNonQuery();
                Response.Redirect("/Users/FriendRequests.aspx");

                con.Close();
            }catch(Exception ex){
                Response.Write("RejectButton" + ex.ToString());
            
            }
        }


        

        void acceptbutton_Click(object sender, EventArgs e1,string name) {
            try
            {
             //   Button btn = (Button)sender;
               // string id = btn.CommandArgument;
                string session = Session["member_id"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                    );
                con.Open();
                SqlCommand cmd = new SqlCommand("Accept_Friend_Request", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email1", SqlDbType.VarChar, 50).Value = name;
                cmd.Parameters.Add("@email2", SqlDbType.VarChar, 50).Value = session;
                cmd.ExecuteNonQuery();
                Response.Redirect("/Users/FriendRequests.aspx");

                con.Close();
            }catch(Exception ex){
                Response.Write("AcceptButton" + ex.ToString());
            
            }
        }


    }
}
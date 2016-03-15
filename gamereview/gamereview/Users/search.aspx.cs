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
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Games_Click(object sender, EventArgs e)
        {

            try{

             SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                    );
                con.Open();
                SqlCommand cmd = new SqlCommand("Members_Search_Games", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value =SearchBar.Text;
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    string gameid=rdr.GetInt32(0).ToString();
                    string gamename = rdr.GetString(1);
                  HyperLink gamehyperlink=new HyperLink();
                    gamehyperlink.ID = "game"+gamename;
                    gamehyperlink.Text = gamename + "<br/>";
                    gamehyperlink.NavigateUrl="/Games/GameInformation.aspx?id="+gameid+"&GameName="+gamename;
                    form1.Controls.Add(gamehyperlink);


                }

                con.Close();
            }catch(Exception ex){
                Response.Write("labels"+ex.ToString());

            
            
            }
        }

        protected void Conferences_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                       );
                con.Open();
                SqlCommand cmd = new SqlCommand("Members_Search_Conferences", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = SearchBar.Text;
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    string conferenceid = rdr.GetInt32(0).ToString();
                    string conferenceName = rdr.GetString(1);
                    HyperLink conferencehyperlink = new HyperLink();
                    conferencehyperlink.ID = "conference" + conferenceName;
                    conferencehyperlink.Text = conferenceName + "<br/>";
                    conferencehyperlink.NavigateUrl = "/Conferences/ConferenceProfile.aspx?id=" + conferenceid;
                    form1.Controls.Add(conferencehyperlink);
                    

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("labels" + ex.ToString());



            }
        }

        protected void Communties_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                       );
                con.Open();
                SqlCommand cmd = new SqlCommand("Members_Search_Communities", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = SearchBar.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string gameid = rdr.GetString(0).ToString();
                    string gamename = rdr.GetString(1);
                    HyperLink communityhyperlink = new HyperLink();
                    communityhyperlink.ID = "game" + gamename;
                    communityhyperlink.Text = gamename + "<br/>";
                    communityhyperlink.NavigateUrl = "/communities.aspx?theme="+gameid;
                    form1.Controls.Add(communityhyperlink);


                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("labels" + ex.ToString());



            }
        }

        protected void Development_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                       );
                con.Open();
                SqlCommand cmd = new SqlCommand("Members_Search_Development_Team", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = SearchBar.Text;
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    string dtid = rdr.GetString(0).ToString();
                    string dtname = rdr.GetString(1);
                    HyperLink dthyperlink = new HyperLink();
                    dthyperlink.ID = "dt" + dtname;
                    dthyperlink.Text = dtname+"<br/>";
                    dthyperlink.NavigateUrl = "/Users/DevelpomentTeamsView.aspx?id=" + dtid;
                    form1.Controls.Add(dthyperlink);


                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("labels" + ex.ToString());



            }

        }

        protected void verified_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                       );
                con.Open();
                SqlCommand cmd = new SqlCommand("Members_Search_Verified_Reviewers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = SearchBar.Text;
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    string verifiedid = rdr.GetString(0).ToString();
                    string verifiedname = rdr.GetString(1);
                    HyperLink verifiedhyperlink = new HyperLink();
                    verifiedhyperlink.ID = "verified" + verifiedname;
                    verifiedhyperlink.Text = verifiedname+"<br/>";
                    verifiedhyperlink.NavigateUrl = "/Users/verifiedviews.aspx?id=" + verifiedid;
                    form1.Controls.Add(verifiedhyperlink);


                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("labels" + ex.ToString());



            }
        }
    }
}
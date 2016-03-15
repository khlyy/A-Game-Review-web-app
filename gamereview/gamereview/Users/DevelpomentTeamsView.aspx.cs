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
    public partial class DevelpomentTeamsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                String session = Request.QueryString["id"].ToString(); 
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                    );
                con.Open();
                string Memberinfo = "select * from  Members where e_mail='" + session + "'";
                SqlCommand Membercmd = new SqlCommand(Memberinfo, con);
                SqlDataReader memberreader = Membercmd.ExecuteReader();
                memberreader.Read();
                string usermail = memberreader.GetString(0);
                string preferedgamestring = memberreader.GetString(2);

                con.Close();
                SqlConnection com = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                   );
                com.Open();
                string dt = "select * from Development_Teams where e_mail='" + session + "'";

                SqlCommand dtcmd = new SqlCommand(dt, com);
                SqlDataReader dtreader = dtcmd.ExecuteReader();
                dtreader.Read();
                string teamnamestring = dtreader.GetString(1);
                string companystring = dtreader.GetString(2);
                string formationdate = dtreader.GetDateTime(3).ToString();
                Email.Text = "Email:" + usermail;
                teamname.Text = "teamname:" + teamnamestring;
                company.Text = "companyname:" + companystring;
                dateofformation.Text = "membershiptype:" + formationdate;
                preferedgame.Text = "Preferedgame:" + preferedgamestring;
                com.Close();
            }
            catch (Exception ex)
            {
                Response.Write("error message" + ex.ToString());
            }


        }
    }
}
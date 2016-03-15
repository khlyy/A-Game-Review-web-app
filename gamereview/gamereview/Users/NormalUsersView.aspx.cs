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
    public partial class NormalUsersView : System.Web.UI.Page
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
                string membershiptypestring = memberreader.GetString(3);
                con.Close();
                SqlConnection com = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString
                   );
                com.Open();
                string Normaluser = "select * from Normal_Users where e_mail='" + session + "'";

                SqlCommand NormalUsercmd = new SqlCommand(Normaluser, com);
                SqlDataReader normaluserreader = NormalUsercmd.ExecuteReader(CommandBehavior.CloseConnection);
                normaluserreader.Read();
                string firstnamestring = normaluserreader.GetString(1);
                string lastnamestring = normaluserreader.GetString(2);
                string dateofbirthstring = normaluserreader.GetDateTime(3).ToString();
                string agestring = normaluserreader.GetInt32(4).ToString();
                Email.Text = "Email:" + usermail;
                firstname.Text = "FirstName:" + firstnamestring;
                lastname.Text = "lastname:" + lastnamestring;
                dateofbitrh.Text = "datebirth:" + dateofbirthstring;
                age.Text = "age:" + agestring;
                membershipType.Text = "membershiptype:" + membershiptypestring;
                preferedgame.Text = "preferedgame:" + preferedgamestring;
                com.Close();

            }
            catch (Exception ex)
            {
                Response.Write("error message" + ex.ToString());
            }
        }
    }
}
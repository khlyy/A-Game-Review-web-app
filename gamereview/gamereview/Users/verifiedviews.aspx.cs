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
    public partial class verifiedviews : System.Web.UI.Page
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
                string verifieduser = "select * from Verified_Reviewers where e_mail='" + session + "'";

                SqlCommand verifiedusercmd = new SqlCommand(verifieduser, com);
                SqlDataReader verifieduserreader = verifiedusercmd.ExecuteReader();
                verifieduserreader.Read();
                string firstnamestring = verifieduserreader.GetString(1);
                string lastnamestring = verifieduserreader.GetString(2);
                string yearsofexperiencestring = verifieduserreader.GetInt32(3).ToString();
                Email.Text ="Email:"+ usermail;
                firstname.Text = "FirstName:"+firstnamestring;
                lastname.Text = "lastname:"+lastnamestring;
                membershipType.Text = "membershiptype:"+membershiptypestring;
                preferedgame.Text ="preferedgame:"+ preferedgamestring;
                yearsofexperience.Text = "yearsofexperience:" + yearsofexperiencestring;
                com.Close();
            }
            catch (Exception ex) { 
           Response.Write("error message"+ex.ToString());
            }

            
        }
        }
        }
    

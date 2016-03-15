using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace gamereview.Conferences
{
    public partial class AttendedConferences : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["gameConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT C.name , C.conference_id FROM Conferences C left outer join Members_Attend_Conferences MAC ON C.conference_id = MAC.conference_id WHERE MAC.member_id ='"+Session["member_id"]+"'",con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string Conference = rdr.GetString(0);
                string id = rdr.GetInt32(1).ToString();
                HyperLink ConferenceLink = new HyperLink();
                ConferenceLink.Text = Conference + " <br/>";
                ConferenceLink.NavigateUrl = "/Conferences/ConferenceProfile.aspx?id=" + id;
                form1.Controls.Add(ConferenceLink);
            }
            con.Close();
        }
    }
}
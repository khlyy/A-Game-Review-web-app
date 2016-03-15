using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace Game
{
    public partial class ChooseGame1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["member_id"] = "baher@gmail.com";
            
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Session["GameName"] = DropDownList_Choose_Game.SelectedItem.ToString();

            String GameName = DropDownList_Choose_Game.SelectedItem.ToString();
            Response.Redirect("GameInformation.aspx?GameName="+GameName);



        }
    }
}
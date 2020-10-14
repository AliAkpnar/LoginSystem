using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSystem
{
    public partial class Standart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {

            Data.setOnline(Session["Email"].ToString(),0);
            Session.Clear();
            Response.AddHeader("REFRESH", string.Concat("1;URL=", Data.Pages.Login, ".aspx"));
        }
    }
}
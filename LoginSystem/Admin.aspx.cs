using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSystem
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            onlineUsers.Text = "Online Users: " + Data.getOnlineUserCount();
            registerCount.Text = "Successfully Registered Users in 1 Day: " + Data.getRegisteredInOneDay();
            notVertified.Text = "Users Registered but Not Verified After 1 Day: " + Data.getNotVerifiedAfterOneDay();
            registerAverage.Text = "How Long It Takes to Complete A Login Average: " + Data.getAverageRegistriation()+" Seconds";
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Data.setOnline(Session["Email"].ToString(), 0);
                Session.Clear();
                Response.AddHeader("REFRESH", string.Concat("1;URL=", Data.Pages.Login, ".aspx"));
            }
            catch (Exception)
            {
                Response.AddHeader("REFRESH", string.Concat("1;URL=", Data.Pages.Login, ".aspx"));
            }
        }
    }
}
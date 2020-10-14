using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lib;
namespace ExpenseApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            //Giriş yapma işlemi
            string email = Request.Form["Email"];
            string password = Request.Form["Password"];
            if (Data.Login(email, password))
            {
                Warning.Text = string.Concat("Login Successful " , email, "! Redirecting...");
                Warning.Visible = true;
                Warning.ForeColor = Color.Green;
                Session.Add("Email", email);
                Response.AddHeader("REFRESH", string.Concat("1;URL=",Data.getUser(email).Role,".aspx"));
            }
            else
            {
                Warning.Text = "Wrong Username/Password or Account not verified.";
                Warning.ForeColor = Color.Red;
                Warning.Visible = true;
            }
        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", string.Concat("1;URL=Register.aspx"));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", string.Concat("1;URL=Retrieve.aspx"));
        }

        protected void verify_Click(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", string.Concat("1;URL=Vertification.aspx"));
        }
    }
}
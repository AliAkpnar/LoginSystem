using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSystem
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerButton_Click(object sender, EventArgs e)
        {
            string name = Nametb.Text;
            string surname = Surnametb.Text;
            string email = Emailtb.Text;
            string password = Passwordtb.Text;
            string secretq = Secretqtb.Text;
            string secreta = Secretatb.Text;
            Data.Register(name, surname, email, password, secretq, secreta, Response);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           

           
        }
    }
}
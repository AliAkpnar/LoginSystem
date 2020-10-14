using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSystem
{
    public partial class Retrieve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void retrieveButton_Click(object sender, EventArgs e)
        {
            Data.retrievePassword(Emailtb.Text, Secretqtb.Text, Secretatb.Text, Warning);
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect(Data.Pages.Login.ToString() + ".aspx");
        }
    }
}
using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSystem
{
    public partial class Vertification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void vertifyButton_Click(object sender, EventArgs e)
        {
            Data.Vertify(Vertiftb.Text, Emailtb.Text, Response, Label1);
        }
    }
}
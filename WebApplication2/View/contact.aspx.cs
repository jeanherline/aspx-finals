using act;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.View
{
    public partial class contact : System.Web.UI.Page
        
    {
        database db = new database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["username"]) == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            db.save(name.Text, email.Text, phone.Text, message.Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Record Added!')", true);
        }

    }
}
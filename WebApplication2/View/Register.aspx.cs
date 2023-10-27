using act;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Web.Services.Description;
using System.Web.UI;

namespace WebApplication2
{
    public partial class Register : Page
    {
        database db = new database();
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            db.add(name.Text, password.Text);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Record Added!')", true);
        }

    }
}

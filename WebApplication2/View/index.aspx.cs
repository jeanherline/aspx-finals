using act;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.View
{
    public partial class index : System.Web.UI.Page
    {
        database data = new database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["username"]) == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string useremail = Session["username"].ToString();
                userName.Text = "Welcome, " + useremail;
            }

            data.con.Open();
            SqlCommand cmd = new SqlCommand("Select message from tblInfo", data.con);
            cmd.CommandType = CommandType.Text;

            string temp = "";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                temp += reader["message"].ToString() + "<br/>" + "<hr>";

            data.con.Close();
            Label1.Text = temp;

        }
    }
}
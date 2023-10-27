using act;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        database data = new database(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            data.con.Open();
            SqlCommand cmd = new SqlCommand("select * from tblUsers where username ='" + username.Text +
                "' and password = '" + password.Text + "'", data.con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Session["username"] = dr["username"].ToString();
                //Response.Redirect("List.aspx");
                Response.Redirect("Regiss.aspx");
                //Response.Redirect("index.aspx");
            }
            data.con.Close();
        }
    

        protected void Button1_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            // Define your SQL query for checking credentials
            string query = "SELECT * FROM tblUsers WHERE username = '" + enteredUsername + "' AND password = '" + enteredPassword + "'";

            // Call the isValidUsers method to check credentials
            data.isValidUsers(query, enteredUsername, enteredPassword);

            username.Text = "";
            password.Text = "";
        }

    }
}

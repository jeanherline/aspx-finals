using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using System.Web.UI;

namespace act
{
    public class database
    {

        public SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Jea;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public void save(string userName, string userEmail, string userPhone, string userMessage)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblInfo values ('" + userName + "', '" + userEmail + "', '" + userPhone + "', '" + userMessage + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void add(string userName, string userPassword)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblUsers values ('" + userName + "', '" + userPassword + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void isValidUsers(string query, string userName, string userPassword)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, this.con);
            SqlCommand sqlAlternative = new SqlCommand("SELECT * FROM tblUsers WHERE username = '" + userName + "' AND password = '" + userPassword + "'");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmd.ExecuteNonQuery();
            if (dt.Rows.Count > 0)
            {
                HttpContext.Current.Response.Redirect("List.aspx");
            }
            else
            {
                HttpContext.Current.Response.Write("Invalid Username and Password");
            }
            con.Close();
        }

        public void viewList(GridView list, string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            list.DataSource = dt;
            list.DataBind();
        }

        public void popupateDDL(DropDownList userId, string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            userId.DataSource = dt;
            userId.DataTextField = "Id";
            userId.DataBind();
        }
        public void save(string sqlCheckId, string sqlCreate, string sqlUpdate)
        {
            con.Open();
            SqlCommand cmdCheckId = new SqlCommand(sqlCheckId, con);
            SqlDataAdapter da = new SqlDataAdapter(cmdCheckId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand(sqlCreate, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        public void delete(string infoId)
        {
            con.Open();
            string sqlDelete = "delete from tblInfo where id = '" + infoId + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deletes(string userId)
        {
            con.Open();
            string sqlDelete = "delete from tblUsers where id = '" + userId + "'";
            SqlCommand cmd = new SqlCommand(sqlDelete, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string Pokemon(string userEmail)
        {
            string userType = "";

            con.Open();

            string query = "SELECT userType FROM tblUsers WHERE username = '" + userEmail + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                userType = reader["userType"].ToString();
            }
            con.Close();
            return userType;
        }
    }
    }

    

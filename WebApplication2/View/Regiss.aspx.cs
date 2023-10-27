using act;
using System;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Regiss : System.Web.UI.Page
    {
         database data = new database();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string userEmail = Session["username"].ToString();
            string userType = data.Pokemon(userEmail);

            if (userType == "admin")
            {
                Button1.Enabled = true;
                Button2.Enabled = true;
                Button3.Enabled = true;
                Button4.Enabled = true;
            }
            else if (userType == "client")
            {
                Button1.Enabled = false;
                Button2.Enabled = false;
                Button3.Enabled = false;
                Button4.Enabled = false;
                GridView2.Enabled = false;

            }

            if (!IsPostBack)

                data.popupateDDL(DropDownList1, "SELECT DISTINCT Id FROM tblUsers");
            data.viewList(GridView2, "SELECT * FROM tblUsers");

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.viewList(GridView2, "SELECT * FROM tblUsers WHERE Id = '" + DropDownList1.SelectedValue + "'");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            data.viewList(GridView2, "SELECT * FROM tblUsers");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView2.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView2.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView2.SelectedRow.Cells[3].Text;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sqlInsert = "insert into tblUsers values ('" + TextBox2.Text + "', '" + TextBox3.Text + "')";
            string CheckRecord = "select id from tblUsers where id = '" + TextBox1.Text + "'";
            string sqlEdit = "update tblUsers set username = '" + TextBox2.Text + "', password = '" + TextBox3.Text + "' where id = '" + TextBox1.Text + "'";
           
            data.save(CheckRecord, sqlInsert, sqlEdit);
            data.viewList(GridView2, "select * from tblUsers");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            
            TextBox2.Focus();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            
            TextBox2.Focus();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            data.deletes(TextBox1.Text);
                
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            
            data.viewList(GridView2, "select * from tblUsers");
        }
    }
}
        
 

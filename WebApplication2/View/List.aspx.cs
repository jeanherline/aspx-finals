using act;
using System;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class List : System.Web.UI.Page
    {
        private readonly database data = new database();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data.popupateDDL(DropDownList1, "SELECT DISTINCT Id FROM tblBlog");
                data.viewList(GridView1, "SELECT * FROM tblBlog"); // Ayusin ang SQL query
               
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            data.viewList(GridView1, "SELECT * FROM tblBlog WHERE Id = '" + DropDownList1.SelectedValue + "'");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            data.viewList(GridView1, "SELECT * FROM tblBlog");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
            TextBox2.Text = GridView1.SelectedRow.Cells[2].Text;
            TextBox3.Text = GridView1.SelectedRow.Cells[3].Text;
            TextBox4.Text = GridView1.SelectedRow.Cells[4].Text;
            TextBox5.Text = GridView1.SelectedRow.Cells[5].Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sqlInsert = "insert into tblInfo values ('" + TextBox2.Text + "', '" + TextBox3.Text + "', '" + TextBox4.Text + "', '" + TextBox5.Text + "')";
            string CheckRecord = "select id from tblInfo where id = '" + TextBox1.Text + "'";
            string sqlEdit = "update tblInfo set name = '" + TextBox2.Text + "', email = '" + TextBox3.Text + "', phone = '" + TextBox4.Text + "', message = '" + TextBox5.Text + "' where id = '" + TextBox1.Text + "'";

            data.save(CheckRecord, sqlInsert, sqlEdit);
            data.viewList(GridView1, "select * from tblInfo");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox2.Focus();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox2.Focus();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            data.delete(TextBox1.Text);
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            data.viewList(GridView1, "select * from tblInfo");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace notebook
{
    public partial class MainPage : System.Web.UI.Page
    {
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null||Session["username"].ToString().Trim().Length<=0)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            String title = button.Text;
            String sql = "select * from usernote where notetitle=@notetitle";
            SqlParameter[] param =
            {
                new SqlParameter("notetitle",title)
            };
            var result = sqlHelp.ExecuteReader(sqlHelp.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql, param);
            if (result.Read())
            {
                id = result.GetInt32(0);
                String content = result.GetString(3);
                txtTitle.Text = title.Trim(); ;
                txtContent.Text = content;
                Session["id"] = id;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text.Equals("修改"))
            {
                txtTitle.Enabled = true;
                txtContent.Enabled = true;
                Button1.Text = "保存";
                Button2.Visible = true;
            }
            else
            {
                if (txtTitle.Text.Trim().Length <= 0)
                {
                    Response.Write("<script>alert('标题不能为空')</script>");
                    return;
                }
                else if (txtContent.Text.Trim().Length <= 0)
                {
                    Response.Write("<script>alert('内容成不能为空)</script>");
                    return;
                }
                String title = txtTitle.Text;
                String content = txtContent.Text;
                String sql = "update usernote set notetitle=@notetitle,notecontent=@notecontent where id=@id";
                int id = int.Parse(Session["id"].ToString());
                SqlParameter[] param =
                {
                    new SqlParameter("notetitle",title),
                    new SqlParameter("notecontent",content),
                    new SqlParameter("id",id)
                };
                sqlHelp.ExecuteNonQuery(sqlHelp.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql, param);
                txtTitle.Enabled = false;
                txtContent.Enabled = false;
                Button2.Visible = false;
                Button1.Text = "修改";
                DataList1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.Text = "修改";
            txtTitle.Enabled = false;
            txtContent.Enabled = false;
            Button2.Visible = false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace notebook
{
    public partial class MainPage : System.Web.UI.Page
    {
        int id;
        String image;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null||Session["username"].ToString().Trim().Length<=0)
            {
                Response.Redirect("Login.aspx");
            }
            Image1.Visible = false;
            DataList1.DataBind();
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
                image = result.GetString(4);
                Session["id"] = id;
                Image1.ImageUrl = image;
                if(image.Length<=0)
                {
                    Image1.Visible = false;
                }
                else
                {
                    Image1.Visible = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text.Equals("修改"))
            {
                txtTitle.Enabled = true;
                txtContent.Enabled = true;
                Image1.Visible = false;
                FileUpload1.Visible = true;
                Button1.Text = "保存";
                Button2.Visible = true;
                btnDelete.Visible = false;
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
                String noteImage = "~/Images/" + Session["username"].ToString() + "/" + FileUpload1.FileName + "";
                String sql = "update usernote set notetitle=@notetitle,notecontent=@notecontent,noteimage=@noteimage where id=@id";
                int id = int.Parse(Session["id"].ToString());
                SqlParameter[] param =
                {
                    new SqlParameter("notetitle",title),
                    new SqlParameter("notecontent",content),
                    new SqlParameter("noteimage",FileUpload1.FileName.Length<=0?"":noteImage),
                    new SqlParameter("id",id)
                };
                sqlHelp.ExecuteNonQuery(sqlHelp.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql, param);
                if (FileUpload1.FileName.Length > 0)
                {
                    upLoadPhoto(FileUpload1, Session["username"].ToString());
                }
                txtTitle.Enabled = false;
                txtContent.Enabled = false;
                Button2.Visible = false;
                FileUpload1.Visible = false;
                Image1.Visible = FileUpload1.FileName.Length > 0 ? true : false;
                Image1.ImageUrl = noteImage;
                Button1.Text = "修改";
                btnDelete.Visible = true;
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
        public void upLoadPhoto(FileUpload e, string username)
        {
            if (Directory.Exists(Server.MapPath("~/Images/" + username)))
            {
                int i = 0;
                string oldFileName = e.FileName;
                string newFileName = oldFileName;

                while (File.Exists(Server.MapPath("~/Images/" + username + "/" + newFileName)))
                {
                    newFileName = oldFileName.Insert(oldFileName.LastIndexOf("."), i.ToString());
                    i++;
                }
                e.SaveAs(Server.MapPath("~/Images/" + username + "/" + newFileName));

            }
            else
            {
                Directory.CreateDirectory(Server.MapPath("~/Images/") + username);
                upLoadPhoto(e, username);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            String sql = "delete from usernote where id=@id";
            int id = int.Parse(Session["id"].ToString());
            SqlParameter[] param =
            {
                new SqlParameter("id",id)
            };
            sqlHelp.ExecuteNonQuery(sqlHelp.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql, param);
            DataList1.DataBind();
            Response.Write("<script>alert('删除成功')</script>");
        }
    }
}
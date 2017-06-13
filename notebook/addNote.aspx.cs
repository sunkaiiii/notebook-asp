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
    public partial class addNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString().Trim().Length <= 0)
            {
                Response.Redirect("Login.aspx");
            }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim().Length <= 0)
            {
                Response.Write("<script>alert('标题不能为空')</script>");
                return;
            }
            String title = txtTitle.Text;
            String content = txtContent.Text;
            String image = "~/Images/" + Session["username"].ToString() + "/" + FileUpload1.FileName + "";
            String sql = "insert into usernote values(@userName,@notetitle,@notecontent,@noteimage)";
            SqlParameter[] param =
            {
                new SqlParameter("userName",Session["username"].ToString()),
                new SqlParameter("notetitle",title),
                new SqlParameter("notecontent",content),
                new SqlParameter("noteimage",FileUpload1.FileName.Length<=0?"":image)
            };
            sqlHelp.ExecuteNonQuery(sqlHelp.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql, param);
            if (FileUpload1.FileName.Length > 0)
            {
                upLoadPhoto(FileUpload1, Session["username"].ToString());
            }
            Response.Write("<script>alert('添加成功')</script>");
            Response.Redirect("MainPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");
        }
    }
}
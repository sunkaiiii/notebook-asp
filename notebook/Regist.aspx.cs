using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace notebook
{
    public partial class Regist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegist_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length <= 0 || txtPassword.Text.Length <= 0 || txtPassword2.Text.Length <= 0 || !txtPassword.Text.Equals(txtPassword2.Text))
            {
                return;
            }
            String userName = txtName.Text;
            String userPassword = txtPassword.Text;
            String sql;
            sql = "select count(*) from userinfo where username=@userName";
            SqlParameter[] param;
            param = new SqlParameter[]
            {
                new SqlParameter("userName",userName)
            };
            int userCount = (int)sqlHelp.ExecuteScalar(sqlHelp.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql, param);
            if (userCount > 0)
            {
                Response.Write("<script>alert('已有该用户名')</script>");
                return;
            }
            sql = "insert into userinfo values(@userName,@userPassword)";
            param =new SqlParameter[]
            {
                new SqlParameter("userName",userName),
                new SqlParameter("userPassword",userPassword),
            };
            sqlHelp.ExecuteNonQuery(sqlHelp.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql, param);
            Response.Write("<script>alert('注册成功')</script>");
            this.RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            this.RegisterClientScriptBlock("e", "<script language=javascript>history.go(-2);</script>");
        }
    }
}
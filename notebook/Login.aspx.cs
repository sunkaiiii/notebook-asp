using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace notebook
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            String userName = Login1.UserName;
            String passWord = Login1.Password;
            String sql = "select count(*) from userinfo where username=@userName and userpassword=@password";
            SqlParameter[] param =
            {
                new SqlParameter("userName",userName),
                new SqlParameter("password",passWord),
            };
            int userCount = (int)sqlHelp.ExecuteScalar(sqlHelp.ConnectionStringLocalTransaction, System.Data.CommandType.Text, sql, param);
            if (userCount > 0)
            {
                Session["username"] = userName;
                e.Authenticated = true;
                //Response.Redirect("MainPage.aspx");
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}
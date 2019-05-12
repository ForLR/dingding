using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Linq;
using Dal;

namespace bishe
{
    public partial class login : Page
    {
        public MySqlConnection sqlConnection;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button_Queding_Click(object sender, EventArgs e)
        {
            //查询用户名和密码是否存在数据库 不存在则显示用户名或密码输入有误
            var sql = $"select count(1) FROM users where getdata!=1 and user_name ='{TextBox_User.Text}' and pass_word='{TextBox_Pwd.Text}'";
                var any = SqlHelper.ExecuteScalar(sql).ToString();
                if (Convert.ToInt16(any) == 0)
                {
                    Response.Write("<script>alert('用户名或密码输入有误!')</script>");
                    TextBox_User.Text = string.Empty;
                    TextBox_Pwd.Text = string.Empty;
                    return;
                }
                Session["User"] = TextBox_User.Text;
                Response.Redirect("xuanze.aspx");
            
          
        }

        protected void TextBox_User_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_Pwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
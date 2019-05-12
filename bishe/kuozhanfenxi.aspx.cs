using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace bishe
{
    public partial class kuozhanfenxi : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button_Paihangbang_Click(object sender, EventArgs e)
        {
            //跳转到排行榜
            Response.Redirect("paihangbang.aspx");
        }

        protected void Button_Qushifenxi_Click(object sender, EventArgs e)
        {
            //跳转趋势分析
            Response.Redirect("qushifenxi.aspx");
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            //跳转到选择
            Response.Redirect("xuanze.aspx");
        }
    }
}
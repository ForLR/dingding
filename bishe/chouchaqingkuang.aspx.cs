using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace bishe
{
    //抽查情况页面
    public partial class chouchaqingkuang : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button_Shijianchoucha_Click(object sender, EventArgs e)
        {
            //跳到时间抽查
            Response.Redirect("shijianchoucha.aspx");
        }

        protected void Button_Xuehaochoucha_Click(object sender, EventArgs e)
        {
            //跳到学号抽查
            Response.Redirect("xuehaochoucha.aspx");
        }

        protected void Button_Chouchaqushi_Click(object sender, EventArgs e)
        { //跳到抽查趋势
            Response.Redirect("chouchaqushi.aspx");
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        { //跳到选择页面
            Response.Redirect("xuanze.aspx");
        }
    }
}
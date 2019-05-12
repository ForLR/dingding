using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bishe
{
    public partial class pingfenbangdan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection sqlConnection = new MySqlConnection(sqlString);
            sqlConnection.Open();

            var weidaka = ConfigurationManager.AppSettings["weidaka"];
            var zaotui = ConfigurationManager.AppSettings["zaotui"];
            var chidao = ConfigurationManager.AppSettings["chidao"];

            var sql = $" SELECT f.`名字`, (100-f.未打卡次数*{weidaka}-f.迟到次数*{chidao}-f.早退次数*{zaotui}) as 评分 from  (SELECT u.user_name as 名字," +
                "( SELECT count(*) from yuanshijilus as y where y.`打卡结果`='早退' and u.user_id=y.user_id ) as 早退次数," +
                " ( SELECT count(*) from yuanshijilus as y where y.`打卡结果`='迟到' and u.user_id=y.user_id ) as 迟到次数, " +
                " (SELECT count(*) from yuanshijilus as y where y.`打卡结果`='未打卡' and u.user_id=y.user_id) as 未打卡次数" +
                " from users as u where u.getdata=1 GROUP BY u.id   ) as f order BY 评分 desc";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection);

            DataSet ds = new DataSet();

            sqlDataAdapter.Fill(ds, "linshi");
            GridView_pingfenbangdan.DataSource = ds;
            GridView_pingfenbangdan.DataBind();

            sqlConnection.Close();
        }

        protected void GridView_pingfenbangdan_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("xuanze.aspx");
        }
    }
}
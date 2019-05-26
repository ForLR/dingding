using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace bishe
{
    //排行榜
    public partial class paihangbang : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }
        /// <summary>
        /// 优秀出勤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Youxiuchuqinbang_Click(object sender, EventArgs e)
        {
            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection sqlConnection = new MySqlConnection(sqlString);
            sqlConnection.Open();

            var cmdString = "SELECT  b.名字 as 名字,count(b.名字) as 次数 from ( " +
                " SELECT any_value(a.名字) as 名字, any_value(a.时间) from( " +
               "SELECT DATE_FORMAT(any_value(y.`考勤时间`), '%Y-%m-%d %H:%i') as 时间, any_value(u.user_name) as 名字,  CASE  WHEN " +
               " any_value(y.`考勤时间`)> DATE_FORMAT(any_value(y.`考勤时间`), '%Y-%m-%d 13:00') THEN  DATE_FORMAT(any_value(y.`考勤时间`), '%Y-%m-%d 18:00') " +
               "ELSE  DATE_FORMAT(any_value(y.`考勤时间`), '%Y-%m-%d 12:00')  END as 日期 from yuanshijilus  as y " +
               "RIGHT join users as u on u.user_id = y.user_id " +
              $" WHERE y.`打卡结果`= '正常') as a GROUP BY a.名字,a.日期 HAVING count(a.日期) > 1 ) as b GROUP BY b.名字  ORDER BY 次数 desc ";
        
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmdString, sqlConnection);

            DataSet ds = new DataSet();

            sqlDataAdapter.Fill(ds, "yuanshijilu");
            GridView_Paihangbang.DataSource = ds;
            GridView_Paihangbang.DataBind();

            sqlConnection.Close();
        }
        /// <summary>
        /// 勤奋榜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Qinfenbang_Click(object sender, EventArgs e)
        {
            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection sqlConnection = new MySqlConnection(sqlString);
            sqlConnection.Open();

            var sql = "SELECT count(y.id) as 勤奋次数,u.user_name as 名字,u.pass_word as 学号,u.role as 职位 from yuanshijilus as y " +
                  "LEFT join users as u on u.user_id = y.user_id " +
                  "WHERE(DATE_FORMAT(y.`考勤时间`, '%H:%i') = '08:30' AND DATE_FORMAT(y.`打卡时间`, '%H:%i') > '08:00' AND DATE_FORMAT(y.`打卡时间`, '%H:%i') < '08:15') or(DATE_FORMAT(y.`考勤时间`, '%H:%i') = '14:00' AND DATE_FORMAT(y.`打卡时间`, '%H:%i') > '13:30' AND DATE_FORMAT(y.`打卡时间`, '%H:%i') < '13:45') GROUP BY u.user_id,u.user_name,u.pass_word,u.role ORDER BY 勤奋次数 desc";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection);

            DataSet ds = new DataSet();

            sqlDataAdapter.Fill(ds, "yuanshijilu");
            GridView_Paihangbang.DataSource = ds;
            GridView_Paihangbang.DataBind();

            sqlConnection.Close();
        }
        /// <summary>
        /// 迟到榜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Chidaobang_Click(object sender, EventArgs e)
        {
            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection sqlConnection = new MySqlConnection(sqlString);
            sqlConnection.Open();

            var cmdString = "SELECT count('迟到') as 迟到次数,u.user_name as 名字,u.pass_word as 学号,u.role as 职位 from yuanshijilus as y " +
                "LEFT join users as u on u.user_id = y.user_id  WHERE y.打卡结果='迟到' GROUP BY  u.user_id,u.user_name,u.pass_word,u.role ORDER BY 迟到次数 desc";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmdString, sqlConnection);

            DataSet ds = new DataSet();

            sqlDataAdapter.Fill(ds, "yuanshijilu");
            GridView_Paihangbang.DataSource = ds;
            GridView_Paihangbang.DataBind();

            sqlConnection.Close();
        }
        /// <summary>
        /// 旷工榜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Kuanggongbang_Click(object sender, EventArgs e)
        {
            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection sqlConnection = new MySqlConnection(sqlString);
            sqlConnection.Open();
            var nsql = " SELECT a.名字, a.时间,CASE WHEN a.时间 > DATE_FORMAT(any_value(a.时间), '%Y-%m-%d 13:00') THEN " +
                "DATE_FORMAT(any_value(a.时间), '%Y-%m-%d 18:00') ELSE DATE_FORMAT(any_value(a.时间), '%Y-%m-%d 12:00' )  " +
                "END AS 日期 from( SELECT  DATE_FORMAT( any_value(y.`考勤时间`), '%Y-%m-%d %H:%i' ) AS 时间," +
                " any_value(u.user_name) AS 名字,CASE WHEN any_value(y.`考勤时间`) > DATE_FORMAT(any_value(y.`考勤时间`), '%Y-%m-%d 13:00') THEN DATE_FORMAT(any_value(y.`考勤时间`), '%Y-%m-%d 18:00') ELSE DATE_FORMAT(any_value(y.`考勤时间`), '%Y-%m-%d 12:00' ) END AS 日期 from yuanshijilus as y " +
                 $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡'  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
                 $"as y left join users as u on u.user_id = y.user_id " +
                 $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡'  AND " +
                 $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as a GROUP BY a.名字,a.日期 HAVING count(a.日期) > 1 ";
            var sql = $"SELECT b.名字,count(b.名字) as 次数 from ( {nsql}) as b GROUP BY b.名字" +
              $" ORDER BY 次数 desc ";
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection);

            DataSet ds = new DataSet();

            sqlDataAdapter.Fill(ds, "linshi");
            GridView_Paihangbang.DataSource = ds;
            GridView_Paihangbang.DataBind();

            sqlConnection.Close();
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("kuozhanfenxi.aspx");
        }
        /// <summary>
        /// 导出到excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Shujudaochu_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=排行榜.xls");
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;
            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            GridView_Paihangbang.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void GridView_Paihangbang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using Dal;

namespace bishe
{
    public partial class shijiantongji : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
            TextBox_Kaishishijian.Attributes["onclick"] = ClientScript.GetPostBackEventReference(Button_Kaishishijian, null);
            TextBox_Jieshushijian.Attributes["onclick"] = ClientScript.GetPostBackEventReference(Button_Jieshushijian, null);
           
        }

        protected void Calendar_Kaishishijian_SelectionChanged(object sender, EventArgs e)
        {
            //时间控件的数据格式
            TextBox_Kaishishijian.Text = Calendar_Kaishishijian.SelectedDate.ToString("yyyy-MM-dd");
            Div_Calendar_Kaishishijian.Visible = false;
        }

        protected void TextBox_Kaishishijian_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button_Kaishishijian_Click(object sender, EventArgs e)
        {
            Div_Calendar_Kaishishijian.Visible = !Div_Calendar_Kaishishijian.Visible;
        }

        protected void Calendar_Jieshushijian_SelectionChanged(object sender, EventArgs e)
        {
            TextBox_Jieshushijian.Text = Calendar_Jieshushijian.SelectedDate.ToString("yyyy-MM-dd");
            Div_Calendar_Jieshushijian.Visible = false;
        }

        protected void TextBox_Jieshushijian_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button_Jieshushijian_Click(object sender, EventArgs e)
        {
            Div_Calendar_Jieshushijian.Visible = !Div_Calendar_Jieshushijian.Visible;
        }
        //正常出勤
        protected void Button_Zhengchangchuqin_Click(object sender, EventArgs e)
        {

            var where = "";
            if (!string.IsNullOrWhiteSpace(TextBox_Kaishishijian.Text))
            {
                where += $" and y.考勤时间 >= '{ TextBox_Kaishishijian.Text }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Jieshushijian.Text))
            {
                where += $" and y.考勤时间 <='{ TextBox_Jieshushijian.Text + " 23:59:59" }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Xuehao.Text))
            {
                where += $" and u.pass_word like '%{TextBox_Xuehao.Text}%'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_banji.Text))
            {
                where += $" and u.class_grade='{TextBox_banji.Text}'";
            }
            var sql = $"SELECT u.user_name as 名字,y.考勤时间,y.打卡时间,y.打卡结果 from yuanshijilus  as y " +
                $"left join users as u on u.user_id = y.user_id where  y.打卡结果='正常'  {where}";
            var countSql = $"SELECT count(1) from yuanshijilus  as y " +
                $"left join users as u on u.user_id = y.user_id where  y.打卡结果='正常'  {where}";
            var count = SqlHelper.ExecuteScalar(countSql);
            using (MySqlConnection sqlConnection = new MySqlConnection(SqlHelper.connStr))
            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection))
            {

                DataSet ds = new DataSet();

              
                    sqlDataAdapter.Fill(ds, "yuanshijilu");
                    GridView_Shijiantongji.DataSource = ds;
                    GridView_Shijiantongji.DataBind();
                tongji.Text = $"{TextBox_banji.Text}班级,考勤时间从{TextBox_Kaishishijian.Text}-{TextBox_Jieshushijian.Text}的正常出勤人数一共{count}人次";
            }
        }
        //迟到
        protected void Button_Chidao_Click(object sender, EventArgs e)
        {
            var where = "";
            if (!string.IsNullOrWhiteSpace(TextBox_Kaishishijian.Text))
            {
                where += $" and y.考勤时间 >= '{ TextBox_Kaishishijian.Text }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Jieshushijian.Text))
            {
                where += $" and y.考勤时间 <='{ TextBox_Jieshushijian.Text + " 23:59:59" }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Xuehao.Text))
            {
                where += $" and u.pass_word like '%{TextBox_Xuehao.Text}%'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_banji.Text))
            {
                where += $" and u.class_grade='{TextBox_banji.Text}'";
            }
            var sql = $"SELECT  u.user_name as 名字,y.考勤时间,y.打卡时间,y.打卡结果 from yuanshijilus  as y " +
                $"left join users as u on u.user_id = y.user_id where  y.打卡结果='迟到' {where}";
            var countSql = $"SELECT count(1) from yuanshijilus  as y " +
                $"left join users as u on u.user_id = y.user_id where  y.打卡结果='迟到' {where}";
            var count = SqlHelper.ExecuteScalar(countSql);
            using (MySqlConnection sqlConnection = new MySqlConnection(SqlHelper.connStr))
            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection))
            {

                DataSet ds = new DataSet();

              
                    sqlDataAdapter.Fill(ds, "yuanshijilu");
                    GridView_Shijiantongji.DataSource = ds;
                    GridView_Shijiantongji.DataBind();
                tongji.Text = $"{TextBox_banji.Text}班级,考勤时间从{TextBox_Kaishishijian.Text}-{TextBox_Jieshushijian.Text}的迟到人数一共{count}人次";
            }
        }
        //早退
        protected void Button_Zaotui_Click(object sender, EventArgs e)
        {
            var where = "";
            if (!string.IsNullOrWhiteSpace(TextBox_Kaishishijian.Text))
            {
                where += $"  y.考勤时间 >='{TextBox_Kaishishijian.Text } '";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Jieshushijian.Text))
            {
                where += $" and y.考勤时间 <='{ TextBox_Jieshushijian.Text + " 23:59:59"}";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Xuehao.Text))
            {
                where += $" and u.pass_word like '%{TextBox_Xuehao.Text}%'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_banji.Text))
            {
                where += $" and u.class_grade='{TextBox_banji.Text}'";
            }

            var sql = $"SELECT  u.user_name as 名字,y.考勤时间,y.打卡时间,y.打卡结果 from yuanshijilus  as y " +
                $"left join users as u on u.user_id = y.user_id where " +
                $" y.打卡结果='早退' {where}";
            var countSql = $"SELECT count(1) from yuanshijilus  as y " +
              $"left join users as u on u.user_id = y.user_id where " +
              $" y.打卡结果='早退' {where}";
            var count = SqlHelper.ExecuteScalar(countSql);
            using (MySqlConnection sqlConnection = new MySqlConnection(SqlHelper.connStr))
            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection))
            {

                DataSet ds = new DataSet();

              
                    sqlDataAdapter.Fill(ds, "yuanshijilu");
                    GridView_Shijiantongji.DataSource = ds;
                    GridView_Shijiantongji.DataBind();
                tongji.Text = $"{TextBox_banji.Text}班级,考勤时间从{TextBox_Kaishishijian.Text}-{TextBox_Jieshushijian.Text}的早退人数一共{count}人次";
            }
        }
        //请假
        protected void Button_Qingjia_Click(object sender, EventArgs e)
        {

            var where = "";
            if (!string.IsNullOrWhiteSpace(TextBox_Kaishishijian.Text))
            {
                where += $" and q.开始时间 >= '{ TextBox_Kaishishijian.Text }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Jieshushijian.Text))
            {
                where += $" and q.开始时间 <='{ TextBox_Jieshushijian.Text + " 23:59:59" }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Xuehao.Text))
            {
                where += $" and u.pass_word like '%{TextBox_Xuehao.Text}%'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_banji.Text))
            {
                where += $" and u.class_grade='{TextBox_banji.Text}'";
            }
            var sql = $" SELECT u.user_name as 名字, q.`开始时间`, q.`结束时间`,q.`请假类型`  from qingjias as q left join users u" +
                $" on q.user_id = u.user_id where 1=1 {where}";
            var countSql = $" SELECT  count(1)  from qingjias as q left join users u" +
                $" on q.user_id = u.user_id where 1=1 {where}";
            var count = SqlHelper.ExecuteScalar(countSql);
            using (MySqlConnection sqlConnection = new MySqlConnection(SqlHelper.connStr))
            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection))
            {
                DataSet ds = new DataSet();

              
                    sqlDataAdapter.Fill(ds, "yuanshijilu");
                    GridView_Shijiantongji.DataSource = ds;
                    GridView_Shijiantongji.DataBind();
                tongji.Text = $"{TextBox_banji.Text}班级,考勤时间从{TextBox_Kaishishijian.Text}-{TextBox_Jieshushijian.Text}的请假人数一共{count}人次";
            }
        }
        //缺课
        protected void Button_Queka_Click(object sender, EventArgs e)
        {
            var where = "";
            if (!string.IsNullOrWhiteSpace(TextBox_Kaishishijian.Text))
            {
                where += $" and y.考勤时间 >= '{ TextBox_Kaishishijian.Text }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Jieshushijian.Text))
            {
                where += $" and y.考勤时间 <='{ TextBox_Jieshushijian.Text + " 23:59:59" }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Xuehao.Text))
            {
                where += $" and u.pass_word like '%{TextBox_Xuehao.Text}%'";
            }

            if (!string.IsNullOrWhiteSpace(TextBox_banji.Text))
            {
                where += $" and u.class_grade='{TextBox_banji.Text}'";
            }
            var sql = " SELECT a.名字, a.时间  as 缺卡时间 from( SELECT  DATE_FORMAT( y.`考勤时间`, '%Y-%m-%d %H:%i' ) AS 时间," +
                " u.user_name AS 名字,CASE WHEN y.`考勤时间` > DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 13:00') THEN DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 18:00') ELSE DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 12:00' ) END AS 日期 from yuanshijilus as y " +
                 $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
                 $"as y left join users as u on u.user_id = y.user_id " +
                 $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
                 $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as a GROUP BY a.名字,a.日期 HAVING count(a.日期)= 1 ";


            var countSql = "select count(1) from ( SELECT a.名字,  a.时间  as 缺卡时间 from( SELECT  DATE_FORMAT( y.`考勤时间`, '%Y-%m-%d %H:%i' ) AS 时间," +
                 " u.user_name AS 名字,CASE WHEN y.`考勤时间` > DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 13:00') THEN DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 18:00') ELSE DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 12:00' ) END AS 日期 from yuanshijilus as y " +
                  $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
                  $"as y left join users as u on u.user_id = y.user_id " +
                  $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
                  $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as a GROUP BY a.名字,a.日期 HAVING count(a.日期)=1) as d ";
            var count = SqlHelper.ExecuteScalar(countSql);

            using (MySqlConnection sqlConnection = new MySqlConnection(SqlHelper.connStr))
            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection))
            {
                DataSet ds = new DataSet();

              
                    sqlDataAdapter.Fill(ds, "yuanshijilu");
                    GridView_Shijiantongji.DataSource = ds;
                    GridView_Shijiantongji.DataBind();
                tongji.Text = $"{TextBox_banji.Text}班级,考勤时间从{TextBox_Kaishishijian.Text}-{TextBox_Jieshushijian.Text}的缺课人数一共{count}人次";
            }
        }
        //旷课
        protected void Button_Kuanggong_Click(object sender, EventArgs e)
        {
            var where = "";
            if (!string.IsNullOrWhiteSpace(TextBox_Kaishishijian.Text))
            {
                where += $" and y.考勤时间 >= '{ TextBox_Kaishishijian.Text }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Jieshushijian.Text))
            {
                where += $" and y.考勤时间 <='{ TextBox_Jieshushijian.Text + " 23:59:59" }'";
            }
            if (!string.IsNullOrWhiteSpace(TextBox_Xuehao.Text))
            {
                where += $" and u.pass_word like '%{TextBox_Xuehao.Text}%'";
            }

            if (!string.IsNullOrWhiteSpace(TextBox_banji.Text))
            {
                where += $" and u.class_grade='{TextBox_banji.Text}'";
            }
            var sql = " SELECT a.名字, CASE  WHEN a.时间 > DATE_FORMAT(a.时间, '%Y-%m-%d 12:00') THEN DATE_FORMAT(a.时间, '%Y-%m-%d 下午') " +
                "  ELSE DATE_FORMAT(a.时间, '%Y-%m-%d 上午') END as 旷课时间 from( SELECT  DATE_FORMAT( y.`考勤时间`, '%Y-%m-%d %H:%i' ) AS 时间," +
                " u.user_name AS 名字,CASE WHEN y.`考勤时间` > DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 13:00') THEN DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 18:00') ELSE DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 12:00' ) END AS 日期 from yuanshijilus as y " +
                 $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
                 $"as y left join users as u on u.user_id = y.user_id " +
                 $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
                 $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as a GROUP BY a.名字,a.日期 HAVING count(a.日期) > 1 ";


            var countSql = "select count(1) from ( SELECT a.名字, CASE  WHEN a.时间 > DATE_FORMAT(a.时间, '%Y-%m-%d 12:00') THEN DATE_FORMAT(a.时间, '%Y-%m-%d 下午') " +
                 "  ELSE DATE_FORMAT(a.时间, '%Y-%m-%d 上午') END as 旷课时间 from( SELECT  DATE_FORMAT( y.`考勤时间`, '%Y-%m-%d %H:%i' ) AS 时间," +
                 " u.user_name AS 名字,CASE WHEN y.`考勤时间` > DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 13:00') THEN DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 18:00') ELSE DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 12:00' ) END AS 日期 from yuanshijilus as y " +
                  $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
                  $"as y left join users as u on u.user_id = y.user_id " +
                  $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
                  $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as a GROUP BY a.名字,a.日期 HAVING count(a.日期) > 1) as d ";

            var count = SqlHelper.ExecuteScalar(countSql);
            using (MySqlConnection sqlConnection = new MySqlConnection(SqlHelper.connStr))
            using (MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection))
            {
                DataSet ds = new DataSet();

              
                    sqlDataAdapter.Fill(ds, "yuanshijilus");
                    GridView_Shijiantongji.DataSource = ds;
                    GridView_Shijiantongji.DataBind();
                tongji.Text = $"{TextBox_banji.Text}班级,考勤时间从{TextBox_Kaishishijian.Text}-{TextBox_Jieshushijian.Text}的缺课人数一共{count}人次";
            }
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("xuanze.aspx");
        }

        protected void Button_Shujudaochu_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=按时间统计.xls");
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;
            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            GridView_Shijiantongji.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void GridView_Shijiantongji_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox_Xuehao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
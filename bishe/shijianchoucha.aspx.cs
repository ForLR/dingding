using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using Dal;

namespace bishe
{
    /// <summary>
    ///
    /// </summary>
    public partial class shijianchoucha : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }

            string cmdString = "SELECT  抽查开始时间, 抽查结束时间  FROM choucha ORDER BY 抽查开始时间;";

            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection MySqlConnection = new MySqlConnection(sqlString);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmdString, MySqlConnection);

            MySqlConnection.Open();

            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds, "choucha");
            GridView_Shijianchoucha.DataSource = ds;
            GridView_Shijianchoucha.DataBind();

            MySqlConnection.Close();
        }
        /// <summary>
        ///  时间抽查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView_Shijianchoucha_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SELECT")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string a = GridView_Shijianchoucha.Rows[index].Cells[1].Text;
                string b = GridView_Shijianchoucha.Rows[index].Cells[2].Text;
                var startTime = Convert.ToDateTime(a).ToString("yyyy-MM-dd HH:mm:ss");
                var endTime = Convert.ToDateTime(b).ToString("yyyy-MM-dd HH:mm:ss");
                var cmdString = "select u.user_name as 名字,y.user_id as `学号`,y.`考勤时间` ,y.`考勤日期`,y.`打卡时间`,y.`打卡结果` from yuanshijilus as y LEFT join users as u " +
              $"on u.user_id = y.user_id where `考勤时间` >='{a}' and  `考勤时间` <='{b}'";


       
                var sql = $"SELECT * from ( select '{a}' as 开始时间 ,'{b}' as 结束时间 ,u.user_id,u.user_name as 名字," +
                    
                     $"CASE " +
                     $"when(SELECT count(*) from qingjias as q where DATE_FORMAT(q.`开始时间`, '%Y-%m-%d %H:%i:%s') <= '{startTime}'and " +
                     $"DATE_FORMAT(q.`结束时间`, '%Y-%m-%d %H:%i:%s')>= '{endTime}' and q.user_id = u.user_id)>0 then  '请假'" +
                     $"WHEN(SELECT Min(打卡时间) from dakaxiangqings where 打卡时间 >= '{startTime}' and 打卡时间 < '{Convert.ToDateTime(b).AddMinutes(1).AddMilliseconds(-1).ToString("yyyy-MM-dd HH:mm:ss")}' and  userId = " + "u.user_id) != ' ' THEN '正常'" +
 $"WHEN(SELECT Min(打卡时间) from dakaxiangqings where 打卡时间 <= '{Convert.ToDateTime(b).AddMinutes(30).AddMilliseconds(-1).ToString("yyyy-MM-dd HH:mm:ss")}' and" +
 $" 打卡时间 >= '{Convert.ToDateTime(b).AddMinutes(30).AddMilliseconds(-1).ToString("yyyy-MM-dd HH:mm:ss")}' and  userId = u.user_id) != ' '  then '迟到'" +
 $"  ELSE  '未打卡' END as 打卡状态, (SELECT Min(打卡时间) from dakaxiangqings where 打卡时间 >= '{startTime}' and 打卡时间<= '{endTime}' and userId = u.user_id) as '最早打卡时间' ," +
 $" ( SELECT msg FROM remark WHERE user_id = u.user_id and start_time='{a}' and end_time='{b}' ) AS 备注  " +
 $" from users as u where u.getdata = 1) as  d where  d.打卡状态!='正常'  ";

                MySqlConnection MySqlConnection = new MySqlConnection(SqlHelper.connStr);

                MySqlDataAdapter sqlDataAdapter1 = new MySqlDataAdapter(sql, MySqlConnection);

                MySqlConnection.Open();

                DataSet dss = new DataSet();

                sqlDataAdapter1.Fill(dss, "yuanshijilus");
                GridView_Shijianjieguo.DataSource = dss;

              //  GridView_Shijianjieguo.DataKeyNames= new string[] { "id" };//主键
                GridView_Shijianjieguo.DataBind();
            }
        }

        protected void GridView_Shijianchoucha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void GridView_Shijianjieguo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //int index = Convert.ToInt32(e.CommandArgument);
            //string a = GridView_Shijianjieguo.Rows[index].Cells[1].Text;
            Response.Write("<script>alert(1)</script>");
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("chouchaqingkuang.aspx");
        }

        protected void Button_Shujudaochu_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=抽查（按时间统计）.xls");
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;
            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            GridView_Shijianjieguo.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

     

        protected void GridView_Shijianjieguo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remark")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string a = GridView_Shijianjieguo.Rows[index].Cells[1].Text;
                string b = GridView_Shijianjieguo.Rows[index].Cells[2].Text;
                string c = GridView_Shijianjieguo.Rows[index].Cells[3].Text;

                Response.Redirect($"AddRemark.aspx?start_time={a}&end_time={b}&id={c}&state=2");
            }

        }

      
    }
}
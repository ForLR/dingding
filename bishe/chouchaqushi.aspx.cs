using System;
using System.Data;
using System.Web.UI;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace bishe
{
    /// <summary>
    /// 抽查趋势
    /// </summary>
    public partial class chouchaqushi : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string cmdString = "select DATE_FORMAT(抽查开始时间,'%u')-7 周,count(id) 次数 from choucha group by 周; ";


            string cmdString1 = "SELECT DK.周,sum(未打卡人数量) as 次数 FROM ( select DATE_FORMAT(c.抽查开始时间,'%u')-7 周, (SELECT( (SELECT count(DISTINCT(u.user_id))  from users as u WHERE u.getdata = 1) - ( SELECT count(DISTINCT(d.userId))  from dakaxiangqings as d " +
                "where d.`打卡时间`>= c.`抽查开始时间` and d.`打卡时间`<= c.`抽查结束时间`) ))as 未打卡人数量 from choucha as c ) AS DK GROUP BY DK.周";

           


            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];
                
            MySqlConnection sqlConnection = new MySqlConnection(sqlString);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmdString, sqlConnection);
            MySqlDataAdapter sqlDataAdapter1 = new MySqlDataAdapter(cmdString1, sqlConnection);

            sqlConnection.Open();

            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds, "choucha");
            Chart_Faqichoucha.DataSource = ds;
            Chart_Faqichoucha.Series["Series_Faqichoucha"].XValueMember = "周";
            Chart_Faqichoucha.Series["Series_Faqichoucha"].YValueMembers = "次数";
            Chart_Faqichoucha.ChartAreas["ChartArea_Faqichoucha"].AxisX.Title = "周次";
            Chart_Faqichoucha.ChartAreas["ChartArea_Faqichoucha"].AxisY.Title = "次数";
            Chart_Faqichoucha.ChartAreas["ChartArea_Faqichoucha"].AxisX.TitleAlignment = StringAlignment.Far;
            Chart_Faqichoucha.ChartAreas["ChartArea_Faqichoucha"].AxisY.TitleAlignment = StringAlignment.Far;
            Chart_Faqichoucha.ChartAreas["ChartArea_Faqichoucha"].AxisX.MajorGrid.Enabled = false;
            Chart_Faqichoucha.ChartAreas["ChartArea_Faqichoucha"].AxisY.MajorGrid.Enabled = false;
            Chart_Faqichoucha.DataBind();

            DataSet dss = new DataSet();
            sqlDataAdapter1.Fill(dss, "choucha");
            Chart_Weichoucha.DataSource = dss;
            Chart_Weichoucha.Series["Series_Weichoucha"].XValueMember = "周";
            Chart_Weichoucha.Series["Series_Weichoucha"].YValueMembers = "次数";
            Chart_Weichoucha.ChartAreas["ChartArea_Weichoucha"].AxisX.Title = "周次";
            Chart_Weichoucha.ChartAreas["ChartArea_Weichoucha"].AxisY.Title = "次数";
            Chart_Weichoucha.ChartAreas["ChartArea_Weichoucha"].AxisX.TitleAlignment = StringAlignment.Far;
            Chart_Weichoucha.ChartAreas["ChartArea_Weichoucha"].AxisY.TitleAlignment = StringAlignment.Far;
            Chart_Weichoucha.ChartAreas["ChartArea_Weichoucha"].AxisX.MajorGrid.Enabled = false;
            Chart_Weichoucha.ChartAreas["ChartArea_Weichoucha"].AxisY.MajorGrid.Enabled = false;
            Chart_Weichoucha.DataBind();

            sqlConnection.Close();

        }

        protected void Chart_Faqichoucha_Load(object sender, EventArgs e)
        {

        }

        protected void Chart_Weichoucha_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("chouchaqingkuang.aspx");
        }
    }
}
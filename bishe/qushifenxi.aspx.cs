using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace bishe
{
    /// <summary>
    /// 趋势分析
    /// </summary>
    public partial class qushifenxi : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }

          

            var cmdString = "SELECT DATE_FORMAT(考勤时间,'%u')-7 周 ,count(id) 次数 from ( select any_value(y.id) as id,any_value(y.user_id),any_value(y.`打卡结果`),any_value(y.`考勤日期`) as 考勤日期,any_value(y.`考勤时间`) as 考勤时间  from yuanshijilus  as y " +
                " LEFT join users as u on u.user_id = y.user_id where y.打卡结果 = '正常' " +
                "group by y.考勤日期,y.user_id  HAVING count(y.id) = 4 ) as d GROUP BY 周";


           
            string cmdString1 = "select DATE_FORMAT(`考勤时间`,'%u')-7 周,count(id) 次数  from yuanshijilus  where 打卡结果 = '迟到' group by 周; ";
            string cmdString2 = "select DATE_FORMAT(`开始时间`,'%u')-7 周,count(id) 次数  from qingjias  group by 周 ";

            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection sqlConnection = new MySqlConnection(sqlString);

            MySqlDataAdapter MySqlDataAdapter = new MySqlDataAdapter(cmdString, sqlConnection);
            MySqlDataAdapter MySqlDataAdapter1 = new MySqlDataAdapter(cmdString1, sqlConnection);
            MySqlDataAdapter MySqlDataAdapter2 = new MySqlDataAdapter(cmdString2, sqlConnection);

            sqlConnection.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter.Fill(ds, "yuanshijilu");
            Chart_Zhengchangchuqin.DataSource = ds;
            Chart_Zhengchangchuqin.Series["Series_Zhengchangchuqin"].XValueMember = "周";
            Chart_Zhengchangchuqin.Series["Series_Zhengchangchuqin"].YValueMembers = "次数";
            Chart_Zhengchangchuqin.ChartAreas["ChartArea_Zhengchangchuqin"].AxisX.Title = "周次";
            Chart_Zhengchangchuqin.ChartAreas["ChartArea_Zhengchangchuqin"].AxisY.Title = "次数";
            Chart_Zhengchangchuqin.ChartAreas["ChartArea_Zhengchangchuqin"].AxisX.TitleAlignment = StringAlignment.Far;
            Chart_Zhengchangchuqin.ChartAreas["ChartArea_Zhengchangchuqin"].AxisY.TitleAlignment = StringAlignment.Far;
            Chart_Zhengchangchuqin.ChartAreas["ChartArea_Zhengchangchuqin"].AxisX.MajorGrid.Enabled = false;
            Chart_Zhengchangchuqin.ChartAreas["ChartArea_Zhengchangchuqin"].AxisY.MajorGrid.Enabled = false;
            Chart_Zhengchangchuqin.DataBind();

            DataSet dss = new DataSet();
            MySqlDataAdapter1.Fill(dss, "yuanshijilu");
            Chart_Chidao.DataSource = dss;
            Chart_Chidao.Series["Series_Chidao"].XValueMember = "周";
            Chart_Chidao.Series["Series_Chidao"].YValueMembers = "次数";
            Chart_Chidao.ChartAreas["ChartArea_Chidao"].AxisX.Title = "周次";
            Chart_Chidao.ChartAreas["ChartArea_Chidao"].AxisY.Title = "次数";
            Chart_Chidao.ChartAreas["ChartArea_Chidao"].AxisX.TitleAlignment = StringAlignment.Far;
            Chart_Chidao.ChartAreas["ChartArea_Chidao"].AxisY.TitleAlignment = StringAlignment.Far;
            Chart_Chidao.ChartAreas["ChartArea_Chidao"].AxisX.MajorGrid.Enabled = false;
            Chart_Chidao.ChartAreas["ChartArea_Chidao"].AxisY.MajorGrid.Enabled = false;
            Chart_Chidao.DataBind();

            DataSet dsss = new DataSet();
            MySqlDataAdapter2.Fill(dsss, "qingjia");
            Chart_Qingjia.DataSource = dsss;
            Chart_Qingjia.Series["Series_Qingjia"].XValueMember = "周";
            Chart_Qingjia.Series["Series_Qingjia"].YValueMembers = "次数";
            Chart_Qingjia.ChartAreas["ChartArea_Qingjia"].AxisX.Title = "周次";
            Chart_Qingjia.ChartAreas["ChartArea_Qingjia"].AxisY.Title = "次数";
            Chart_Qingjia.ChartAreas["ChartArea_Qingjia"].AxisX.TitleAlignment = StringAlignment.Far;
            Chart_Qingjia.ChartAreas["ChartArea_Qingjia"].AxisY.TitleAlignment = StringAlignment.Far;
            Chart_Qingjia.ChartAreas["ChartArea_Qingjia"].AxisX.MajorGrid.Enabled = false;
            Chart_Qingjia.ChartAreas["ChartArea_Qingjia"].AxisY.MajorGrid.Enabled = false;
            Chart_Qingjia.DataBind();

            sqlConnection.Close();
        }

        protected void Chart_Zhengchangchuqin_Load(object sender, EventArgs e)
        {

        }

        protected void Chart_Chidao_Load(object sender, EventArgs e)
        {

        }

        protected void Chart_Qingjia_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("kuozhanfenxi.aspx");
        }
    }
}
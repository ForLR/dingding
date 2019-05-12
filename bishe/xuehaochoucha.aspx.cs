using Dal;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace bishe
{
    /// <summary>
    /// 学号抽查
    /// </summary>
    public partial class xuehaochoucha : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void TextBox_Xuehao_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 抽查结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Chouchajieguo_Click(object sender, EventArgs e)
        {
            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection sqlConnection = new MySqlConnection(sqlString);
            sqlConnection.Open();
            //获取根据获取的学号 然后代入sql语句的where条件
            var sql= " SELECT d.抽查开始时间,d.抽查结束时间, CASE  WHEN ( SELECT count( * )  FROM qingjias AS q LEFT join users as u on u.user_id=q.user_id" +
                "  WHERE DATE_FORMAT( q.`开始时间`, '%Y-%m-%d %H:%i:%s' ) <= d.`抽查开始时间` AND DATE_FORMAT( q.`结束时间`, '%Y-%m-%d %H:%i:%s' ) >= d.`抽查结束时间` " +
                $" AND u.pass_word ='{ TextBox_Xuehao.Text}' ) > 0 THEN '请假' else d.打卡时间 END as 打卡时间 ," +
                 $"( SELECT msg FROM remark as r LEFT join users as u on r.user_id=u.user_id " +
                $"WHERE u.pass_word ='{TextBox_Xuehao.Text}' AND start_time = d.抽查开始时间 AND end_time = d.抽查结束时间 ) AS 备注" +
                $" from " +
                "(SELECT 抽查开始时间,抽查结束时间, (SELECT CASE  WHEN  min(打卡时间) is NULL THEN '无打卡' ELSE " +
                "min(打卡时间) END as 打卡时间 FROM dakaxiangqings as d left join users as u  on d.userId = u.user_id " +
                $"WHERE d.打卡时间 >= c.`抽查开始时间` and d.打卡时间 <= c.`抽查结束时间` AND u.pass_word ='{ TextBox_Xuehao.Text}') as 打卡时间" +
              
                $" from choucha as c) as d ";

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sql, sqlConnection);

            DataSet ds = new DataSet();

            if (TextBox_Xuehao.Text != string.Empty)
            {
                sqlDataAdapter.Fill(ds, "yuanshijilus");
                GridView_Xuehaochoucha.DataSource = ds;
                GridView_Xuehaochoucha.DataBind();
            }

            sqlConnection.Close();
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("chouchaqingkuang.aspx");
        }

        protected void Button_Shujudaochu_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=抽查（按学号统计）.xls");
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.Charset = "";
            this.EnableViewState = false;
            StringWriter oStringWriter = new StringWriter();
            HtmlTextWriter oHtmlTextWriter = new HtmlTextWriter(oStringWriter);
            GridView_Xuehaochoucha.RenderControl(oHtmlTextWriter);
            Response.Write(oStringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void GridView_Xuehaochoucha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView_Xuehaochoucha_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remark")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string a = GridView_Xuehaochoucha.Rows[index].Cells[1].Text;
                string b = GridView_Xuehaochoucha.Rows[index].Cells[2].Text;
                string c = TextBox_Xuehao.Text ;
                int state = 1;
                var userid = SqlHelper.ExecuteScalar($"select user_id from users where pass_word='{c}'").ToString();

                Response.Redirect($"AddRemark.aspx?start_time={a}&end_time={b}&id={userid}&state={state}");
            }
        }
    }
}
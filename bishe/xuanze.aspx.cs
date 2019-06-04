using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Dal;
using BLL.Model.dingding;
using System.Linq;
using System.Collections.Generic;
using BLL;

namespace bishe
{
    /// <summary>
    /// 选择
    /// </summary>
    public partial class xuanze : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button_Shujugengxin_Click(object sender, EventArgs e)
        {
            Response.Redirect("shujugengxin.aspx");
        }

        protected void Button_Changguitongji_Click(object sender, EventArgs e)
        {

            var sql = $"select count(id) from yuanshijilus ";
            var any = Convert.ToInt16(SqlHelper.ExecuteScalar(sql));
            if (any == 0)
            {
                Response.Write("<script>alert('请先点击数据更新!')</script>");
            }
            else
            {
                Response.Redirect("changgui.aspx");
            }
        }

        protected void Button_Kuozhanfenxi_Click(object sender, EventArgs e)
        {

            var sql = $"select count(id) from yuanshijilus ";
            var any = Convert.ToInt16(SqlHelper.ExecuteScalar(sql));
            if (any == 0)
            {
                Response.Write("<script>alert('请先点击数据更新!')</script>");
            }
            else
            {
                Response.Redirect("kuozhanfenxi.aspx");
            }
        }


        protected void Button_Chouchaqingkuang_Click(object sender, EventArgs e)
        {
            Response.Redirect("chouchaqingkuang.aspx");
        }

        protected void Button_Zhuxiao_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
         
            Response.Redirect("login.aspx");
        }

        protected void Button_bangdan_Click(object sender, EventArgs e)
        {
            Response.Redirect("pingfenbangdan.aspx");
        }

        protected void Button_tongzhi_Click(object sender, EventArgs e)
        {
            DingHelper dd = new DingHelper();
            int state = 1;
            string text = string.Empty;
            using (MySqlDBContext db = new MySqlDBContext())
            {
                var users = db.user.Where(x => x.getdata == 1).ToList();

                var i = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
                if (i == -1) i = 6;
                var startTime = DateTime.Now.Date.AddDays(-i).ToString("yyyy-MM-dd HH:mm:ss");
                var endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                foreach (var item in users)
                {

                    var where = "";
                    where += $" and y.考勤时间 >= '{ startTime}'";


                    where += $" and y.考勤时间 <='{endTime}'";

                    where += $"  and u.user_id='{item.user_id}'";

                    var qjwhere = "";
                    qjwhere += $" and q.开始时间 >= '{ startTime}'";


                    qjwhere += $" and q.开始时间 <='{endTime}'";

                    qjwhere += $"  and u.user_id='{item.user_id}'";

                    //正常出勤
                    var zcsql = $"SELECT count(*) FROM( SELECT count(1) as c from yuanshijilus  as y " +
             $"left join users as u on u.user_id = y.user_id where  y.打卡结果='正常'  {where} GROUP BY DATE_FORMAT(y.考勤时间,'%Y-%m-%d') HAVING c=4 ) as d";
                    //迟到
                    var cdSql = $"SELECT count(1) from yuanshijilus  as y " +
                $"left join users as u on u.user_id = y.user_id where  y.打卡结果='迟到' {where}";
                    //早退
                    var ztSql = $"SELECT count(1) from yuanshijilus  as y " +
            $"left join users as u on u.user_id = y.user_id where " +
            $" y.打卡结果='早退' {where}";


                    //请假
                    var qjSql = $" SELECT  count(1)  from qingjias as q left join users u " +
               $" on q.user_id = u.user_id where 1=1 {qjwhere}";
                    //缺卡
                    var qkSql = $"select count(1) from ( SELECT any_value(u.user_name) as 名字,any_value(y.考勤时间) as 考勤时间,any_value(y.打卡时间) as 打卡时间," +
                        $" any_value(y.打卡结果) as 打卡结果  from yuanshijilus  as y " +
             $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
             $"as y left join users as u on u.user_id = y.user_id " +
             $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
             $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as d";
                    //旷课
                    var kkSql = "select count(1) from ( SELECT any_value(a.名字), CASE  WHEN any_value(a.时间) > DATE_FORMAT(any_value(a.时间), '%Y-%m-%d 12:00') THEN DATE_FORMAT(any_value(a.时间), '%Y-%m-%d 下午') " +
                "  ELSE DATE_FORMAT(any_value(a.时间), '%Y-%m-%d 上午') END as 旷课时间 from( SELECT  DATE_FORMAT( any_value(y.`考勤时间`), '%Y-%m-%d %H:%i' ) AS 时间," +
                " any_value(u.user_name) AS 名字,CASE WHEN y.`考勤时间` > DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 13:00') THEN DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 18:00') ELSE DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 12:00' ) END AS 日期 from yuanshijilus as y " +
                 $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT DISTINCT y.id FROM qingjias as q  LEFT JOIN yuanshijilus AS y ON q.user_id = y.user_id LEFT JOIN users AS u ON u.user_id = y.user_id where y.打卡结果='未打卡' {where} AND " +
                 $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as a GROUP BY a.名字,a.日期 HAVING count(a.日期) > 1) as d ";

                    var ccsql = "SELECT count(*) from ( SELECT d.抽查开始时间,d.抽查结束时间, CASE  WHEN ( SELECT count( * )  FROM qingjias AS q LEFT join users as u on u.user_id=q.user_id" +
                     "  WHERE DATE_FORMAT( q.`开始时间`, '%Y-%m-%d %H:%i:%s' ) <= d.`抽查开始时间` AND DATE_FORMAT( q.`结束时间`, '%Y-%m-%d %H:%i:%s' ) >= d.`抽查结束时间` " +
                     $" AND u.pass_word ='{item.user_id}' ) > 0 THEN '请假' else d.打卡时间 END as 打卡时间 ," +
                      $"( SELECT msg FROM remark as r LEFT join users as u on r.user_id=u.user_id " +
                     $"WHERE u.pass_word ='{item.user_id}' AND start_time = d.抽查开始时间 AND end_time = d.抽查结束时间 ) AS 备注" +
                     $" from " +
                     "(SELECT 抽查开始时间,抽查结束时间, (SELECT CASE  WHEN  min(打卡时间) is NULL THEN '无打卡' ELSE " +
                     "min(打卡时间) END as 打卡时间 FROM dakaxiangqings as d left join users as u  on d.userId = u.user_id " +
                     $"WHERE d.打卡时间 >= c.`抽查开始时间` and d.打卡时间 <= c.`抽查结束时间` AND u.pass_word ='{ item.user_id}') as 打卡时间" +

                     $" from choucha as c) as d ) as  e where e.`抽查开始时间`>='{startTime}' and e.`抽查结束时间`<='{endTime}' and e.`打卡时间`!=''";

                    var msg = new tongjiModel
                    {
                        msgtype = "oa",
                        oa = new Oa
                        {
                            head = new Head
                            {
                                bgcolor = "FFBBBBBB",
                                text = $"{item.user_name}关于出勤情况"
                            },
                            body = new Body
                            {
                                author = "考勤",
                                content = $"[{startTime}-{endTime}]",
                                title = $"{item.user_name}出勤情况",
                                form = new List<Form>
                            {
                                new Form { key="正常.........",value=$"{SqlHelper.ExecuteScalar(zcsql)}次"},
                                new Form { key="迟到.........",value=$"{SqlHelper.ExecuteScalar(cdSql)}次"},
                                new Form { key="早退.........",value=$"{SqlHelper.ExecuteScalar(ztSql)}次"},
                                new Form { key="请假.........",value=$"{SqlHelper.ExecuteScalar(qjSql)}次"},
                                new Form { key="旷工.........",value=$"{SqlHelper.ExecuteScalar(kkSql)}次"},
                                new Form { key="缺卡.........",value=$"{SqlHelper.ExecuteScalar(qkSql)}次"},
                                 new Form { key="抽查.........",value=$"{SqlHelper.ExecuteScalar(ccsql)}次"}
                            }
                            }
                        }
                    };
                    var response = dd.GetCorpconversation(item.user_id, msg);
                    state = response.errcode;
                    msg = response.errmsg;
                }
                if (state==0)
                {
                    Response.Write("<script>alert('发送完成')</script>");
                }
                else
                {
                    Response.Write($"<script>alert('{text}')</script>");
                }
            }
        }

        protected void Button_user_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserManage.aspx");
        }
    }
}
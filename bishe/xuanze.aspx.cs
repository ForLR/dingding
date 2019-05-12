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
                    var qkSql = $"select count(1) from ( SELECT  u.user_name as 名字,y.考勤时间,y.打卡时间,y.打卡结果  from yuanshijilus  as y " +
             $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
             $"as y left join users as u on u.user_id = y.user_id " +
             $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
             $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as d";
                    //旷课
                    var kkSql = "select count(1) from ( SELECT a.名字, CASE  WHEN a.时间 > DATE_FORMAT(a.时间, '%Y-%m-%d 12:00') THEN DATE_FORMAT(a.时间, '%Y-%m-%d 下午') " +
                "  ELSE DATE_FORMAT(a.时间, '%Y-%m-%d 上午') END as 旷课时间 from( SELECT  DATE_FORMAT( y.`考勤时间`, '%Y-%m-%d %H:%i' ) AS 时间," +
                " u.user_name AS 名字,CASE WHEN y.`考勤时间` > DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 13:00') THEN DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 18:00') ELSE DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 12:00' ) END AS 日期 from yuanshijilus as y " +
                 $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
                 $"as y left join users as u on u.user_id = y.user_id " +
                 $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
                 $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as a GROUP BY a.名字,a.日期 HAVING count(a.日期) > 1) as d ";

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
                                new Form { key="缺卡.........",value=$"{SqlHelper.ExecuteScalar(qkSql)}次"}
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
    }
}
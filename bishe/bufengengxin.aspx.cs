using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using BLL;
using BLL.Model;
using System.Collections.Generic;
using Dal;
using System.Linq;

namespace bishe
{
    /// <summary>
    /// 部分更新
    /// </summary>
    public partial class bufengengxin : Page
    {
        static DingHelper dd = new DingHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
            TextBox_Kaishishijian.Attributes["onclick"] = ClientScript.GetPostBackEventReference(Button_Kaishishijian, null);
            TextBox_Jieshushijian.Attributes["onclick"] = ClientScript.GetPostBackEventReference(Button_Jieshushijian, null);
        }

        protected void Calendar_Kaishishijian_SelectionChanged(object sender, EventArgs e)
        {
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
        //部分更新的原理和全部更新的原理一致  只是获取打卡数据的开始时间是自己设定的
        protected void Button_Queding_Click(object sender, EventArgs e)
        {
            var kaishiTime = Convert.ToDateTime(TextBox_Kaishishijian.Text);
            var jieshuTime = Convert.ToDateTime(TextBox_Jieshushijian.Text + " 23:59:59");

            if ((jieshuTime-kaishiTime).Days>7)
            {
                
                Response.Write("<script>if(confirm('结束时间和开始时间最大范围不能超过7天')){window.location='/bufengengxin.aspx'} else{window.location='/xuanze.aspx'}</script>");
                return;
            }
            
            using (MySqlDBContext db = new MySqlDBContext())
            {
                
                var userList = db.user.Where(x => x.getdata == 1).ToList();
                var maxTime = new DateTime(2019,2,25);
                if (db.yuanshijilu.Any())
                {
                    maxTime = Convert.ToDateTime(db.yuanshijilu.Max(x => x.考勤时间));
                }
               
                if (Convert.ToDateTime(maxTime) >jieshuTime)
                {
                    Response.Write("<script>if(confirm('当前时间段的数据已经更新存在于数据库中,请往后选择时间段更新')){window.location='/bufengengxin.aspx'} else{window.location='/xuanze.aspx'}</script>");
                    return;
                }
                if (maxTime>kaishiTime)
                {
                    kaishiTime = maxTime;
                }
                List<DateTime> dateTimes = new List<DateTime>();
                int days = (jieshuTime - kaishiTime).Days;
                for (int i = 0; i < days; i++)
                {
                    dateTimes.Add(jieshuTime.Date.AddDays(-i));
                }
                var index = dateTimes.Count % 7 == 0 ? dateTimes.Count / 7 : dateTimes.Count / 7 + 1;

                int offset = 0;
                for (int i = 0; i < userList.Count; i++)
                {
                    var user = userList[i];

                    for (int t = 0; t < index; t++)
                    {
                        var times = dateTimes.Skip(t * 7).Take(7).ToList();
                        var data = dd.GetAttendance(user.user_id, times.Min(), times.Max().AddDays(1).AddMilliseconds(-1), offset, 50);
                        for (int x = 0; x < data.recordresult.Count; x++)
                        {
                            var result = data.recordresult[x];
                            var jl = new yuanshijilu()
                            {
                                user_id = result.userId,
                                打卡时间 = StringToDateTime(result.userCheckTime.ToString()).AddHours(8),
                                打卡结果 = ToTimeResult(result.timeResult),
                                考勤时间 = StringToDateTime(result.baseCheckTime.ToString()).AddHours(8),
                                考勤日期 = StringToDateTime(result.workDate.ToString())
                            };
                            db.yuanshijilu.Add(jl);
                        }
                    }
                }
               

                if (db.SaveChanges() > 0)
                {
                   Response.Write("<script>if(confirm('部分更新完成')){window.location='/xuanze.aspx'} else{window.location='/xuanze.aspx'}</script>");
                }
                else
                {
                    Response.Write("<script>if(confirm('暂时没有更新项，是否重新更新')){window.location='/xuanze.aspx'} else{window.location='/ shujugengxin.aspx'}</script>");
                }

               

            }
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("shujugengxin.aspx");
        }

        public static DateTime StringToDateTime(string createTime)
        {
            double timeVal = default(double);
            if (!string.IsNullOrEmpty(createTime))
            {
                timeVal = double.Parse(createTime);
            }
            return DateTime.Parse(DateTime.Now.ToString("1970-01-01       00:00:00")).AddMilliseconds(timeVal);
        }
        /// <summary>
        /// 将时间戳转换为日期类型，并格式化
        /// </summary>
        /// <param name="longDateTime"></param>
        /// <returns></returns>
        public static string LongDateTimeToDateTimeString(string longDateTime)
        {
            //用来格式化long类型时间的,声明的变量
            long unixDate;
            DateTime start;
            DateTime date;
            //ENd

            unixDate = long.Parse(longDateTime);
            start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            date = start.AddMilliseconds(unixDate).ToLocalTime();

            return date.ToString("yyyy-MM-dd HH:mm:ss");

        }

        public static string ToTimeResult(string str)
        {
            var result = string.Empty;
            switch (str)
            {
                case "Normal":
                    result = "正常";
                    break;
                case "Early":
                    result = "早退";
                    break;
                case "Late":
                    result = "迟到";
                    break;
                case "SeriousLate":
                    result = "严重迟到";
                    break;
                case "Absenteeism":
                    result = "旷工迟到";
                    break;
                case "NotSigned":
                    result = "未打卡";
                    break;

                default:
                    break;
            }
            return result;
        }


    }
}
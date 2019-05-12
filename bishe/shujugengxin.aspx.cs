using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Dal;
using System.Collections.Generic;
using System.Linq;
using BLL.Model;
using BLL;
using System.Diagnostics;

namespace bishe
{
    public partial class shujugengxin : Page
    {
        static DingHelper dd = new DingHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
            
            Session["clickShujugengxin"] = true;
        }
        //全部更新
        protected void Button_Quanbugengxin_Click(object sender, EventArgs e)
        {
            using (MySqlDBContext db = new MySqlDBContext())
            {

                db.Database.ExecuteSqlCommand("TRUNCATE TABLE yuanshijilus");
                //获取所有需要打卡人的数据 getdata字段为是否需要获取打卡数据
                var userList = db.user.Where(x => x.getdata == 1).ToList();
                //获取yuanshijilu表里面的最晚一条的数据的时间作为更新打卡数据的起始时间
                var updateTime = db.yuanshijilu.Any() ? Convert.ToDateTime(db.yuanshijilu.Max(x => x.考勤时间)).Date : new DateTime(2019, 2, 25);
                List<DateTime> dateTimes = new List<DateTime>();
                //当前时间的天数与打卡起始时间的天 差数  因为 钉钉的接口一次只能获取七天之内的打卡数据 所有需要分批 分时间段取数据
                int days = (DateTime.Now.Date - updateTime).Days;

                //按时间天数差 循环
                for (int i = 0; i < days; i++)
                {
                    dateTimes.Add(DateTime.Now.Date.AddDays(-i));
                }
                //七个一批 分成多少批
                var index = dateTimes.Count % 7 == 0 ? dateTimes.Count / 7 : dateTimes.Count / 7 + 1;

                int offset = 0;
                var datas = new List<yuanshijilu>();
                //取出每一个用户的所有数据
                var stoptime = new Stopwatch();
                stoptime.Start();
                for (int i = 0; i < userList.Count; i++)
                {
                    var user = userList[i];
                    //每一个用户取多少批
                    for (int t = 0; t < index; t++)
                    {
                        //当前这一批的所有时间
                        var times = dateTimes.Skip(t * 7).Take(7).ToList();
                        //去钉钉取数据
                        var data = dd.GetAttendance(user.user_id, times.Min(), times.Max().AddDays(1).AddMilliseconds(-1), offset, 50);
                        //处理取出来的所有数据
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
                            //插入数据库
                            datas.Add(jl);
                        }
                    }
                }
                stoptime.Stop();
                var chaxuntime = stoptime.ElapsedMilliseconds;
                stoptime.Restart();
                db.BulkInsert(datas);
                try
                {
                    db.SaveChanges();
                    stoptime.Stop();
                    var charutime = stoptime.ElapsedMilliseconds;
                    //更新完成 弹出全部更新完成
                    Response.Write("<script>if(confirm('全部更新完成。查询用时{" + chaxuntime + "}。插入用时{" + charutime + "}')){window.location='/xuanze.aspx'} else{window.location='/xuanze.aspx'}</script>");
                }
                catch (Exception ex)
                {
                 
                    //弹出暂时没有更新项，是否重新更新
                    var redirect = "<script>if(confirm('暂时没有更新项，是否重新更新 '  " +$"或者错误信息{ex.Message}"+")){window.location='/xuanze.aspx'} else " +
"{window.location='/shujugengxin.aspx'}</script>";
                    Response.Write(redirect);
                };
            }
        }

        protected void Button_Bufengengxin_Click(object sender, EventArgs e)
        {
            Response.Redirect("bufengengxin.aspx");
        }

        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("xuanze.aspx");
        }

        /// <summary>
        /// 打卡详情更新 原理和打卡记录相同 只是这个里面的数据是获取所有的打卡记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_xiangqinggengxin_Click(object sender, EventArgs e)
        {
           
            using (MySqlDBContext db = new MySqlDBContext())
            {
                var userList = db.user.Where(x => x.getdata == 1).ToList();

                var updateTime = db.dakaxiangqing.Any() ? Convert.ToDateTime(db.dakaxiangqing.Max(x => x.打卡时间)).Date : new DateTime(2019, 2, 25);

                List<DateTime> dateTimes = new List<DateTime>();
                int days = (DateTime.Now.Date - updateTime).Days;
                for (int i = 0; i < days; i++)
                {
                    dateTimes.Add(DateTime.Now.Date.AddDays(-i));
                }
                var index = dateTimes.Count % 7 == 0 ? dateTimes.Count / 7 : dateTimes.Count / 7 + 1;
               
                for (int i = 0; i < userList.Count; i++)
                {
                    var datas = new List<dakaxiangqings>();
                    var user = userList[i];
                    for (int t = 0; t < index; t++)
                    {
                        var times = dateTimes.Skip(t * 7).Take(7).ToList();
                        var data = dd.GetAttendanceListRecord(user.user_id, times.Min(), times.Max().AddDays(1).AddMilliseconds(-1));
                        for (int d = 0; d < data.recordresult.Count; d++)
                        {
                            var result = data.recordresult[d];
                            var dk = new dakaxiangqings
                            {
                                userId = result.userId,
                                审批id = result.procInstId,
                                工作日 = StringToDateTime(result.workDate.ToString()).AddHours(8),
                                打卡时间 = StringToDateTime(result.userCheckTime.ToString()).AddHours(8)

                            };
                            if (result.baseCheckTime == null)
                            {
                                dk.msg = result.invalidRecordMsg;
                            }
                            else
                            {
                                dk.基准时间 = StringToDateTime(result.baseCheckTime.ToString()).AddHours(8);
                            }
                            db.dakaxiangqing.Add(dk);
                        }
                      
                    }
                }
            
                if (db.SaveChanges() > 0)
                {
                    Response.Write("<script>if(confirm('全部更新完成')){window.location='/xuanze.aspx'} else{window.location='/xuanze.aspx'}</script>");
                }
                else
                {
                    var redirect = "<script>if(confirm('暂时没有更新项，是否重新更新 ')){window.location='/xuanze.aspx'} else " +
"{window.location='/shujugengxin.aspx'}</script>";
                    Response.Write(redirect);
                }


            }

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

        protected void Button_qingjia_Click(object sender, EventArgs e)
        {
           
            using (MySqlDBContext db = new MySqlDBContext())
            {
                //删除所有请假数据  重新全部添加
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE qingjias");

                var userList = db.user.Where(x => x.getdata.Value == 1).Select(x => x.user_id).ToList();
                foreach (var item in userList)
                {
                    List<string> ids = GetIdList(item);//获取具体用户的所有审批id
                    foreach (var id in ids)
                    {
                        var data = dd.GetProcessInstance(id);
                        var operation_records = data.process_instance.operation_records.Count;
                        //审批通过
                        if (data.process_instance.result == "agree")
                        {
                            var qjData = JsonHelper.DeserializeJsonToObject<dynamic>(Convert.ToString(data.process_instance.form_component_values[0].value));
                            string startTime = Convert.ToString(qjData[0]);
                            if (startTime.Contains("上午"))
                            {
                                startTime = startTime.Replace("上午", " 08:30:00");
                            }
                            else if (startTime.Contains("下午"))
                            {
                                startTime = startTime.Replace("下午", " 17:00:00");
                            }
                            string endTime = Convert.ToString(qjData[1]);
                            if (endTime.Contains("上午"))
                            {
                                endTime = endTime.Replace("上午", " 08:30:00");
                            }
                            else if (endTime.Contains("下午"))
                            {
                                endTime = endTime.Replace("下午", " 17:00:00");
                            }
                            qingjia qj = new qingjia
                            {
                                user_id = item,
                                开始时间 = startTime,
                                结束时间 = endTime,
                                请假类型 = Convert.ToString(qjData[4])
                            };
                            db.qingjia.Add(qj);
                        }
                    }
                }

                if (db.SaveChanges()>0)
                {
                    Response.Write("<script>if(confirm('请假数据更新完成')){window.location='/xuanze.aspx'} else{window.location='/xuanze.aspx'}</script>");
                }
                else
                {
                    var redirect = "<script>if(confirm('暂时没有更新项，是否重新更新 ')){window.location='/xuanze.aspx'} else " +
"{window.location='/shujugengxin.aspx'}</script>";
                    Response.Write(redirect);
                }
            }
        }

     


        /// <summary>
        /// 取得所有审批id
        /// </summary>
        /// <returns></returns>
        public static List<string> GetIdList(string userId = "0540636631658", int offset = 1)
        {

            var startTime = dd.GetTimeStamp(new DateTime(2019, 2, 25).ToUniversalTime());
            var endTime = dd.GetTimeStamp(DateTime.Now.ToUniversalTime()); ;
            //var sta = LongDateTimeToDateTimeString(startTime.ToString());
            var data = dd.GetProcessInstanceIds(userId, startTime, endTime, offset);
            var count = data.result.list.Count;

            List<string> result = new List<string>();
            for (int i = 0; i < count; i++)
            {
                var id = data.result.list[i];
                result.Add(Convert.ToString(id));
            }
            if (data.result.next_cursor > 1)
            {
                result = result.Union(GetIdList(userId, data.result.next_cursor)).ToList();
            }
            return result;
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
using BLL;
using BLL.Model;
using BLL.Model.dingding;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class Program
    {
        static DingHelper dd = new DingHelper();
        static void Main(string[] args)
        {
            #region 注释
            //using (MySqlDBContext db = new MySqlDBContext())
            //{
            //    var users= db.user.Where(x => x.getdata == 1).ToList();

            //    var i = DateTime.Now.DayOfWeek - DayOfWeek.Monday;
            //    if (i == -1) i = 6;
            //    var startTime = DateTime.Now.Date.AddDays(-i).ToString("yyyy-MM-dd HH:mm:ss");
            //    var endTime = DateTime.Now.AddDays(1).AddMilliseconds(-1).ToString("yyyy-MM-dd HH:mm:ss");
            //    foreach (var item in users)
            //    {

            //        var where = "";
            //            where += $" and y.考勤时间 >= '{ startTime}'";


            //            where += $" and y.考勤时间 <='{endTime}'";

            //            where += $"  and u.user_id='0540636631658'";

            //        var qjwhere = "";
            //        qjwhere += $" and q.开始时间 >= '{ startTime}'";


            //        qjwhere += $" and q.开始时间 <='{endTime}'";

            //        qjwhere += $"  and u.user_id='{item}'";

            //        //正常出勤
            //        var zcsql = $"SELECT count(*) FROM( SELECT count(1) as c from yuanshijilus  as y " +
            // $"left join users as u on u.user_id = y.user_id where  y.打卡结果='正常'  {where} GROUP BY DATE_FORMAT(y.考勤时间,'%Y-%m-%d') HAVING c=4 ) as d";
            //        //迟到
            //        var cdSql = $"SELECT count(1) from yuanshijilus  as y " +
            //    $"left join users as u on u.user_id = y.user_id where  y.打卡结果='迟到' {where}";
            //        //早退
            //        var ztSql = $"SELECT count(1) from yuanshijilus  as y " +
            //$"left join users as u on u.user_id = y.user_id where " +
            //$" y.打卡结果='早退' {where}";


            //        //请假
            //        var qjSql = $" SELECT  count(1)  from qingjias as q left join users u " +
            //   $" on q.user_id = u.user_id where 1=1 {qjwhere}";
            //        //缺卡
            //        var qkSql = $"select count(1) from ( SELECT  u.user_name as 名字,y.考勤时间,y.打卡时间,y.打卡结果  from yuanshijilus  as y " +
            // $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
            // $"as y left join users as u on u.user_id = y.user_id " +
            // $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
            // $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as d";
            //        //旷课
            //        var kkSql = "select count(1) from ( SELECT a.名字, CASE  WHEN a.时间 > DATE_FORMAT(a.时间, '%Y-%m-%d 12:00') THEN DATE_FORMAT(a.时间, '%Y-%m-%d 下午') " +
            //    "  ELSE DATE_FORMAT(a.时间, '%Y-%m-%d 上午') END as 旷课时间 from( SELECT  DATE_FORMAT( y.`考勤时间`, '%Y-%m-%d %H:%i' ) AS 时间," +
            //    " u.user_name AS 名字,CASE WHEN y.`考勤时间` > DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 13:00') THEN DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 18:00') ELSE DATE_FORMAT(y.`考勤时间`, '%Y-%m-%d 12:00' ) END AS 日期 from yuanshijilus as y " +
            //     $"left join users as u on u.user_id = y.user_id where y.打卡结果='未打卡' {where}  AND  y.id not in (SELECT  y.id from yuanshijilus  " +
            //     $"as y left join users as u on u.user_id = y.user_id " +
            //     $"LEFT join qingjias as q on  u.user_id=y.user_id where y.打卡结果='未打卡' {where} AND " +
            //     $" y.`打卡时间`  BETWEEN q.`开始时间` and q.`结束时间`) " + $" GROUP BY y.id) as a GROUP BY a.名字,a.日期 HAVING count(a.日期) > 1) as d ";

            //        var msg = new tongjiModel
            //        {
            //            msgtype = "oa",
            //            oa = new Oa
            //            {
            //                head = new Head
            //                {
            //                    bgcolor = "FFBBBBBB",
            //                    text = $"{item.user_name}关于出勤情况"
            //                },
            //                body = new Body
            //                {
            //                    author = "考勤",
            //                    content = $"[{startTime}-{endTime}]",
            //                    title =$"{item.user_name}出勤情况",
            //                    form = new List<Form>
            //                {
            //                    new Form { key="正常.........",value=$"{SqlHelper.ExecuteScalar(zcsql)}次"},
            //                    new Form { key="迟到.........",value=$"{SqlHelper.ExecuteScalar(cdSql)}次"},
            //                    new Form { key="早退.........",value=$"{SqlHelper.ExecuteScalar(ztSql)}次"},
            //                    new Form { key="请假.........",value=$"{SqlHelper.ExecuteScalar(qjSql)}次"},
            //                    new Form { key="旷工.........",value=$"{SqlHelper.ExecuteScalar(kkSql)}次"},
            //                    new Form { key="缺卡.........",value=$"{SqlHelper.ExecuteScalar(qkSql)}次"}
            //                }
            //                }
            //            }
            //        };

            //        var response = dd.GetCorpconversation("0540636631658", msg);

            //    }

            //}
            #endregion
            UpdateData();
            Console.WriteLine();
            Console.ReadKey();
        }
       
        /// <summary>
        /// 更新用户的班级
        /// </summary>
        public static void UpdateBanji()
        {
            using (MySqlDBContext db = new MySqlDBContext())
            {
                var ids = dd.GetUserIds("13972515");
                var userList = db.user.Where(x => x.getdata == 1).ToList();
                foreach (var item in ids)
                {
                    var user = userList.FirstOrDefault(x => x.user_id == Convert.ToString(item));
                    if (user != null)
                    {
                        user.class_grade = "201521";
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    }
           
                }
                db.SaveChanges();
            }
        }
        /// <summary>
        ///添加用户信息到数据库
        /// </summary>
        public void AddUser()
        {
            using (MySqlDBContext db = new MySqlDBContext())
            {
                DingHelper dd = new DingHelper();
                var users = dd.GetUserIds("14011045");
                var userList = new List<User>();
                for (int i = 0; i < users.Count; i++)
                {
                    var userid = users[i];
                    var user = dd.GetUserDetail(Convert.ToString(userid));
                    userList.Add(new User
                    {
                        mobile = user.mobile,
                        pass_word = user.mobile,
                        role = "教工: " + user.position,
                        user_id = user.userid,
                        user_name = user.name
                    });
                }
                db.user.AddRange(userList);
                db.SaveChanges();


            }
        }
        //更新请假数据
        public void UpdateQingjia()
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

                if (db.SaveChanges() > 0) { Console.WriteLine("请假数据更新完成"); };
            }
        }
        //更新打卡记录
        public static void UpdateData()
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
                Console.WriteLine($"查询用时:{chaxuntime}ms");
                //stoptime.Restart();

                //                db.BulkInsert(datas);
                //                try
                //                {
                //                    db.SaveChanges();
                //                    stoptime.Stop();
                //                    var charutime = stoptime.ElapsedMilliseconds;
                //                    //更新完成 弹出全部更新完成
                //                    Response.Write("<script>if(confirm('全部更新完成。查询用时{" + chaxuntime + "}。插入用时{" + charutime + "}')){window.location='/xuanze.aspx'} else{window.location='/xuanze.aspx'}</script>");
                //                }
                //                catch (Exception ex)
                //                {

                //                    //弹出暂时没有更新项，是否重新更新
                //                    var redirect = "<script>if(confirm('暂时没有更新项，是否重新更新 '  " + $"或者错误信息{ex.Message}" + ")){window.location='/xuanze.aspx'} else " +
                //"{window.location='/shujugengxin.aspx'}</script>";
                //                    Response.Write(redirect);
                //                };
            }
        }
        /// <summary>
        /// 更新打卡详情
        /// </summary>
        public void UpdateDataRecode()
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
            if (db.SaveChanges() > 0) { Console.WriteLine("原始数据更新完成"); };


        }
    }
        // 时间戳(毫秒值)String转换为DateTime类型转换
        public DateTime TicksToDate(string time)
        {
            return new DateTime((Convert.ToInt64(time) * 10000) + 621355968000000000);
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

        /// <summary>
        /// 获取时间戳  13位
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long GetTimeStamp(DateTime date)
        {
            TimeSpan ts = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * 1000);
        }

        public static bool ContainProperty(object obj, string propertyName)
        {
            if (obj != null && !string.IsNullOrWhiteSpace(propertyName))
            {
                var prop = obj.GetType().GetProperties();
                foreach (var item in prop)
                {
                    Console.WriteLine(item.Name);
                }
                var property = obj.GetType().GetProperty(propertyName);
                return property != null;
            }
            return false;
        }

        /// <summary>
        /// 取得所有审批id
        /// </summary>
        /// <returns></returns>
        public static List<string> GetIdList(string userId = "0540636631658", int offset = 1)
        {
            var startTime = GetTimeStamp(new DateTime(2019, 2, 25).ToUniversalTime());
            var endTime = GetTimeStamp(DateTime.Now.ToUniversalTime()); ;
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
            }
        }

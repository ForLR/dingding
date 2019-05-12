using BLL.Model.dingding;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    public class DingHelper
    {
        private  string _accessToken = string.Empty;
        
        public DingHelper()
        {

            if (string.IsNullOrWhiteSpace(_accessToken))
            {
                var obj = HttpHelper.HttpGet("https://oapi.dingtalk.com/gettoken?appkey=dingklt9rga2qkadjq8y&appsecret=arrM5lbKTHxFT6Kx-xohhqvF9Wrbt5jEASA97Up_U42Z4H9TLbVEehcoeeWsHUzU");
                _accessToken = JsonHelper.DeserializeJsonToObject<dynamic>(obj).access_token;
            }
        }
        /// <summary>
        /// 部门id获取所有用户的id
        /// </summary>
        /// <param name="deptId"></param>
        public  dynamic GetUserIds(string deptId)
        {

            var response = HttpHelper.HttpGet($"https://oapi.dingtalk.com/user/getDeptMember?access_token={_accessToken}&deptId={deptId}");
            return JsonHelper.DeserializeJsonToObject<dynamic>(response).userIds;
        }
        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public  dynamic GetUserDetail(string userId)
        {
            var response = HttpHelper.HttpGet($"https://oapi.dingtalk.com/user/get?access_token={_accessToken}&userid={userId}");
            return JsonHelper.DeserializeJsonToObject<dynamic>(response);
        }
        /// <summary>
        /// 获取打卡结果
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public  Attendance GetAttendance(string userIdList, DateTime workDateFrom, DateTime workDateTo, int offset, int limit)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var ids = new List<string>();
            ids.Add(userIdList);
            dic.Add("userIdList", ids);
            dic.Add("workDateFrom", workDateFrom.ToString("yyyy-MM-dd HH:mm:ss"));
            dic.Add("workDateTo", workDateTo.ToString("yyyy-MM-dd HH:mm:ss"));
            dic.Add("offset", offset.ToString());
            dic.Add("limit", limit.ToString());

            var response = HttpHelper.Post($"https://oapi.dingtalk.com/attendance/list?access_token={_accessToken}", JsonHelper.SerializeObject(dic));
             
            return JsonHelper.DeserializeJsonToObject<Attendance>(response.ToString());
        }

        /// <summary>
        /// 获取打卡详情
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public dynamic GetAttendanceListRecord(string userIdList, DateTime checkDateFrom, DateTime checkDateTo)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var ids = new List<string>();
            ids.Add(userIdList);
            dic.Add("userIds", ids);
            dic.Add("isI18n", "false");
            dic.Add("checkDateFrom", checkDateFrom.ToString("yyyy-MM-dd HH:mm:ss"));
            dic.Add("checkDateTo", checkDateTo.ToString("yyyy-MM-dd HH:mm:ss"));
        
            var response = HttpHelper.Post($"https://oapi.dingtalk.com/attendance/listRecord?access_token={_accessToken}", JsonHelper.SerializeObject(dic));
            return JsonHelper.DeserializeJsonToObject<dynamic>(response.ToString());
        }
        /// <summary>
        /// 查询请假状态
        /// </summary>
        /// <param name="userIdList"></param>
        /// <param name="start_time">开始时间 ，UNIX时间戳，支持最多180天的查询</param>
        /// <param name="end_time"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public  dynamic Getleavestatus(string userid_list, long start_time,long end_time,int offset,int size)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("userid_list", userid_list);
            dic.Add("start_time", start_time);
            dic.Add("end_time", end_time);
            dic.Add("offset", offset);
            dic.Add("size", size);
            var response = HttpHelper.Post($"https://oapi.dingtalk.com/topapi/attendance/getleavestatus?access_token={_accessToken}", JsonHelper.SerializeObject(dic));
            return JsonHelper.DeserializeJsonToObject<dynamic>(response.ToString());
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <returns></returns>
        public dynamic SendChat(string cid,string content)
        { 
            Dictionary<string, string> dic = new Dictionary<string, string>();
            var msg = new TextMsg();
            msg.msgtype = "text";
            msg.text = new Text();
            msg.text.content = content;
            dic.Add("sender", "0540636631658");
            dic.Add("cid", cid);
            //dic.Add("chatid", "0b261630e9743b229cb12861dd550185");
            dic.Add("msg", JsonHelper.SerializeObject(msg));
            var response = HttpHelper.Post($"https://oapi.dingtalk.com/message/send_to_conversation?access_token={_accessToken}", JsonHelper.SerializeObject(dic));
            return JsonHelper.DeserializeJsonToObject<dynamic>(response.ToString());
        }

        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <returns></returns>
        public string GetTicket()
        {
            var response = HttpHelper.HttpGet($"https://oapi.dingtalk.com/get_jsapi_ticket?access_token={_accessToken}");
            return JsonHelper.DeserializeJsonToObject<dynamic>(response.ToString()).ticket;
        }

        /// <summary>
        /// 批量获取审批实例id
        /// </summary>
        /// <param name="userid_list"></param>
        /// <param name="start_time"></param>
        /// <param name="end_time"></param>
        /// <param name="cursor"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public ProcessInstanceResult GetProcessInstanceIds(string userid_list, long start_time, long end_time, int cursor, int size=10)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("process_code", "PROC-84D8542B-C0D8-4476-9087-A68322D2F8E6");
            dic.Add("userid_list", userid_list);
            dic.Add("start_time", start_time);
            dic.Add("end_time", end_time);
            dic.Add("cursor", cursor);
            dic.Add("size", size);
            var response = HttpHelper.Post($"https://oapi.dingtalk.com/topapi/processinstance/listids?access_token={_accessToken}", JsonHelper.SerializeObject(dic));
            return JsonHelper.DeserializeJsonToObject<ProcessInstanceResult>(response.ToString());
        }
        /// <summary>
        /// 获取审批实例
        /// </summary>
        /// <param name="process_instance_id"></param>
        /// <returns></returns>
        public dynamic GetProcessInstance(string process_instance_id)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("process_instance_id", process_instance_id);
           
            var response = HttpHelper.Post($"https://oapi.dingtalk.com/topapi/processinstance/get?access_token={_accessToken}", JsonHelper.SerializeObject(dic));
            return JsonHelper.DeserializeJsonToObject<dynamic>(response.ToString());
        }

        /// <summary>
        /// 发送工作消息
        /// </summary>
        /// <returns></returns>
        public dynamic GetCorpconversation(string userId, tongjiModel msg)
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("agent_id", "248921930");
            dic.Add("userid_list", userId);
            dic.Add("msg", msg);
            var response = HttpHelper.Post($"https://oapi.dingtalk.com/topapi/message/corpconversation/asyncsend_v2?access_token={_accessToken}", JsonHelper.SerializeObject(dic));
            return JsonHelper.DeserializeJsonToObject<dynamic>(response.ToString());
        }

        /// <summary>
        /// 生成js签名
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="nonceStr"></param>
        /// <param name="timeStamp"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public  string GetSign(long time, string url)
        {

            string plain = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", GetTicket(), "dingding123", time, url);

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plain);
                byte[] digest = SHA1.Create().ComputeHash(bytes);
                string digestBytesString = BitConverter.ToString(digest).Replace("-", "");
                return digestBytesString.ToLower();
            }
            catch (Exception e)
            {
                throw;
            }
        }
        /// <summary>
        /// 获取时间戳  13位
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public  long GetTimeStamp(DateTime date)
        {
            TimeSpan ts = date - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * 1000);
        }

    }
}

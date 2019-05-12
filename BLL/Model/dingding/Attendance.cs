using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model.dingding
{
    /// <summary>
    /// 打卡结果
    /// </summary>
    public class Attendance
    {
        public int errcode { get; set; }
        public  string errmsg { get; set; }
        public bool hasMore { get; set; }
        public List<AttendanceResult> recordresult { get; set; }



    }
    public class AttendanceResult
    {
        /// <summary>
        /// 计算迟到和早退，基准时间
        /// </summary>
        public long baseCheckTime { get; set; }
        /// <summary>
        /// 数据来源
        ///ATM：考勤机;
        /// BEACON：IBeacon;
        ///DING_ATM：钉钉考勤机;
        ///USER：用户打卡;
        ///BOSS：老板改签;
        ///APPROVE：审批系统;
        ///SYSTEM：考勤系统;
        ///AUTO_CHECK：自动打卡
        /// </summary>
        public string checkType { get; set; }
        public string corpId { get; set; }
        public long groupId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string locationResult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long planId { get; set; }
        /// <summary>
        /// Normal：正常;
        /// Early：早退;
        /// Late：迟到;
        ///SeriousLate：严重迟到；
        ///Absenteeism：旷工迟到；
        ///NotSigned：未打卡
        /// </summary>
        public string timeResult { get; set; }
        /// <summary>
        /// 实际打卡时间,  用户打卡时间的毫秒数
        /// </summary>
        public string userCheckTime { get; set; }
        public string userId { get; set; }
        /// <summary>
        /// 工作日
        /// </summary>
        public long workDate { get; set; }
        public string procInstId { get; set; }
    }

}

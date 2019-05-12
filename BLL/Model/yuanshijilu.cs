using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class yuanshijilu
    {
        public int id { get; set; }
        public string user_id { get; set; }
        public DateTime 考勤日期 { get; set; }
        public DateTime 考勤时间 { get; set; }
        public DateTime 打卡时间 { get; set; }
        public string 打卡结果 { get; set; }
       
    }
}

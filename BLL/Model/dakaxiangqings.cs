using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class dakaxiangqings
    {
        public DateTime 打卡时间 { get; set; }
        public int id { get; set; }
        public DateTime 工作日 { get; set; }
        public string userId { get; set; }
        public string 审批id { get; set; }
        public DateTime 基准时间 { get; set; }
        public  string msg { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model.dingding
{
    public class ProcessInstanceResult
    {
        public result result { get; set; }
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
    public class result
    {
        public List<string> list { get; set; }
        public int next_cursor { get; set; }
    }
}

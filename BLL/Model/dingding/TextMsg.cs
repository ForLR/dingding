using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model.dingding
{
    public class TextMsg
    {
        public string msgtype { get; set; }
        public Text text { get; set; }
    }
    public class Text
    {
        public string content { get; set; }
    }
}

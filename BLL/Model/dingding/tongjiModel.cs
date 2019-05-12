using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model.dingding
{
    public class tongjiModel
    {
        public string msgtype { get; set; }
        public Oa oa { get; set; }
    }
    public class Oa
    {
        public Head head { get; set; }
        public Body body { get; set; }
       
    }
    public class Head
    {
        public string bgcolor { get; set; }
        public string text { get; set; }
    }
    public class Body
    {
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public List<Form> form { get; set; }
    }
    public class Form
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}

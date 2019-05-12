using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class User
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string role { get; set; }
        public string pass_word { get; set; }
        public string mobile { get; set; }
        public string user_id { get; set; }
        public int? getdata { get; set; }
        public string class_grade { get;set;}
    }
}

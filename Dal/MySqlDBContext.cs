using BLL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class MySqlDBContext:DbContext
    {
        public MySqlDBContext():base(GetConnection(),true)
        {

        }
        public DbSet<choucha> chouchas { get; set; }
        public DbSet<User> user { get; set; }
        public DbSet<yuanshijilu> yuanshijilu { get; set; }
        public DbSet<qingjia> qingjia { get; set; }
        public DbSet<department> department { get; set; }

        public DbSet<dakaxiangqings> dakaxiangqing { get; set; }
        public static DbConnection GetConnection()
        {
            var str = ConfigurationManager.ConnectionStrings["MasterDatabase"];
          
            var conn = DbProviderFactories.GetFactory(str.ProviderName).CreateConnection();
           
            conn.ConnectionString = str.ConnectionString;
            return conn;
        }
    }
}

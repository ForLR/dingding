using System;
using System.Data;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using Dal;
using BLL;
using System.Collections.Generic;
using BLL.Model;

namespace bishe
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 如果未经过登录界面登录而直接输入此页面地址，返回登录页面
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
         
            string cmdString = "SELECT  departmentId as 部门id, name as 部门名字  FROM departments ORDER BY id;";

            string sqlString = ConfigurationManager.AppSettings["ConnectionString"];

            MySqlConnection MySqlConnection = new MySqlConnection(sqlString);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmdString, MySqlConnection);

            MySqlConnection.Open();

            DataSet ds = new DataSet();
            sqlDataAdapter.Fill(ds, "choucha");
            GridView1.DataSource = ds;
            GridView1.DataBind();

            MySqlConnection.Close();
           
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "SELECT")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                NameValue.Text = GridView1.Rows[index].Cells[2].Text;
                Idvalue.Text = GridView1.Rows[index].Cells[1].Text;
            }
        }


        protected void Button_Fanhui_Click(object sender, EventArgs e)
        {
            Response.Redirect("xuanze.aspx");
        }

        protected void Button_student_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameValue.Text)|| string.IsNullOrWhiteSpace(Idvalue.Text))
            {
                Response.Write("<script>alert('请先选择操作的对象')</script>");
                return;
            }
            using (MySqlDBContext db = new MySqlDBContext())
            {
                DingHelper dd = new DingHelper();
                var users = dd.GetUserIds(Idvalue.Text);
                if (users==null)
                {
                    Response.Write("<script>alert('部门下不存在数据')</script>");
                    return;
                }
                var sql = $"DELETE from users where user_id in(select user_id from(SELECT  * from  users where class_grade = '{NameValue.Text}')t)";
                db.Database.ExecuteSqlCommand(sql);
                var userList = new List<User>();
                for (int i = 0; i < users.Count; i++)
                {
                    var userid = users[i];
                    var user = dd.GetUserDetail(Convert.ToString(userid));
                    userList.Add(new User
                    {
                        mobile = user.mobile,
                        pass_word = user.mobile,
                        role = user.position,
                        user_id = user.userid,
                        user_name = user.name,
                        class_grade = NameValue.Text,
                        getdata = 1

                    });
                }
                db.user.AddRange(userList);
                if ( db.SaveChanges()>0)
                {
                    Response.Write("<script>alert('部门下学生数据更新完成')</script>");
                }
                else
                {
                    Response.Write("<script>alert('暂无更新项')</script>");
                }
               
            }
        }

        protected void Button_teacher_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameValue.Text) || string.IsNullOrWhiteSpace(Idvalue.Text))
            {
                Response.Write("<script>alert('请先选择操作的对象')</script>");
                return;
            }
            using (MySqlDBContext db = new MySqlDBContext())
            {
                DingHelper dd = new DingHelper();
                var users = dd.GetUserIds(Idvalue.Text);
                if (users == null)
                {
                    Response.Write("<script>alert('部门下不存在数据')</script>");
                    return;
                }
                var sql = $"DELETE from users where user_id in(select user_id from(SELECT  * from  users where class_grade = '{NameValue.Text}')t)";
                db.Database.ExecuteSqlCommand(sql);
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
                        user_name = user.name,
                        class_grade= NameValue.Text,
                        getdata=0
                        
                    });
                }
                db.user.AddRange(userList);
                if (db.SaveChanges() > 0)
                {
                    Response.Write("<script>alert('部门下教工数据更新完成')</script>");
                }
                else
                {
                    Response.Write("<script>alert('暂无更新项')</script>");
                }
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button_delete_Click(object sender, EventArgs e)
        {
            using (MySqlDBContext db = new MySqlDBContext())
            {
                var sql = $"DELETE from users where user_id in(select user_id from(SELECT  * from  users where class_grade = '{NameValue.Text}')t)";
               
                if (db.Database.ExecuteSqlCommand(sql) > 0)
                {
                    Response.Write("<script>alert('部门下用户删除完成')</script>");
                }
                else
                {
                    Response.Write("<script>alert('部门下用户暂无删除项')</script>");
                }
            }
             
        }
    }
}
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bishe
{
    public partial class AddRemark : System.Web.UI.Page
    {
        string start_time = string.Empty;
        string end_time = string.Empty;
        string id = string.Empty;
        int state = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("login.aspx");
            }
            start_time = Request.QueryString["start_time"];
            end_time = Request.QueryString["end_time"];
            id = Request.QueryString["id"];
            state=Convert.ToInt32(Request.QueryString["state"]);
        }
        protected void TextBox_User_TextChanged(object sender, EventArgs e)
        {

        }
        protected void Button_Queding_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(start_time)|| string.IsNullOrWhiteSpace(end_time) || string.IsNullOrWhiteSpace(id))
            {
                Response.Write("<script>alert('请重新登陆再试')</script>");
            }
            var text = TextBox_User.Text;
            var where = $"user_id = '{id}' and start_time='{start_time}' and end_time='{end_time}' ";
            var sql = $"SELECT count(id) FROM remark WHERE  {where}";
            var any = SqlHelper.ExecuteScalar(sql).ToString();
          
            if (Convert.ToInt16(any) == 0)
            {
                var insert = $"INSERT INTO  `remark`(`user_id`, `start_time`,  `msg`, `end_time`) VALUES ('{id}', '{start_time}','{text}','{end_time}');";
                var insertOk = SqlHelper.ExecuteNonQuery(insert).ToString();
                if (Convert.ToInt16(insertOk) == 0)
                {
                    Response.Write("<script>alert(请稍后再试)</script>");
                    return;
                }
                if (state==1)
                {
                    Response.Redirect("xuehaochoucha.aspx");
                }
                else
                {
                    Response.Redirect("shijianchoucha.aspx");
                }
                return;
            }
           var  update = $"update remark set msg= '{text}' where {where}";
            var updateOk = SqlHelper.ExecuteNonQuery(update).ToString();
            if (Convert.ToInt16(updateOk) == 0)
            {
                Response.Write("<script>alert(请稍后再试)</script>");
                return;
            }

            if (state == 1)
            {
                Response.Redirect("xuehaochoucha.aspx");
            }
            else
            {
                Response.Redirect("shijianchoucha.aspx");
            }
            return;
        }
    }
}
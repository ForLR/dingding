using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL
{
    class CookieHelper
    {
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="userinfo"></param>
        public static void SetCookie(string cookieName,string value)
        {
        
            HttpCookie cookie = new HttpCookie(cookieName, value);
            cookie.Expires = DateTime.Now.AddSeconds(7200);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 获取指定Cookie值
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        /// <returns></returns>
        public static string GetCookieValue(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            string str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }
    }
}

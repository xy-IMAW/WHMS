using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WHMS
{
    /// <summary>
    /// HTTP请求工具类
    /// </summary>
    public class Http
    {
        /// <summary>
        /// 获取页面html
        /// </summary>
        public static void GetPageHtml(string url)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
            request.Proxy = null;

            request.Host = "sso.jwc.whut.edu.cn";
            request.KeepAlive = true;
      
            request.Accept = "text/html,application/xhtml+xm…plication/xml;q=0.9,*/*;q=0.8";
            request.ContentType = "application/x-www-form-urlencoded";

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            request.AllowAutoRedirect= false;
        }

        /// <summary>
        /// Http下载文件
        /// </summary>
        public static void HttpDownloadFile(string url)
        {
            ///string accept = "text/html,application/xhtml+xm…plication/xml;q=0.9,*/*;q=0.8";
            ///string contenttype = "application/x-www-form-urlencoded";
           /// HttpRequestHeader.Accept.Equals(accept);
           /// HttpRequestHeader.ContentType.Equals(contenttype);
           
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)";
            request.Proxy = null;
         
            request.Host = "sso.jwc.whut.edu.cn";
            request.KeepAlive = true;

           
            request.Accept = "text/html,application/xhtml+xm…plication/xml;q=0.9,*/*;q=0.8";
            request.ContentType= "application/x-www-form-urlencoded";
         


            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
           
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
        }
    }
 
 
}
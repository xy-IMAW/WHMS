using System;
using System.Data;
using FineUI;

namespace WHMS.Infor_Data
{
    public partial class StuImport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Common.checklogin("../login.aspx");
        }
  

        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            string FN="Student";//模板名
            NPOI_EXCEL.DownLoad(FN);
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            //上传并更新班级
            NPOI_EXCEL.upload(fileupload, GridView1);

        }
    }
}
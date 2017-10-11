using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace WHMS.Infor_Data
{
    public partial class Stu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.checklogin("../login.aspx");

            }
        }

        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            string FN = "Student";//模板名
            NPOI_EXCEL.DownLoad(FN);
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            DataControl.UpdataStudent(GridView1);
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            //上传并更新班级
            NPOI_EXCEL.upload(fileupload, GridView1);
        }
    }
}
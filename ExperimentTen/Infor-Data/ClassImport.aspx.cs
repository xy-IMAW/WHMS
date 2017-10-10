using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WHMS.Infor_Data
{
    public partial class ClassImport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            //上传并更新班级
            NPOI_EXCEL.upload(fileupload, GridView1);
          
        }
    }
}
using System;
using System.Data;
using FineUI;

namespace WHMS
{
    public partial class ShowEditDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

     

   

        protected void Button1_Click1(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(FileUpload,GridView1);
         //   NPOI_EXCEL.upload(FileUpload, gridview);
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(FileUpload,GridView1);
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(FileUpload,Grid1);
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(FileUpload,gridview);
        }
    }
}
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
        protected void btnImport_Click(object sender, EventArgs e)
        {
         //   DataTable dt = new DataTable();
      //      NPOI_EXCEL.UploadtoDataTable(FL1, Gridview);

         //   Gridview.DataSource = dt;
           // Gridview.DataBind();

          //  Grid1.DataSource = dt;
          /*  string name = dt.Rows[0][1].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {

                }
            }*/
       //     Grid1.DataBind();

        }

        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            string FN="Student";//模板名
            NPOI_EXCEL.DownLoad(FN);
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
        }
    }
}
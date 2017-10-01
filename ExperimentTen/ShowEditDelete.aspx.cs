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

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //   NPOI_EXCEL.UploadtoDataTable(fileupload,GridView);
            NPOI_EXCEL.upload(FileLoad, gridview);
         /*   GridView.DataSource = dt;
            string name = dt.Rows[0][1].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    
                }
            }
            GridView.DataBind();
            */
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

           // NPOI_EXCEL.DownLoad();
        }
    }
}
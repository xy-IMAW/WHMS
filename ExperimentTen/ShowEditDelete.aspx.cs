﻿using System;
using System.Data;

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
      //    dt =  NPOI_EXCEL.UploadtoDataTable(FileUpload1);
            GridView1.DataSource = dt;
            string name = dt.Rows[0][1].ToString();
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    
                }
            }
            GridView1.DataBind();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

           // NPOI_EXCEL.DownLoad();
        }
    }
}
using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;
using System.IO;
using AspNet = System.Web.UI.WebControls;

namespace WHMS.Infor_Data
{
    public partial class ClassDataOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid(GridView1);
                GridView1.Caption = Common.Class + "班" + Common.SySe + "学期 工时表";
            }

        }


        public void Bind(DataTable data)
        {
            // DataTable data = new DataTable();
            DataRow dr;

            string sql1 = "select * from [Working_hoursInfor] where SySe like '%" + Common.SySe + "%'";
            string sql2 = "select StuID,StuName,Class from Student where Class='" + Common.Class + "' order by StuID";
            string sql3 = "select distinct Program,Date from [Working_hoursInfor] where SySe like '%" + Common.SySe + "%'";
            DataTable dt = Common.datatable(sql1);
            DataTable student = Common.datatable(sql2);
            DataTable program = Common.datatable(sql3);

            data.Columns.Add("学号", typeof(string));
            data.Columns.Add("姓名", typeof(string));
            data.Columns.Add("班级", typeof(string));

            for (int i = 0; i <= program.Rows.Count; i++)
            {

                if (i < program.Rows.Count)
                {
                    //   string time = (Convert.ToDateTime(program.Rows[i][1].ToString()).Date).ToString();
                    data.Columns.Add(program.Rows[i][0].ToString(), typeof(string));
                }

                else
                {
                    data.Columns.Add("合计", typeof(int));
                }
            }
            //构建活动行
            /*     dr = data.NewRow();
                 for (int i=0;i<program.Rows.Count;i++)
                 {

                     dr[i] = program.Rows[i][0].ToString();
                 }
                 data.Rows.Add(dr);
     */

            for (int i = 0; i < student.Rows.Count; i++)
            {
                dr = data.NewRow();
                dr[0] = student.Rows[i][0].ToString();
                dr[1] = student.Rows[i][1].ToString();
                dr[2] = student.Rows[i][2].ToString();

                int total = 0;
                for (int j = 0; j < program.Rows.Count; j++)
                {
                    for (int t = 0; t < dt.Rows.Count; t++)
                    {
                        string t1 = dt.Rows[t][0].ToString();
                        string t2 = student.Rows[i][0].ToString();
                        string t3 = dt.Rows[t][2].ToString();
                        string t4 = program.Rows[j][0].ToString();
                        if (dt.Rows[t][0].ToString() == student.Rows[i][0].ToString() && dt.Rows[t][2].ToString() == program.Rows[j][0].ToString())
                        {
                            // dr[program.Rows[j][0].ToString()]= dt.Rows[t][3].ToString();
                            dr[3 + j] = dt.Rows[t][3].ToString();
                            total += Convert.ToInt32(dt.Rows[t][3].ToString());
                        }
                    }
                }
                dr["合计"] = total;
                data.Rows.Add(dr);
            }

            //   GridView1.DataSource = data;
            //  GridView1.DataBind();
        }


        private void BindGrid(GridView GridView1)
        {
            #region  添加动态列   
            /*    GridView1.Columns.Clear();
                 GridView1.Width = new Unit(0);

                 string sql1 = "select * from [Working_hoursInfor] where SySe like '%2016-2017-1%'";
                 string sql2 = "select StuID,StuName,Class from Student where Class='信管1501' order by Class,StuID";
                 string sql3 = "select distinct Program,Date from [Working_hoursInfor] where SySe like '%2016-2017-1%'";
                 DataTable dt = Common.datatable(sql1);                                                                                                                                          
                 DataTable student = Common.datatable(sql2);
                 DataTable program = Common.datatable(sql3);

                 CreateGridColumn("学号", "学号", 150);
                 CreateGridColumn("姓名", "姓名", 150);
                 CreateGridColumn("班级", "班级", 150);


                 for (int i=0;i<=program.Rows.Count;i++)
                 {
                     if (i < program.Rows.Count)
                     {
                   //      DateTime time = Convert.ToDateTime(program.Rows[i][1].ToString()).Date;
                         CreateGridColumn(program.Rows[i][0].ToString(), program.Rows[i][0].ToString(), 150);
                     }
                     else
                     {
                        AspNet. TemplateField count = new AspNet. TemplateField();
                         GridView1.Columns.Add(count);
                     }
                 }*/
            #endregion



            DataTable data = new DataTable();
            Bind(data);
            //dt：数据源  
            GridView1.DataSource = data;
            GridView1.DataBind();
            output(GridView1);

        }


        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                string sql3 = "select distinct Program,Date from [Working_hoursInfor] where SySe like '%" + Common.SySe + "%'";
                DataTable program = Common.datatable(sql3);

                TableCellCollection header = e.Row.Cells;

                header.Clear();

                string headtxt = "学号</th><th rowspan='2'>姓名</th>";
                // headtxt += "<th colspan='"+program.Rows.Count+"'></th>";  //跨四列  
                headtxt += "<th rowspan='2'>班级</th>";
                for (int i = 0; i < program.Rows.Count; i++)
                {
                    DateTime Time = Convert.ToDateTime(program.Rows[i][1].ToString());
                    DateTime time = Time.Date;
                    headtxt += "<th>" + time.ToString("yyyy-MM-dd");
                    //  headtxt = headtxt.Substring(0, headtxt.Length - 5);  //移除掉最后一个</th>  
                }
                headtxt += "<th rowspan='2'>合计</th>";
                headtxt += "<tr>";
                for (int i = 0; i < program.Rows.Count; i++)
                {
                    headtxt += "<th>" + program.Rows[i][0].ToString() + "</th>";
                }
                headtxt += "</tr>";
                TableHeaderCell cell = new TableHeaderCell();
                cell.Attributes.Add("rowspan", "2");  //跨两行   
                cell.Text = (headtxt);
                header.Add(cell);
            }
        }


        public void output(GridView GridView1)
        {
            ResolveGridView(GridView1);

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile"+DateTime.Now.Date.ToString()+".xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);

            Response.Write(sw.ToString());
            Response.End();

            /*
                Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF7;
        Response.AppendHeader("Content-Disposition", "attachment;filename=MyExcelFile.xls");
        Response.ContentType = "application/excel";
        this.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        GridView1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
             */
        }
        private void ResolveGridView(System.Web.UI.Control ctrl)
        {

            for (int i = 0; i < ctrl.Controls.Count; i++)
            {
                // 图片的完整URL
                if (ctrl.Controls[i].GetType() == typeof(AspNet.Image))
                {
                    AspNet.Image img = ctrl.Controls[i] as AspNet.Image;
                    img.ImageUrl = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, Page.ResolveUrl(img.ImageUrl));
                }

                // 将CheckBox控件转化为静态文本
                if (ctrl.Controls[i].GetType() == typeof(AspNet.CheckBox))
                {
                    Literal lit = new Literal();
                    lit.Text = (ctrl.Controls[i] as AspNet.CheckBox).Checked ? "√" : "×";
                    ctrl.Controls.RemoveAt(i);
                    ctrl.Controls.AddAt(i, lit);
                }

                if (ctrl.Controls[i].HasControls())
                {
                    ResolveGridView(ctrl.Controls[i]);
                }

            }

        }
    }
}
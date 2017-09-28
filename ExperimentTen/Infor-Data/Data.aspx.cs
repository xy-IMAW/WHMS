using FineUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Text;

namespace WHMS.Infor_Data
{
    public partial class Data : System.Web.UI.Page
    {
        public string t1;//学年
        public string t2;//学期
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            if (!Page.IsPostBack)
            {
                Common.checklogin("../Login.aspx");
                //判断是否从学生信息页面跳转过来的
                if (Common.Sid != "")
                {
                    txtId.Text = Common.Sid;
                    string sqlStr = "select SySe,Program,[Working-hours] from [Working-hoursInfor] where StuID=" + Common.Sid;
                    DataSet myds = Common.dataSet(sqlStr);
                    gridExample.DataSource = myds;
                    gridExample.DataBind();
                    btnAdd.OnClientClick = windowPop.GetShowReference("");
                }
                gridExample.SortField = "SySe";
                BindGrid3();
                btnAdd.OnClientClick += windowPop.GetShowReference("EmpAdd.aspx", "增加职工");
                btnDelete.OnClientClick = gridExample.GetNoSelectionAlertReference("至少选择一项！");
            }

        }

        //学期下拉框绑定
        protected void BindGrid3()
         
        {

            //学期绑定。九月为分界
            int year = DateTime.Now.Year;
            int year2 = DateTime.Now.Year - 1;
            if (DateTime.Now.Month < 9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value =(--year2).ToString() + "-"+ (--year).ToString();
                    DL1.Items.Add(li);
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (year2--).ToString() + "-"+ (year--).ToString();
                    DL1.Items.Add(li);
                }
            }


            List<string> list2 = new List<string>();
            list2.Add("全部");
            list2.Add("1");
            list2.Add("2");

            DL2.DataSource = list2;
            DL2.DataBind();

        }
      /*  protected void BindGrid3()
        {
           
          
            //下拉列表框选项设置  手动设置           
            List<string> list1 = new List<string>();
            list1.Add("全部");
            list1.Add("2013-2014");
            list1.Add("2014-2015");
            list1.Add("2015-2016");
            list1.Add("2016-2017");
            list1.Add("2017-2018");
            list1.Add("2018-2019");
            DL1.DataSource = list1;
            DL1.DataBind();

            List<string> list2 = new List<string>();
            list2.Add("全部");
            list2.Add("1");
            list2.Add("2");

            DL2.DataSource = list2;
            DL2.DataBind();
        }
        */
        protected void btnDelete_Click3(object sender, EventArgs e)
        {
          
            string id = gridExample.SelectedRow.Values[0].ToString();//选中行的第一列为ID

            string sqlStr = "delete from Working-hours where SySe= '" + id + " '";
            Common.ExecuteSql(sqlStr);
            this.BindGrid3();
            Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
        }

        protected void gridExample_Sort(object sender, GridSortEventArgs e)
        {

        }

        protected void windowPop_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            this.BindGrid3();
        }
        #region select_handle
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            t1 = DL1.SelectedItem.Text;
            t2 = DL2.SelectedItem.Text;
            Common.Sid = txtId.Text;

            if (t1 == "全部")
            {
                DL2.ForceSelection = true;
                string sqlStr = "select SySe,Program,[Working-hours] from [Working-hoursInfor] where StuID=" + Common.Sid;
                DataSet myds = Common.dataSet(sqlStr);
                gridExample.DataSource = myds;
                gridExample.DataBind();

            }
            else
            {
                if (t2 == "全部")
                {
                    string sqlStr = "select SySe,Program,[Working-hours] from [Working-hoursInfor] where (SySe like'%" + t1 + "%') and StuID =" + Common.Sid;
                    DataSet myds = Common.dataSet(sqlStr);
                    gridExample.DataSource = myds;
                    gridExample.DataBind();
                }
                else
                {
                    string sqlStr = "select SySe,Program,[Working-hours] from [Working-hoursInfor] where (SySe like'" + t1 + "-" + t2 + "') and StuID =" + Common.Sid;
                    DataSet myds = Common.dataSet(sqlStr);
                    gridExample.DataSource = myds;
                    gridExample.DataBind();
                }

            }


        }
        #endregion
        #region excel_handle
        protected void Button1_Click(object sender, EventArgs e)
        {
            string excelname = DateTime.Now.ToString("yyyyMMhhmmss");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=" + excelname + ".xls");
            Response.ContentType = "application/x-xls";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write(GetGridTableHtml(gridExample));
            Response.End();
        }

        private string GetGridTableHtml(Grid grid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<meta http-equiv=\"content-type\" content=\"application/excel; charset=UTF-8\"/>");
            sb.Append("<table cellspacing=\"0\" rules=\"all\" border=\"1\" style=\"border-collapse:collapse;\">");
            sb.Append("<tr>");
            foreach (GridColumn column in grid.Columns)
            {
                sb.AppendFormat("<td>{0}</td>", column.HeaderText);
            }
            sb.Append("</tr>");
            foreach (GridRow row in grid.Rows)
            {
                sb.Append("<tr>");
                foreach (object value in row.Values)
                {
                    string html = value.ToString();
                    if (html.StartsWith(Grid.TEMPLATE_PLACEHOLDER_PREFIX))
                    {
                        // 模板列
                        string templateID = html.Substring(Grid.TEMPLATE_PLACEHOLDER_PREFIX.Length);
                        Control templateCtrl = row.FindControl(templateID);
                        html = GetRenderedHtmlSource(templateCtrl);
                    }
                    else
                    {
                        // 处理CheckBox
                        if (html.Contains("f-grid-static-checkbox"))
                        {
                            if (html.Contains("uncheck"))
                            {
                                html = "×";
                            }
                            else
                            {
                                html = "√";
                            }
                        }

                        // 处理图片
                        if (html.Contains("<img"))
                        {
                            string prefix = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                            html = html.Replace("src=\"", "src=\"" + prefix);
                        }
                    }
                    sb.AppendFormat("<td>{0}</td>", html);
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        private string GetRenderedHtmlSource(Control ctrl)
        {
            if (ctrl != null)
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        ctrl.RenderControl(htw);

                        return sw.ToString();
                    }
                }
            }
            return String.Empty;
        }
        #endregion

        protected void gridExample_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridExample.PageIndex = e.NewPageIndex;
        }
    }
}
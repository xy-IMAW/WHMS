using System;
using System.Data;
using FineUI;


namespace WHMS.Infor_Data
{
    public partial class Program : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDDL();
        }

        public void BindDDL()
        {
            int thisyear = DateTime.Now.Year;
            for (int I=1;I<5;I++)
            {
                ListItem Li = new ListItem();
                Li.Text = thisyear--.ToString();
                Li.Value = thisyear--.ToString();
                
                DDL.Items.Add(Li);
            }
        }

        public void Bind()
        {


            string year = DDL.SelectedItem.Value;
            string sqlstr = "select Program,Data from Program where Year="+year;
            DataTable dt = Common.datatable(sqlstr);
            gridExample.DataSource = dt;
            gridExample.DataBind();


            
        }
        //页面编号
        protected void gridExample_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridExample.PageIndex = e.NewPageIndex;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string sqlstr = "";
            Common.ExecuteSql(sqlstr);
            Alert.Show("添加成功","信息",MessageBoxIcon.Information);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sqlstr = "delete from";
            Common.ExecuteSql(sqlstr);
            Alert.Show("删除成功", "信息", MessageBoxIcon.Information);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
    }
}
using System;
using System.Data;
using FineUI;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WHMS.Infor_Data
{
    public partial class Program : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDDL();//学期下拉框
        }

        //学期绑定到两个下拉框
        public void BindDDL()
        {
            int year = DateTime.Now.Year;
            int year2 = DateTime.Now.Year - 1;
            if (DateTime.Now.Month <9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (--year).ToString() + "-" + (--year2).ToString();
                   DDL.Items.Add(li);
                    selectSy.Items.Add(li);
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (year--).ToString() + "-" + (year2--).ToString();
                    DDL.Items.Add(li);
                    selectSy.Items.Add(li);
                }
            }

            List<string> list2 = new List<string>();
            list2.Add("1");
            list2.Add("2");
            selectSe.DataSource = list2;
            selectSe.DataBind();
        }
        //查询某学期的活动
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }
        public void Bind()
        {


            string year = DDL.SelectedItem.Value;
            string sqlstr = "select Program,SySe,Data from Program where SySe='" +selectSy.SelectedItem.Text+"'";
            DataTable dt = Common.datatable(sqlstr);
            gridExample.DataSource = dt;
            gridExample.DataBind();


            
        }
        //页面编号
        protected void gridExample_PageIndexChange(object sender, GridPageEventArgs e)
        {
            gridExample.PageIndex = e.NewPageIndex;
        }
        //添加活动
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //查重
            bool flag = true;//标志是否账号已存在
            if (txtProgram.Text == "")
            {
                Alert.Show("请填写需要添加的活动信息", "提示", MessageBoxIcon.Warning);
            }
            else
            {
                string sqlstr = "select Program from Program where SySe='"+selectSy.SelectedItem.Text+"'";
                Common.Open();
                SqlDataReader reader = Common.ExecuteRead(sqlstr);
                while (flag)
                {
                    int a = 0;//标志是否进行了下面的循环
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("Program"));
                        if (name == txtProgram.Text)
                        {

                            Common.close();
                            flag = false;//该班级已存在
                            txtProgram.Text = "";
                            txtProgram.Focus();
                            break;
                        }
                        a++;
                    }
                    if (a == 0)
                    {
                        break;
                    }
                }
                if (flag)
                {
                    Common.close();
                    string sqlstr2 = "insert into Program (Program,SySe,Date) values ('" + txtProgram.Text + "','" + selectSy.SelectedItem.Text+"','"+date.SelectedDate.Value + "')";
                    Common.ExecuteSql(sqlstr2);
                    Alert.Show("添加成功", "提示信息", MessageBoxIcon.Information);
                }
                else
                {
                    Common.close();//任何情况结束后都要关闭连接
                    Alert.Show("该活动已在活动表中", "错误", MessageBoxIcon.Error);
                }
            }
        }
        //删除活动
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sqlstr = "delete from Program where Program='"+gridExample.SelectedRow.Values[1]+"'and Date='"+gridExample.SelectedRow.Values[3]+"'";
            Common.ExecuteSql(sqlstr);
            Alert.Show("删除成功", "信息", MessageBoxIcon.Information);
        }

      
    }
}
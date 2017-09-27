﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FineUI;
using System.Data;
using System.Data.SqlClient;

namespace WHMS.Infor_Data
{
    public partial class Class : System.Web.UI.Page
    {
        string grade;
        protected void Page_Load(object sender, EventArgs e)
        {
            GradeBind();
        }
        //年级下拉框绑定
        protected void GradeBind()
        {
            int year = DateTime.Now.Year;
            if (DateTime.Now.Month < 9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (--year).ToString();
                    SelectGrade.Items.Add(li);
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (year--).ToString();
                    SelectGrade.Items.Add(li);
                }
            }
        }
        //删除班级
        protected void btnDeleteClass_Click(object sender, EventArgs e)
        {
            if (Grid3.SelectedRowIndex < 0)
            {
                Alert.Show("请选择一项进行删除", "警告", MessageBoxIcon.Warning);
            }
            else
            {              
                string sqlStr = "delete from Class where Class= '" + Grid3.SelectedRow.Values[1].ToString()+"'";
                Common.ExecuteSql(sqlStr);          
                BindGrid3();
                Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);

            }
        }

        //班级表单数据绑定
        public void BindGrid3()
        {
            string sqlstr = "select Class,Grade from Class where Grade = '" + grade + "'";
            DataTable dt = Common.datatable(sqlstr);
            // DataSet ds = Common.dataSet(sqlstr);
            Grid3.DataSource = dt;
            Grid3.DataBind();

        }

        //查找班级
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            grade = SelectGrade.SelectedItem.Text;
            string sqlstr = "select Grade,Class from Class where Grade ='"+grade+"'";
            DataTable dt = Common.datatable(sqlstr);
            Grid3.DataSource = dt;
            Grid3.DataBind();
        }

        //添加班级
        protected void btnAddClass_Click(object sender, EventArgs e)
        {
            //查重
            bool flag = true;//标志
            if (txtClassName.Text == "" || txtGrade.Text == "")
            {
                Alert.Show("请填写需要添加的班级信息", "提示", MessageBoxIcon.Warning);
            }
            else
            {
                string sqlstr = "select Class from Class";
                Common.Open();
                SqlDataReader reader = Common.ExecuteRead(sqlstr);
                while (flag)
                {
                    int a = 0;//标志是否进行了下面的循环
                    while (reader.Read())
                    {
                        string name = reader.GetString(reader.GetOrdinal("Class"));
                        if (name == txtClassName.Text)
                        {

                            Common.close();
                            flag = false;//该班级已存在
                            txtClassName.Text = "";
                            txtClassName.Focus();
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
                    string sqlstr2 = "insert into Class (Class,Grade) values ('" + txtClassName.Text + "','" + txtGrade.Text + "')";
                    Common.ExecuteSql(sqlstr2);
                    Alert.Show("添加成功", "提示信息", MessageBoxIcon.Information);
                }
                else
                {
                    Common.close();//任何情况结束后都要关闭连接
                    Alert.Show("该班级已在班级表中", "错误", MessageBoxIcon.Error);
                }
            }


        }
    }
}
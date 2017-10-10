using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FineUI;

namespace WHMS.Infor_Data
{
    public partial class ClassData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }
        public void Bind()
        {
            int year = DateTime.Now.Year;
            int year2 = DateTime.Now.Year - 1;
            if (DateTime.Now.Month < 9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (--year).ToString();
                    DL1.Items.Add(li);
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (year--).ToString();
                    DL1.Items.Add(li);
                }
            }

            //学期绑定。九月为分界
            year = DateTime.Now.Year;
            if (DateTime.Now.Month < 9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (--year2).ToString() + "-" + (--year).ToString();
                    DL3.Items.Add(li);
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (year2--).ToString() + "-" + (year--).ToString();
                    DL3.Items.Add(li);
                }
            }


            List<string> list2 = new List<string>();
            list2.Add("全部");
            list2.Add("1");
            list2.Add("2");

            DL4.DataSource = list2;
            DL4.DataBind();

        }

        public void BindClass()
        {
            string sqlstr = "select Class from Class where Grade ='"+DL1.SelectedItem.Text+"'";
            Common.Open();
            SqlDataReader reader = Common.ExecuteRead(sqlstr);
            while (reader.Read())
            {
                ListItem li = new ListItem();
                li.Text = li.Value = reader["Class"].ToString();
                DL2.Items.Add(li);
            }
        }

        protected void DL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClass();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            DataControl.ClassData(table1,DL2.SelectedItem.Text,DL3.SelectedItem.Text,DL4.SelectedItem.Text);
        }
    }
}
using System;
using System.Collections.Generic;
using FineUI;

namespace WHMS.Infor_Data
{
    public partial class GradeData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DL1bind();
                btn2.OnClientClick = window1.GetShowReference("HoursImport.aspx","导入工时");
            }
        }
        public void DL1bind()
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
             year= DateTime.Now.Year;
            if (DateTime.Now.Month < 9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (--year2).ToString() + "-" + (--year).ToString();
                    DL2.Items.Add(li);
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    ListItem li = new ListItem();
                    li.Text = li.Value = (year2--).ToString() + "-" + (year--).ToString();
                    DL2.Items.Add(li);
                }
            }


            List<string> list2 = new List<string>();
            list2.Add("全部");
            list2.Add("1");
            list2.Add("2");

            DL3.DataSource = list2;
            DL3.DataBind();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            DataControl.GradeData(table1,DL2.SelectedItem.Text,DL3.SelectedItem.Text,DL1.SelectedItem.Text);
        }
    }
}
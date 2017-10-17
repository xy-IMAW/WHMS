using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FineUI;
using System.Web.UI.WebControls;
using System.Data;

namespace WHMS.Infor_Data
{
    public partial class ClassData : System.Web.UI.Page
    {
        string grade;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                BindClass();
                btn2.OnClientClick = window1.GetShowReference("HoursImport.aspx","导入工时");
            }
        
        }
        public void Bind()
        {
            //年级
            int year = DateTime.Now.Year;
            
            if (DateTime.Now.Month < 9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    FineUI.ListItem li = new FineUI.ListItem();
                    li.Text = li.Value = (--year).ToString();
                    DL1.Items.Add(li);
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    FineUI.ListItem li = new FineUI.ListItem();
                    li.Text = li.Value = (year--).ToString();
                    DL1.Items.Add(li);
                }
            }
            DL1.SelectedIndex = 0;

            //学期绑定。九月为分界
            year = DateTime.Now.Year;
            int year2 = DateTime.Now.Year + 1;
            if (DateTime.Now.Month < 9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    FineUI.ListItem li = new FineUI.ListItem();
                    li.Text = li.Value =(--year).ToString() + "-" + (--year2).ToString();
                    DL3.Items.Add(li);
                
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    FineUI.ListItem li = new FineUI.ListItem();
                    li.Text = li.Value = (year--).ToString() + "-" + (year2--).ToString();
                    DL3.Items.Add(li);
                }
            }


            List<string> list2 = new List<string>();
           // list2.Add("全部");
            list2.Add("1");
            list2.Add("2");

            DL4.DataSource = list2;
            DL4.DataBind();

        }

        public void BindClass()
        {
             grade = DL1.SelectedItem.Text;
            string sqlstr = "select Class from Class where Grade ='"+grade+"'";
            Common.Open();
            SqlDataReader reader = Common.ExecuteRead(sqlstr);
            while (reader.Read())
            {
                FineUI.ListItem li = new FineUI.ListItem();
                li.Text = li.Value = reader["Class"].ToString();
                DL2.Items.Add(li);
            }
            Common.close();
        }


        protected void btn_Click(object sender, EventArgs e)
        {
            //  DataControl.ClassData(table1,DL2.SelectedItem.Text,DL3.SelectedItem.Text,DL4.SelectedItem.Text);

            DataTable data = new DataTable();
            Bind(data);
            //dt：数据源  
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
        public void Bind(DataTable data)
        {
            // DataTable data = new DataTable();"+DL3.SelectedItem.Text+"-"+DL4.SelectedItem.Text+"
            DataRow dr;

            string sql1 = "select * from [Working_hoursInfor] where SySe like '%2017-2018-1%'";
            string sql2 = "select StuID,StuName,Class from Student where Class='"+DL2.SelectedItem.Text+"' order by Class,StuID";
            string sql3 = "select distinct Program,Date from [Working_hoursInfor] where SySe like '%2017-2018-1%'";
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
            //     GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)//涉及一个问题：页面初始加载时显示什么
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                string sql3 = "select distinct Program,Date from [Working_hoursInfor] where SySe like '%2017-2018-1%'";
                DataTable program = Common.datatable(sql3);

                TableCellCollection header = e.Row.Cells;
                header.Clear();

                string headtxt = "学号</th><th rowspan='2'>姓名</th>";
                // headtxt += "<th colspan='"+program.Rows.Count+"'></th>";  //跨四列  
                headtxt += "<th rowspan='2'>班级</th>";
                for (int i = 0; i < program.Rows.Count; i++)
                {
                    string t = program.Rows[i][1].ToString();
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





        protected void DL1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grade = DL1.SelectedItem.Text;
            DL2.Items.Clear();
            DL2.SelectedIndex = 0;
            BindClass();
        }
    }
}
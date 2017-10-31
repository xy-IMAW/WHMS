using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using FineUI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WHMS.Infor_Data
{
    public partial class Class : System.Web.UI.Page
    {
        string grade;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Common.Class = "";
                Common.SySe = "";
                Import.OnClientClick = window1.GetShowReference("ClassImport.aspx");
                 btn3.OnClientClick = window1.GetShowReference("HoursImport.aspx", "导入工时");
             //   btn.OnClientClick = window1.GetShowReference("../ShowEditDelete.aspx");
                GradeBind();
            }
         
        }
        //年级下拉框绑定
        protected void GradeBind()
        {
            int year = DateTime.Now.Year;
            if (DateTime.Now.Month < 9)
            {
               

                for (int i = 1; i < 5; i++)
                {
                    FineUI.ListItem li = new FineUI.ListItem();
                    li.Text = li.Value = (--year).ToString();
                    SelectGrade.Items.Add(li);
                }
            }
            else
            {
               

                for (int i = 1; i < 5; i++)
                {
                    FineUI.ListItem li = new FineUI.ListItem();
                    li.Text = li.Value = (year--).ToString();
                    SelectGrade.Items.Add(li);
                }
            }

            //学期绑定。九月为分界
            year = DateTime.Now.Year;
            int year2 = DateTime.Now.Year + 1;
            if (DateTime.Now.Month < 9)
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    string y1 = (--year).ToString();
                    string y2 = (--year2).ToString();

                    FineUI.ListItem li = new FineUI.ListItem();
                    li.Text = li.Value = (y1).ToString() + "-" + (y2).ToString()+"-1";
                    DL3.Items.Add(li);

                  li = new FineUI.ListItem();
                    li.Text = li.Value = (y1).ToString() + "-" + (y2).ToString() + "-2";
                    DL3.Items.Add(li);
                }
            }
            else
            {
                List<string> list = new List<string>();

                for (int i = 1; i < 5; i++)
                {
                    string y1 = (year--).ToString();
                    string y2 = (year2--).ToString();

                    FineUI.ListItem li = new FineUI.ListItem();
                    li.Text = li.Value = (y1).ToString() + "-" + (y2).ToString()+"-1";
                    DL3.Items.Add(li);

                   li = new FineUI.ListItem();
                    li.Text = li.Value = (y1).ToString() + "-" + (y2).ToString() + "-2";
                    DL3.Items.Add(li);
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
                string sqlStr = "delete from Class where Class= '" + Grid3.SelectedRow.Values[2].ToString()+"'";
                Common.ExecuteSql(sqlStr);          
                BindGrid3();
                Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);

            }
        }

        //班级表单数据绑定
        public void BindGrid3()
        {
            grade = SelectGrade.SelectedItem.Text;
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

        protected void DownLoad_Click(object sender, EventArgs e)
        {
            string fn = "Working_hours";
            NPOI_EXCEL.DownLoad(fn);
        }

        protected void window1_Close(object sender, WindowCloseEventArgs e)
        {
            BindGrid3();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            if (Grid3.SelectedRowIndex < 0)
            {
                Alert.Show("请选择要查看的班级", "提示", MessageBoxIcon.Warning);
            }
            else
            {
                Common.Class = Grid3.SelectedRow.Values[2].ToString();
                Common.SySe = DL3.SelectedText;
                   PageContext.RegisterStartupScript(window1.GetShowReference("ClassData.aspx"));
                //   Response.Redirect("ClassData.aspx");
              //  PageContext.RegisterStartupScript(window1.GetShowReference("../ShowEditDelete.aspx"));
            }
         
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            Common.grade =Convert.ToInt32( SelectGrade.SelectedValue);
            Common.SySe = DL3.SelectedValue.ToString();
     //         PageContext.RegisterStartupScript(window1.GetShowReference("GradeData.aspx"));
          //  Response.Redirect("GradeData.aspx");
        }

        protected void GridView_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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


        }

    }
}
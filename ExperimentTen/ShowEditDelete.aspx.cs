using System;
using System.Data;
using FineUI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WHMS
{
    public partial class ShowEditDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             //   bind();
            }
        }
      

        protected void btn1_Click(object sender, EventArgs e)
        {
            // NPOI_EXCEL.upload(FileUpload,GridView1);
            NPOI_EXCEL.upload(fileupload, GridView1);
            //   GridToData();
        
        }

        public void GridToData()
        {
            for (int i = 1; i < GridView1.Rows.Count; i++)
            {
                Alert.Show(GridView1.Rows[i].Cells[0].Text);
            }
        }

        public void Updata()
        {
            bool NoRepeat = true;
            int flag = 0;
            int flag2 = 0;
            string Class;
            string Grade;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Class = GridView1.Rows[i].Cells[1].Text;
                Grade = GridView1.Rows[i].Cells[0].Text;
                string sqlstr1 = "select Class from Class";
                Common.Open();
                SqlDataReader re = Common.ExecuteRead(sqlstr1);
                while (re.Read())
                {
                    string class1 = re.GetString(re.GetOrdinal("Class"));
                    if (class1 == Class)
                    {
                        NoRepeat = false;
                        flag ++;//重复次数
                        break;
                    }
                    NoRepeat = true;
                }
                Common.close();
                //未重复才添加
                if (NoRepeat)
                {
                   
                    string sqlstr = "insert into Class (Class,Grade) values ('" + Class + "','" + Grade + "')";//插入新数据
                    Common.ExecuteSql(sqlstr);
                    flag2++;
                }
         
            }
            if (flag == 0)
            {
                Alert.Show("添加成功！\r\n已添加" + flag2.ToString() + "条记录！", "提示", MessageBoxIcon.Information);
            }
            else
            {
                Alert.Show("已添加"+flag2.ToString()+"条记录\r\n 有"+flag.ToString()+"条记录重复", "提示", MessageBoxIcon.Information);

            }


        }

        protected void btn_Click(object sender, EventArgs e)
        {
            // Updata();
         //   DataControl.UpdataClass(GridView1);
            DataControl.UpdataWorking_hours(GridView1);
        }

        public void bind()
        {
            //
            string sql1 = "select * from [Working-hours]";
            string sql2 = "select StuID,StuName,Class from Student where Class='信管1501' order by Class,StuID";
            string sql3 = "select distinct Program from [Working-hours]";
            DataTable dt = Common.datatable(sql1);
            DataTable student = Common.datatable(sql2);
            DataTable program = Common.datatable(sql3);
            
          //  Table table1 = new Table();
         //  FineUI.Label lb;

            //第一列表头
            TableRow tr = new TableRow();//行
               tr.HorizontalAlign = HorizontalAlign.Center;
               TableCell tc = new TableCell();//列
            tc.Text = "学号";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "姓名";
            tr.Cells.Add(tc);

            tc = new TableCell();
            tc.Text = "行政班级";
            tr.Cells.Add(tc);

            for (int i=0;i<=program.Rows.Count;i++)
            {
                tc = new TableCell();
                if (i < program.Rows.Count)
                {
                    tc.Text = program.Rows[i][0].ToString();
                }
                else
                {
                    tc.Text = "合计";
                }
                tr.Cells.Add(tc);
            }

            table1.Rows.Add(tr);
        
            for (int i = 0; i < student.Rows.Count; i++)
            {
                tr = new TableRow();
                tc = new TableCell();
                //    lb = new FineUI.Label();
                //    lb.Text = student.Rows[i][0].ToString();
                //   tc.Controls.Add(lb);
                tc.Text = student.Rows[i][0].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.Text = student.Rows[i][1].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.Text = student.Rows[i][2].ToString();
                tr.Cells.Add(tc);

                int total = 0;
                for (int j=0;j<program.Rows.Count;j++)
                {
                    tc = new TableCell();
                    //        lb = new FineUI.Label();
                    for (int t=0;t<dt.Rows.Count;t++)
                    {
                        if (dt.Rows[t][0].ToString()==student.Rows[i][0].ToString()&&dt.Rows[t][3].ToString()==program.Rows[j][0].ToString())
                        {
                            tc.Text = dt.Rows[t][4].ToString();
                            total += Convert.ToInt32(tc.Text);
                        }
                    }
                    tc.Attributes.Add("text-align","center");
                    tr.Cells.Add(tc);
                }
                tc = new TableCell();
                tc.Text = total.ToString();
                tr.Cells.Add(tc);
                table1.Rows.Add(tr);

            }
            
        }
    }
}
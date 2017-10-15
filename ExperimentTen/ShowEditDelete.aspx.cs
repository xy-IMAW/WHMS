using System;
using System.Data;
using FineUI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;

namespace WHMS
{
    public partial class ShowEditDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //     bind();
                //   Bind();
                InitGrid2();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            InitGrid2();
        }


        public void Bind()
        {
            string sql = "select * from Student where Grade='2015'";
            DataTable dt = Common.datatable(sql);
            grid.DataSource = dt;
            grid.DataBind();
        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            // NPOI_EXCEL.upload(FileUpload,GridView1);
       //     NPOI_EXCEL.upload(fileupload, GridView1);
            //   GridToData();
            DataTable dt = new DataTable();
            dt = NPOI_EXCEL.getDataTable(FileUpload1);
            grid.DataSource = dt;
            grid.DataBind();
       //     Alert.Show(grid.Rows[0].Values[0].ToString());
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
            //  DataControl.UpdataWorking_hours(GridView1);
            DataControl.UpdataStudent(grid);
        }


        public void bind()
        {
            //
            string sql1 = "select * from [Working_hoursInfor]";
            string sql2 = "select StuID,StuName,Class from Student where Class='信管1501' order by Class,StuID";
            string sql3 = "select distinct Program from [Working_hoursInfor]";
            DataTable dt = Common.datatable(sql1);
            DataTable student = Common.datatable(sql2);
            DataTable program = Common.datatable(sql3);
            
          //  Table table1 = new Table();
         //  FineUI.Label lb;

            //第一列表头
            TableRow tr = new TableRow();//行
      //      GridRow gr = new GridRow();
            
            
                
               tr.HorizontalAlign = HorizontalAlign.Center;
               TableCell tc = new TableCell();//列
            tc.Text = "学号";
            tr.Cells.Add(tc);
          //  gr.Values[0] = "学号";

            tc = new TableCell();
            tc.Text = "姓名";
            tr.Cells.Add(tc);
         //   gr.Values[1] = "姓名";

            tc = new TableCell();
            tc.Text = "行政班级";
            tr.Cells.Add(tc);
       //     gr.Values[2] = "行政班级";

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
      //      grid.Rows.Add(gr);
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
              //  int o = table1.Rows.Count;

            }
            
        }

        protected void OUT_Click(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();
            TableToExcel(table1);
           
        }
        public static bool TableToExcel(Table table1)
        {

            bool result = false;
            IWorkbook workbook = null;
            FileStream fs = null;
            IRow row = null;
            ISheet sheet = null;
            ICell cell = null;
            try
            {
                if (table1 != null && table1.Rows.Count > 0)
                {
                    workbook = new HSSFWorkbook();
                    sheet = workbook.CreateSheet("Sheet0");//创建一个名称为Sheet0的表  
                 //   int rowCount = dt.Rows.Count;//行数  
               int     rowCount = table1.Rows.Count;
               //     int columnCount = dt.Columns.Count;//列数  
                 int   columnCount = table1.Rows[0].Cells.Count;

                    //设置列头  
                    row = sheet.CreateRow(0);//excel第一行设为列头  
                    for (int c = 0; c < columnCount; c++)
                    {
                       cell = row.CreateCell(c);
                        //cell.SetCellValue(dt.Columns[c].ColumnName);
                        cell.SetCellValue(table1.Rows[0].Cells[c].ToString());
                    }

                    //设置每行每列的单元格,  
                    for (int i = 0; i < rowCount; i++)
                    {
                        row = sheet.CreateRow(i + 1);
                        for (int j = 0; j < columnCount; j++)
                        {
                            cell = row.CreateCell(j);//excel第二行开始写入数据  
                           // cell.SetCellValue(dt.Rows[i][j].ToString());
                           cell.SetCellValue(table1.Rows[i].Cells[j].ToString());
                        }
                    }
                    using (fs = File.OpenWrite(@"D:/myxls.xls"))
                    {
                        workbook.Write(fs);//向打开的这个xls文件中写入数据  
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

                if (fs != null)
                {
                    fs.Close();
                    throw ex;
                }

                return false;
            }
        }


        public void InitGrid2()
        {
            string sql1 = "select * from [Working_hoursInfor]";
            string sql2 = "select StuID,StuName,Class from Student where Class='信管1501' order by Class,StuID";
            string sql3 = "select distinct Program from [Working_hoursInfor]";
            DataTable dt = Common.datatable(sql1);
            DataTable student = Common.datatable(sql2);
            DataTable program = Common.datatable(sql3);

            FineUI.BoundField bf;

            bf = new FineUI.BoundField();
               bf.DataField = "StuID";
                bf.HeaderText = "学号";
                grid2.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "StuName";
            bf.HeaderText = "姓名";
            grid2.Columns.Add(bf);

            bf = new FineUI.BoundField();
            bf.DataField = "Class";
            bf.HeaderText = "行政班级";
            grid2.Columns.Add(bf);

            for (int i=0;i<program.Rows.Count;i++)
            {
                bf = new FineUI.BoundField();
                bf.DataField = program.Rows[i][0].ToString();
                bf.HeaderText = program.Rows[i][0].ToString();
                grid2.Columns.Add(bf);
            }

            bf = new FineUI.BoundField();
            bf.DataField = "count";
            bf.HeaderText = "合计";
            grid2.Columns.Add(bf);

            for (int i=0;i<student.Rows.Count;i++)
            {
                GridRow gr = new GridRow();
                gr.Values[0] = student.Rows[i][0].ToString();
                grid2.Rows[i].Values[0] = student.Rows[i][0].ToString();
                grid2.Rows[i].Values[1]= student.Rows[i][1].ToString();
                grid2.Rows[i].Values[2] = student.Rows[i][2].ToString();

                int total = 0;
                for (int j=0;j<program.Rows.Count;j++)
                {
                    for (int t=0;t<dt.Rows.Count;t++)
                    {
                        if (dt.Rows[t][0].ToString() == student.Rows[i][0].ToString() && dt.Rows[t][3].ToString() == program.Rows[j][0].ToString())
                        {
                            grid2.Rows[i].Values[3 + j] = dt.Rows[t][4].ToString();
                            total += Convert.ToInt32(grid2.Rows[i].Values[3 + j]);
                        }
                        else
                        {
                            grid2.Rows[i].Values[3 + j] = "";
                        }
                    }
                }
                grid2.Rows[i].Values[3 + program.Rows.Count] = total.ToString();
            }
        }
    }
}
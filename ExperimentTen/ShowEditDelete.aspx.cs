using System;
using System.Data;
using FineUI;
using System.Data.SqlClient;

namespace WHMS
{
    public partial class ShowEditDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
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
            Updata();
        }
    }
}
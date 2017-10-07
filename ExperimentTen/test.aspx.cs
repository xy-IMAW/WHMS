using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using FineUI;

namespace WHMS
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          //  Bind1();
        }
        public void Bind1()
        {
            string sqlstr = "select * from [Working-hoursInfor]";

            DataSet ds = new DataSet();
            ds = Common.dataSet(sqlstr);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            #region
            /*
            if (file.HasFile)
            {
                string fileName = file.ShortFileName;

                if (!ValidateFileType(fileName))
                {
                    ShowNotify("无效的文件类型！");
                    return;
                }


                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                file.SaveAs(Server.MapPath("~/upload/" + fileName));


                labResult.Text = "<p>文件路径：" + file.FileName + "</p>" +

                    "<p>头像：<br /><img src=\"" + ResolveUrl("~/upload/" + fileName) + "\" /></p>";

                //// 清空表单字段（第一种方法）
                //tbxUserName.Reset();
                //file.Reset();

                // 清空表单字段（第三种方法）
                SimpleForm1.Reset();

            }
            */
            #endregion
       
        }

        protected void btnupload1_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(FileUpload1,GridView1);
         /*   bool fileOK = true;


            //文件的上传路径
            string path = Server.MapPath("~/ExperimentTen/res/Import/");


            //判断上传文件夹是否存在，若不存在，则创建
            if (!Directory.Exists(path))
            {
                //创建文件夹 
                Directory.CreateDirectory(path);
            }
            if (FileUpload1.HasFile)
            {


                //允许上传的类型
                //string[] allowExtesions = { ".doc", ".xls", ".rar", ".zip", ".ppt" };
                //for (int i = 0; i < allowExtesions.Length; i++)
                //{
                //    if (fileExtesion == allowExtesions[i])
                //    {
                //        //文件格式正确 允许上传
                //        fileOK = true;
                //    }
                //}


                string name = FileUpload1.FileName;// 获得上传文件的名字.
                int size = FileUpload1.PostedFile.ContentLength;// 文件大小.
                if (size > (1000000 * 1024))
                {
                    fileOK = false;
                    Label2.Text = "文件过大";
                }
                string type = FileUpload1.PostedFile.ContentType;// 文件类型.


                // 获取上传文件的类型(后缀)
                string fileExtesion = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();


                //string type2 = name.Substring(name.LastIndexOf(".") + 1);// LastIndexOf()最后一个索引位置匹配.Substring()里面的+1是重载.
                if (fileOK)
                {
                    try
                    {
                        Random ranNum = new Random();


                        // 在1和1000之间的随机正整数
                        int num = ranNum.Next(1, 1000);
                        // 获取当前时间
                        string newname = "";
                        //System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
                        // 声明文件名，防止重复
                        newname = newname + num;

                        string ipath = Server.MapPath("~/ExperimentTen/res/Import/") + "\\" + newname; // 取得根目录下面的upimg目录的路径.
                        string fpath = Server.MapPath("~/ExperimentTen/res/Import/") + "\\" + newname;
                        string wpath = "~/ExperimentTen/res/Import/\\" + newname; // 获得虚拟路径
                        if (fileExtesion == ".jpg" || fileExtesion == ".gif" || fileExtesion == ".bmp" || fileExtesion == ".png")
                        {
                            FileUpload1.SaveAs(ipath); // 保存方法,参数是一个地址字符串.
                            Image1.ImageUrl = wpath;
                            Label1.Text = "你传的文件名是:" + name + "<br>文件大小为:" + size + "字节<br>文件类型是:" + type +
                                "<br>后缀是:" + fileExtesion + "<br>实际路径是:" + ipath + "<br>虚拟路径是:" + fpath;
                            Image1.Visible = true;
                            fileUrl.Text = ipath;
                        }
                        else
                        {
                            Image1.Visible = false;
                            FileUpload1.SaveAs(fpath);
                            Label1.Text = "你传的文件名是:" + name + "<br>文件大小为:" + size + "字节<br>文件类型是:" + type +
                                "<br>后缀是:" + fileExtesion + "<br>实际路径是:" + ipath + "<br>虚拟路径是:" + fpath;
                            fileUrl.Text = fpath;
                        }
                        // FileUpload1.PostedFile.SaveAs(path + newname);


                        //Session["filename"] = newname;
                        Label2.Text = "上传成功";
                        fileName.Text = name;
                        filesize.Text = size.ToString();
                        DataTable dt = new DataTable();
                        dt = NPOI_EXCEL.ExcelToDataTable(ipath, true);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        //lab_upload.Text = "上传成功";
                    }
                    catch (Exception ex)
                    {


                        Label2.Text = "上传失败";
                        throw ex;
                    }
                }
            }
            else
            {
                //尚未选择文件
                Label2.Text = "尚未选择任何文件，请选择文件";
                return;
            }
            */
        }

        protected void btnupload2_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(fileupload,grid);
        }

        protected void btnupload3_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(fileupload,GridView1);
        }
        protected void btnupload4_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(FileUpload1,grid);
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(FileUpload1, Grid2);
        }
        protected void btn2_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(fileupload, grid);
        }
        protected void btn3_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(fileupload, Grid2);
        }
        protected void btn4_Click(object sender, EventArgs e)
        {
            NPOI_EXCEL.upload(FileUpload1, grid);
        }
    }
}
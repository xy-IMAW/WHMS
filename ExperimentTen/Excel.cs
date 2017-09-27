using System;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Data;
using System.Web;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Linq;

using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Configuration;



namespace WHMS
{
    public class NPOI_EXCEL
    {
        /// <summary>  
        /// 将excel导入到datatable  
        /// </summary>  
        /// <param name="filePath">excel路径</param>  
        /// <param name="isColumnName">第一行是否是列名</param>  
        /// <returns>返回datatable</returns>  
       ///Excel读入
        public static DataTable ExcelToDataTable(string filePath, bool isColumnName)

        {
            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;
            try
            {
                using (fs = File.OpenRead(filePath))
                {
                    // 2007版本  
                    if (filePath.IndexOf(".xlsx") > 0)
                        workbook = new XSSFWorkbook(fs);
                    // 2003版本  
                    else if (filePath.IndexOf(".xls") > 0)
                        workbook = new HSSFWorkbook(fs);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheetAt(0);//读取第一个sheet，当然也可以循环读取每个sheet  
                        dataTable = new DataTable();
                        if (sheet != null)
                        {
                            int rowCount = sheet.LastRowNum;//总行数  
                            if (rowCount > 0)
                            {
                                IRow firstRow = sheet.GetRow(0);//第一行  
                                int cellCount = firstRow.LastCellNum;//列数  

                                //构建datatable的列  
                                if (isColumnName)
                                {
                                    startRow = 1;//如果第一行是列名，则从第二行开始读取  
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        cell = firstRow.GetCell(i);
                                        if (cell != null)
                                        {
                                            if (cell.StringCellValue != null)
                                            {
                                                column = new DataColumn(cell.StringCellValue);
                                                dataTable.Columns.Add(column);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                                    {
                                        column = new DataColumn("column" + (i + 1));
                                        dataTable.Columns.Add(column);
                                    }
                                }

                                //填充行  
                                for (int i = startRow; i <= rowCount; ++i)
                                {
                                    row = sheet.GetRow(i);
                                    if (row == null) continue;

                                    dataRow = dataTable.NewRow();
                                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                                    {
                                        cell = row.GetCell(j);
                                        if (cell == null)
                                        {
                                            dataRow[j] = "";
                                        }
                                        else
                                        {
                                            //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
                                            switch (cell.CellType)
                                            {
                                                case CellType.Blank:
                                                    dataRow[j] = "";
                                                    break;
                                                case CellType.Numeric:
                                                    short format = cell.CellStyle.DataFormat;
                                                    //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理  
                                                    if (format == 14 || format == 31 || format == 57 || format == 58)
                                                        dataRow[j] = cell.DateCellValue;
                                                    else
                                                        dataRow[j] = cell.NumericCellValue;
                                                    break;
                                                case CellType.String:
                                                    dataRow[j] = cell.StringCellValue;
                                                    break;
                                            }
                                        }
                                    }
                                    dataTable.Rows.Add(dataRow);
                                }
                            }
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return dataTable;
            }
        }

        /// <summary>
        /// Excel导出
        /// </summary>
        /// <param name="dt">需要导出的表</param>
        /// <returns></returns>
        public static bool DataTableToExcel(DataTable dt)
        {
            bool result = false;
            IWorkbook workbook = null;
            FileStream fs = null;
            IRow row = null;
            ISheet sheet = null;
            ICell cell = null;
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    workbook = new HSSFWorkbook();
                    sheet = workbook.CreateSheet("Sheet0");//创建一个名称为Sheet0的表  
                    int rowCount = dt.Rows.Count;//行数  
                    int columnCount = dt.Columns.Count;//列数  

                    //设置列头  
                    row = sheet.CreateRow(0);//excel第一行设为列头  
                    for (int c = 0; c < columnCount; c++)
                    {
                        cell = row.CreateCell(c);
                        cell.SetCellValue(dt.Columns[c].ColumnName);
                    }

                    //设置每行每列的单元格,  
                    for (int i = 0; i < rowCount; i++)
                    {
                        row = sheet.CreateRow(i + 1);
                        for (int j = 0; j < columnCount; j++)
                        {
                            cell = row.CreateCell(j);//excel第二行开始写入数据  
                            cell.SetCellValue(dt.Rows[i][j].ToString());
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

        /// <summary>
        /// 模板文件下载
        /// </summary>
        public static  void DownLoad(string FN)
        {
            string fileName =FN+ ".xls";//客户端保存的文件名
          //  string filePath = Server.MapPath("~/ExperimentTen/res/DownLoad/muban.xls");//路径
            string filePath = HttpContext.Current.Server.MapPath("~/ExperimentTen/res/DownLoad/muban.xls");//路径

            //以字符流的形式下载文件
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length];
            fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            //  Response.ContentType = "application/octet-stream";
          HttpContext.Current.Response.ContentType = "application/excel";

            //通知浏览器下载文件而不是打开
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.BinaryWrite(bytes);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="FileUpload1">文件框</param>
        /// <param name="GridView1">表单</param>
        public static void UploadtoDataTable(FineUI.FileUpload FileUpload1,GridView grid)
        {
            DataTable dt = new DataTable();
            bool fileOK = true;
            //文件的上传路径
            string path = HttpContext.Current.Server.MapPath("~/ExperimentTen/res/Import/");
           
            if (FileUpload1.HasFile)
            {
                string name = FileUpload1.FileName;// 获得上传文件的名字.
                string type = FileUpload1.PostedFile.ContentType;// 文件类型.
                // 获取上传文件的类型(后缀)
                string fileExtesion = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                //string type2 = name.Substring(name.LastIndexOf(".") + 1);// LastIndexOf()最后一个索引位置匹配.Substring()里面的+1是重载.
                if (fileOK)
                {
                    try
                    {
                     //   Random ranNum = new Random();
                        // 在1和1000之间的随机正整数
                        //  int num = ranNum.Next(1, 10);
                        // 获取当前时间
                        string newname = System.DateTime.Now.ToString("yyyyMMddHHmmss");
                        // 声明文件名，防止重复
                        newname = newname +name+ fileExtesion;
                        string fpath = HttpContext.Current.Server.MapPath("~/ExperimentTen/res/Import/") + "\\" + newname;//路径                       
                        if (type == "application/vnd.ms-excel" || type == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                          
                            FileUpload1.SaveAs(fpath);

                            //处理Excel 返回DateTable
                            Alert.Show("上传成功","信息",MessageBoxIcon.Information);

                        
                            dt = NPOI_EXCEL.ExcelToDataTable(fpath, false);
                            grid.DataSource = dt;
                            grid.DataBind();

                     //       return dt;
                       

                        }
                        else
                        {
                         Alert.Show("文件上传失败","错误",MessageBoxIcon.Error);
                   //         return null;
                        }
                        // FileUpload1.PostedFile.SaveAs(path + newname);


                        //Session["filename"] = newname;
             

                        //lab_upload.Text = "上传成功";
                    }
                    catch (Exception ex)
                    {
                        Alert.Show("文件上传失败", "错误", MessageBoxIcon.Error);
                 //       return null;
                        throw ex;
                        
                    }
                }
            }
            else
            {
                //尚未选择文件
                Alert.Show("尚未选择任何文件，请选择文件", "错误", MessageBoxIcon.Error);
               
            //    return null ;
            }
         //   return dt;
        }

       /* public bool ImportExcel(string form)
        {
            string UserID = Session["UserID"].ToString();

            string size = System.Web.HttpContext.Current.Request.Files[0].ContentLength.ToString();//文件大小
            string type = System.Web.HttpContext.Current.Request.Files[0].ContentType;//文件类型
            string _name = System.Web.HttpContext.Current.Request.Files[0].FileName;//原文件名
            string name = UserID + "_" + DateTime.Now.ToString("yyyyMMdd") + "_" + _name.Substring(_name.LastIndexOf("."));//文件名字
            string path = Server.MapPath("~/Areas/Import/res/Import/") + name; //服务器端保存路径
            if (Convert.ToInt32(size) > 2097152)
            {
                //ViewBag.msg = "上传失败文件大于2m";
                Alert.Show("上传失败。文件大于2M");
                return View();//上传失败页面
            }

            if (type == "application/vnd.ms-excel" || type == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                HttpPostedFileBase files = Request.Files[0];
                files.SaveAs(path);

                //处理Excel 返回DateTable
                //ImportExcelToDataTable(name);
                return PartialView("_StudentInfo", DateTableToList(ImportExcelToDataTable(name)));
            }
            else
            {
                return null;
            }
        }
        */
    }
}
using System;
using System.Data.SqlClient;
using FineUI;

namespace WHMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                
                Common.close();//确保数据库连接关闭
                //重置所有关键字符的值
                Common.State = "";
                Common.ID = "";
                Common.Name="";
                Common.Sid = "";
                if (Common.IsLogin)
                {
                    Alert.Show("请正常登陆！", "警告", MessageBoxIcon.Warning);
                }
             
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sqlstr = "select State from Account where StuID = '"+ tbxStuID.Text+"'";
            Common.Open();
            SqlDataReader re = Common.ExecuteRead(sqlstr);
            if(re.Read())
            {
                Common.State = re.GetString(re.GetOrdinal("State"));
            }
            Common.close();

            string sqlStr = "select * from Account where StuID='" + tbxStuID.Text + "'";
            Common.Open();
            SqlDataReader reader = Common.ExecuteRead(sqlStr);
            if (reader.Read())
            {
                string dbpassword = reader.GetString(reader.GetOrdinal("Password"));
                if (tbxPassword.Text == dbpassword)
                {
                    Alert.ShowInTop("成功登录！","提示",MessageBoxIcon.Information);
                    Common.close();
                    Common.ID = tbxStuID.Text;//绑定登陆者ID
                    Response.Redirect("Default_f.aspx");
                }
                else
                {
                    Common.close();
                    Alert.ShowInTop("用户名或密码错误！", "错误", MessageBoxIcon.Error);
                }
            }
            else
            {
                Alert.ShowInTop("输入的用户名不存在！","错误",MessageBoxIcon.Error);
                Common.close();
            }
        }

    
    }
}
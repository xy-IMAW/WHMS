using System;
using FineUI;
using System.Data.SqlClient;

namespace WHMS
{
    public partial class fineUI_Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Response.Redirect("http://sso.jwc.whut.edu.cn/Certification//login.do");///test
                Common.Sid = "";
                #region 
              
                Common.checklogin("/Login.aspx");
             //   btnPasswordUpdate.OnClientClick = window1.GetShowReference("Account/PasswordUpdate.aspx", "修改密码");
                if (Common.State != "超级管理员")
                {
                    HandlerName();
                    handler.Text = Common.Name;
                }
                else
                {
                    handler.Text = "超级管理员/Administrator";
                }
                #endregion
                
            }

        }
        #region event
        //根据权限加载菜单
        protected void leftMenuTree_Load(object sender, EventArgs e)
        {
            //设置各功能节点
            TreeNode node1 = new TreeNode();//账户管理 0
            TreeNode node2 = new TreeNode();//学生信息管理 0,1,2
            TreeNode node3 = new TreeNode();//工时查询 0,1,2
            TreeNode node4 = new TreeNode();//活动管理 0
            if (Common.State == "超级管理员")
            {
                node1.Text = "权限管理";
                node1.NavigateUrl = "~/Account/Account.aspx";

                node2.Text = "学生信息管理";
                node2.NavigateUrl = "~/Infor-Data/Infor.aspx";

                node3.Text = "工时管理";
                node3.NavigateUrl = "~/Infor-Data/Data.aspx";

                node4.Text = "活动管理";
                node4.NavigateUrl = "~/Infor-Data/Program.aspx";
                leftMenuTree.Nodes.Add(node1);
                leftMenuTree.Nodes.Add(node2);
                leftMenuTree.Nodes.Add(node3);
                leftMenuTree.Nodes.Add(node4);

             

                // leftMenuTree.Nodes[0].Nodes[2].NavigateUrl = "~/Account/Account.aspx";
            }
            else if (Common.State == "管理员")
            {
                node2.Text = "学生信息管理";
                node2.NavigateUrl = "~/Infor-Data/Infor.aspx";

                node3.Text = "工时管理";
                node3.NavigateUrl = "~/Infor-Data/Data.aspx";
                node4.Text = "活动管理";
                node4.NavigateUrl = "~/Infor-Data/Program.aspx";

                leftMenuTree.Nodes.Add(node2);
                leftMenuTree.Nodes.Add(node3);
                leftMenuTree.Nodes.Add(node4);
                //  leftMenuTree.Nodes[0].Nodes[2].NavigateUrl = "";
                // leftMenuTree.Nodes[0].Nodes[2].ToolTip = "没有访问权限！";
            }
            else//组织委员界面
            {
                ///todo 组织委员界面
            }
        }

        protected void btnPasswordUpdate_Click(object sender, EventArgs e)
        {
            //  window1.GetShowReference("../Account/PasswordUpdate","修改密码");
        }
        protected void HandlerName()
        {
            string sqlstr = "select StuName from Student where StuID="+Common.ID;
            Common.Open();
            SqlDataReader re = Common.ExecuteRead(sqlstr);
            if (re.Read())
            {
                Common.Name = re.GetString(re.GetOrdinal("StuName"));
            }
            Common.close();
        }
        #endregion
    }
}
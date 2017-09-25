<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WHMS.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>登陆</title>   
</head>   
<body style="background:url(login.jpg)">
    <form id="form1" runat="server">
        <div>
        <f:PageManager ID="PageManager1" runat="server" />
        <f:Window ID="Window1" runat="server" Title="工时统计系统" IsModal="false" EnableClose="false"
            WindowPosition="GoldenSection" Width="350px">
            <Items>
                <f:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" BodyPadding="10px"
                    LabelWidth="60px" ShowHeader="false">
                    <Items>
                        <f:TextBox ID="tbxStuID" Label="学号" Required="true" runat="server">
                        </f:TextBox>
                        <f:TextBox ID="tbxPassword" Label="密码"  Required="true" runat="server" TextMode="Password">
                        </f:TextBox>
                                           
                       
                     
                    </Items>
                </f:SimpleForm>
            </Items>
            <Toolbars>
                <f:Toolbar ID="Toolbar1" runat="server" Position="Bottom" ToolbarAlign="Right">
                    <Items>
                        <f:Button ID="btnLogin" Text="登录" Type="Submit" ValidateForms="SimpleForm1" ValidateTarget="Top"
                            runat="server" OnClick="btnLogin_Click">
                        </f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Window>
             </div>
    </form>
</body>
</html>


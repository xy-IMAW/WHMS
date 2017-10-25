<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassData.aspx.cs" Inherits="WHMS.Infor_Data.ClassData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
                .mypanel {
            text-align: center;
            padding-top: 10px;
            margin-top: 10px;
            border-top: solid 1px #ccc;
        }

            .mypanel .mybutton {
                display: inline-block;
                *display: inline;
                margin-right: 10px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <f:PageManager ID="pagemanager1" runat="server"  EnableFStateValidation="false" />
           <f:panel ID="panel1" runat="server">
            <Toolbars>
                <f:Toolbar ID="tool1" runat="server" ToolbarAlign="Center" CssClass="mypanel" Position="Top">
                    <Items>
                        <f:Button ID="Button2" runat="server" Text="导出"  OnClick="Button2_Click" CssClass="mybutton" />
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                 
                 <f:ContentPanel runat="server" Margin="50,,50,">
                    <div style="align-content:center; align-items:center; text-align:center">
                           <asp:GridView ID="GridView1" runat="server" Width="800px" Caption="工时信息" ShowFooter="true" ShowHeader="true" OnRowCreated="GridView1_RowCreated" >
                               
                           </asp:GridView>
                 
                     
                    </div>                       
                </f:ContentPanel>   
            </Items>
            </f:panel>
           

    </div>
    </form>
</body>
</html>

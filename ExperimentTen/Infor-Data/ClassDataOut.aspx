<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassDataOut.aspx.cs" Inherits="WHMS.Infor_Data.ClassDataOut" %>

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
                </f:Toolbar>
            </Toolbars>
            <Items>
                 
                 <f:ContentPanel runat="server" Margin="50,,50,">
                    <div style="align-content:center; align-items:center; text-align:center">
                           <asp:GridView ID="GridView1" runat="server"  Caption="工时信息" ShowFooter="true" ShowHeader="true" AutoGenerateColumns="true" OnRowCreated="GridView1_RowCreated" EmptyDataText="NO data" >                               
                           </asp:GridView>               
                     
                    </div>                       
                </f:ContentPanel>   
            </Items>
            </f:panel>
           

    </div>
    </form>
</body>
</html>
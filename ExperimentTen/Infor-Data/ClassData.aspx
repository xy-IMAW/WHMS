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
         <div>
            <asp:Button ID="btn1" runat="server" Text="测试" OnClick="Button2_Click" />
        </div>
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
                    <f:Panel ID="panel2" runat="server">
                       <Items>
                           <f:ContentPanel runat="server" Margin="50,,50,"> 
                                  <asp:GridView ID="GridView1" runat="server"  Caption="工时信息" ShowFooter="true" ShowHeader="true" AutoGenerateColumns="true" OnRowCreated="GridView1_RowCreated">                              
                           </asp:GridView>    
                                                                  
                </f:ContentPanel>   
                                        
                    
                       </Items>
                        <Items>
                            <f:Label ID="infor" runat="server" Text="" RegionPosition="Center" Readonly="true" Margin="20px"></f:Label>
                        </Items>
                   </f:Panel>
               </Items>
           
            <Items>                 
             <f:Window ID="window1" Hidden="true" EnableIFrame="true" runat="server" EnableClose="true"  Width="500px" Height="800px" Target="Top"  EnableMaximize="true"></f:Window>
                
            </Items>

            </f:panel>
       
           

    </div>
    </form>
</body>
</html>

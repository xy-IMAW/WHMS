﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowEditDelete.aspx.cs" Inherits="WHMS.ShowEditDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="RegionPanel1" EnableFStateValidation="false" />
        <f:Panel ID="panel1" runat="server" >
        
            <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                     <f:FileUpload ID="FileUpload1" runat="server" Label="文件" />
                       
                        
                        <f:ContentPanel runat="server">
                         
                                      
                        </f:ContentPanel>
                        <f:CPHConnector runat="server">
                               <asp:FileUpload runat="server" ID="fileupload" />
                         <asp:Button ID="Button2" runat="server" OnClick="btn1_Click" Text="上传" />        
                        </f:CPHConnector>
                      
                         <f:Button ID="btn1" runat="server" Text="上传" OnClick="btn1_Click" />  
                            <f:Button ID="btn" runat="server" OnClick="btn_Click" Text="更新" /> 
                <f:Button ID="OUT" runat="server" OnClick="OUT_Click" Text="导出" /> 
                    </Items>
                </f:Toolbar>               
            </Toolbars>
            <Items>
                       <f:Panel ID="panel2" runat="server" ShowBorder="true">
                    <Items>
                          <f:Grid ID="grid" runat="server" >
                              <Columns>
                                  <f:BoundField DataField="学号" runat="server"></f:BoundField>
                                  <f:BoundField DataField="姓名" runat="server"></f:BoundField>
                                  <f:BoundField DataField="班级" runat="server"></f:BoundField>
                                  <f:BoundField DataField="年级" runat="server"></f:BoundField>
                                  <f:BoundField DataField="" runat="server"></f:BoundField>

                              </Columns>
                              </f:Grid>
                          <f:Grid ID="grid2" runat="server" ShowBorder="true" ShowHeader="true"></f:Grid>
                    </Items>
                </f:Panel> 
            </Items>
            <Items>
                <f:ContentPanel runat="server" Margin="50,,50,">
                    <div style="align-content:center; align-items:center; text-align:center">
                           <asp:GridView ID="GridView1" runat="server" Width="800px" Caption="工时信息" ShowFooter="true" ShowHeader="true" OnRowCreated="GridView1_RowCreated" >
                               
                           </asp:GridView>
                 
                        <asp:Table ID="table1" runat="server" Width="70%" GridLines="Both" CellPadding="2" />
                    </div>                       
                </f:ContentPanel>               
            
       
              
                
            </Items>           
        </f:Panel>      
    </div>      
    </form>

</body>
</html>
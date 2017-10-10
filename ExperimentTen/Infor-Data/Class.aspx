﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="WHMS.Infor_Data.Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="RegionPanel1" EnableFStateValidation="false" />
        <f:TabStrip runat="server">
            <Tabs>
                <f:Tab ID="tab1" runat="server">
                    <Items>
                          <f:Panel ID="panel1" runat="server" EnableCollapse="true" ShowHeader="false">
            <Items>
                <f:Panel ID="panel11" runat="server" Title="班级添加" ShowHeader="true" ShowBorder="true">
                    <Toolbars>
                        <f:Toolbar ID="tool1" runat="server">
                            <Items>                                
                                   <f:TextBox ID="txtClassName" runat="server" Label="班级" Text="" ShowRedStar="true" LabelAlign="Right" Required="true" Width="300px"></f:TextBox>                                    
                            </Items>  
                              <Items>
                                 <f:TextBox ID="txtGrade" runat="server" Label="年级" Text="" ShowRedStar="true" LabelAlign="Right" Required="true" Width="300px"></f:TextBox>
                                    <f:Button ID="btnAddClass" Icon="Add" runat="server" Text="新增" OnClick="btnAddClass_Click"></f:Button>
                            </Items>                         
                        </f:Toolbar>
                        <f:Toolbar ID="toolbar2" runat="server">
                         <Items>
                             <f:Button ID="DownLoad" Text="下载模板" Icon="Accept" runat="server" OnClick="DownLoad_Click" ></f:Button>
                              <f:Button ID="Import" Text="导入班级" runat="server" OnClick="Import_Click" ></f:Button>
                            
                         </Items>
                     </f:Toolbar>  
                    </Toolbars>
                </f:Panel>
            </Items>
        </f:Panel>
        <f:Panel ID="panel2" runat="server" EnableCollapse="false" Title="班级信息" ShowHeader="true" ShowBorder="true">            
                 <Toolbars >
                                <f:Toolbar ID="toolbar1" runat="server">
                                    <Items>                                                                          
                                        
                                   <f:DropDownList ID="SelectGrade" runat="server" Label="年级" LabelAlign="Right" ></f:DropDownList>
                                        <f:Button ID="btnSearch" runat="server" Text="查找" Icon="Zoom" OnClick="btnSearch_Click"></f:Button>  
                                        <f:Button ID="btnDeleteClass" Icon="Delete" runat="server" Text="删除" ConfirmTitle="注意" ConfirmIcon="Question" ConfirmText="确认删除？" ConfirmTarget="Self" OnClick="btnDeleteClass_Click"></f:Button>                                     
                                     </Items>
                                </f:Toolbar>
                                       
                    </Toolbars>         
            <Items>
                 <f:Grid ID="Grid3" Height="550px" BoxFlex="1" ShowBorder="false" ShowGridHeader="true"  runat="server" DataKeyNames="Id,Name" EnableRowClickEvent="true">
                           <Columns>
                                <f:TemplateField Width="60px" HeaderText="序号" TextAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </f:TemplateField>
                                <f:BoundField Width="100px"  DataField="Grade" HeaderText="年级" TextAlign="Center" />
                                <f:BoundField Width ="100px" DataField="Class" HeaderText="班级" TextAlign="Center" />                              
                            </Columns>
                  </f:Grid>    
            </Items>
                     
        </f:Panel>        
                    </Items>
                   
                </f:Tab>
                <f:Tab ID="tab2" Hidden="true" runat="server" IFrameUrl="ClassImport.aspx" Title="更新班级">

                </f:Tab>
            </Tabs>
        </f:TabStrip>
       
                                
    </div>
    </form>
</body>
</html>

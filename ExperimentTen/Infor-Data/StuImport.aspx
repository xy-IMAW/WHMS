<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuImport.aspx.cs" Inherits="WHMS.Infor_Data.StuImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">   
    <div>
   
      
        <f:PageManager ID="PageManager1" runat="server" AutoSizePanelID="RegionPanel1" />
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">
            <Items>
               <f:Grid ID="Grid1" runat="server" ShowBorder="true" ShowHeader="true" Title="学生名单导入" AllowPaging="true" PageIndex="0" PageSize="40">
                    
                    <Toolbars>
                        <f:Toolbar runat="server">
                            <Items>
                            <f:FileUpload ID="FL1" runat="server" Label="请选择Excel表"></f:FileUpload>
                            <f:Button ID="btnImport" runat="server" OnClick="btnImport_Click" Text="导入"></f:Button>
                                <f:Button ID="btnDownLoad" runat="server" Text="下载模板" OnClick="btnDownLoad_Click"></f:Button>
                            </Items>                             
                        </f:Toolbar>                       
                    </Toolbars>
              <Columns>
                   <f:TemplateField Width="60px">
                       <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                        </ItemTemplate>
                    </f:TemplateField>
                  <f:TemplateField >
                      <ItemTemplate>
                          <asp:GridView ID="Gridview" runat="server" PageIndex="0" AllowPaging="true" PageSize="50" >
                            
                          </asp:GridView>
                      </ItemTemplate>
                  </f:TemplateField>
                    <f:BoundField Width="250px" DataField="StuID" HeaderText="学号" TextAlign="Center"/>
                    <f:BoundField Width="100px" DataField="StuName" HeaderText="姓名" TextAlign="Center"/>
                    <f:BoundField Width="150px" DataField="Class" HeaderText="班级" TextAlign="Center"/>
                    <f:BoundField Width="100px" DataField="Grade" HeaderText="年级" TextAlign="Center"/>
              </Columns>
            </f:Grid>
           </Items>
        </f:Panel>
    </div>
    </form>
</body>
</html>

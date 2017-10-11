<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StuImport.aspx.cs" Inherits="WHMS.Infor_Data.StuImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <style>
        .tool1 
        {
            text-align:center;
           align-content:center;
           margin:50px,0,50px,0;
        }
    </style>
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
                                <f:Button ID="btnDownLoad" runat="server" Text="下载模板" OnClick="btnDownLoad_Click"></f:Button>
                            </Items>                             
                        </f:Toolbar>        
                            <f:Toolbar ID="tool1" runat="server" CssClass="tool1">
                    <Items>
                           <f:CPHConnector runat="server" >
                               <asp:FileUpload runat="server" ID="fileupload"  CssClass="tool1"/>
                         <asp:Button ID="Button2" runat="server" OnClick="btn1_Click" Text="上传" />        
                        </f:CPHConnector>
                    </Items>
                </f:Toolbar>               
                    </Toolbars>       
            </f:Grid>
           </Items>
                     <Items>
                <f:ContentPanel runat="server" Margin="50,,50,">
                    <div style="align-content:center; align-items:center; text-align:center">
                           <asp:GridView ID="GridView1" runat="server" />
                 
                        <asp:Table ID="table1" runat="server" Width="70%" GridLines="Both" CellPadding="2" />
                    </div>                       
                </f:ContentPanel>               
                <f:Button ID="btn" runat="server" OnClick="btn_Click" Text="更新" CssClass="tool1" />   
                <f:Grid ID="Grid" runat="server" />
                
            </Items>   
        </f:Panel>
    </div>
    </form>
</body>
</html>

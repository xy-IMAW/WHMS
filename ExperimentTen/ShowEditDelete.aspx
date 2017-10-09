<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowEditDelete.aspx.cs" Inherits="WHMS.ShowEditDelete" %>

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
                    <%--   <f:FileUpload ID="FileUpload" runat="server" Label="文件" />--%>  
                       
                        
                        <f:ContentPanel runat="server">
                         
                                      
                        </f:ContentPanel>
                        <f:CPHConnector runat="server">
                               <asp:FileUpload runat="server" ID="fileupload" />
                         <asp:Button ID="Button2" runat="server" OnClick="btn1_Click" Text="上传" />        
                        </f:CPHConnector>
                       <%--     <f:Button ID="btn" runat="server" Text="上传" OnClick="btn1_Click" />--%>    
                    </Items>
                </f:Toolbar>               
            </Toolbars>
            <Items>
                <f:ContentPanel runat="server" Margin="50,,50,">
                    <div style="align-content:center; align-items:center; text-align:center">
                           <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageIndex="0" PageSize="50" />
                        <asp:Table ID="table1" runat="server" Width="70%" GridLines="Both" CellPadding="2" />
                    </div>                       
                </f:ContentPanel>               
                <f:Button ID="btn" runat="server" OnClick="btn_Click" Text="更新" />   
                <f:Grid ID="Grid" runat="server" />
                
            </Items>           
        </f:Panel>      
    </div>      
    </form>

</body>
</html>
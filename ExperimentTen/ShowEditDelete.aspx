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
                        <f:FileUpload ID="FileUpload" runat="server" />
                        <f:Button ID="btn1" runat="server" Text="test1" OnClick="btn1_Click" />
                        <f:Button ID="btn2" runat="server" Text="test2" OnClick="btn2_Click" />
                        <f:Button ID="btn3" runat="server" Text="test3" OnClick="btn3_Click" />
                        <f:ContentPanel runat="server">
                             <asp:Button ID="Button1" runat="server" OnClick="btn1_Click" Text="上传1" />
                              <asp:Button ID="Button2" runat="server" OnClick="btn2_Click" Text="上传2" />
                              <asp:Button ID="Button3" runat="server" OnClick="btn3_Click" Text="上传3" />
                        </f:ContentPanel>
                    </Items>
                </f:Toolbar>               
            </Toolbars>
            <Items>
                <f:ContentPanel runat="server" >
                          <asp:GridView ID="GridView1" runat="server" />
                </f:ContentPanel>         
            <f:Grid ID="Grid1" runat="server" />
            </Items>           
        </f:Panel>
       
    </div>      
        <div>
             <asp:GridView ID="gridview" runat="server"></asp:GridView>
        </div>
    </form>

</body>
</html>
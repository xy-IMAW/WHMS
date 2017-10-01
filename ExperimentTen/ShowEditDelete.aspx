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
                <f:Toolbar ID="tool1" runat="server">
                    <Items>
                        <f:Button ID="download" Icon="Accept" OnClick="Button2_Click" runat="server"></f:Button>
                      
                    </Items>
                </f:Toolbar>
                <f:Toolbar ID="tool2" runat="server">
                    <Items>
                     
                        <f:FileUpload ID="FileLoad" runat="server"></f:FileUpload>
                          <f:Button ID="Import" Icon="PageWhiteExcel" OnClick="Button1_Click" runat="server"></f:Button>
                    </Items>
                </f:Toolbar>
            </Toolbars>
        </f:Panel>
       
    </div>      
        <div>
             <asp:GridView ID="gridview" runat="server"></asp:GridView>
        </div>
    </form>

</body>
</html>
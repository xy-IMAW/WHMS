<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WHMS.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
 
        
        <div>
            <f:PageManager runat="server" />

         
            <f:Panel runat="server">
                <Toolbars>
                    <f:Toolbar runat="server">
                        <Items>
                            <f:FileUpload ID="fileupload" runat="server" Label="上传"></f:FileUpload>
                            <f:Button ID="btn2" Text="test1" OnClick="btn1_Click" runat="server"></f:Button>
                              <f:Button ID="Button2" Text="test2" OnClick="btn2_Click" runat="server"></f:Button>
                              <f:Button ID="Button3" Text="test3" OnClick="btn3_Click" runat="server"></f:Button>
                              <f:Button ID="Button4" Text="test4" OnClick="btn4_Click" runat="server"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:ContentPanel runat="server" BodyPadding="100px" RegionPosition="Center" >
                         <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated"/>
                    </f:ContentPanel>
                    <f:Grid ID="grid" runat="server" ShowBorder="true" />
                </Items>
            </f:Panel>
   
        </div>
    </form>
</body>
</html>

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
              <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button1" runat="server" OnClick="btnupload1_Click" Text="上传1" />
           <asp:Button ID="Button5" runat="server" OnClick="btnupload2_Click" Text="上传2" />
           <asp:Button ID="Button6" runat="server" OnClick="btnupload3_Click" Text="上传3" />
           <asp:Button ID="Button7" runat="server" OnClick="btnupload4_Click" Text="上传4" />
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Image ID="Image1" runat="server" Visible="False" />
                <asp:Label ID="fileUrl" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="fileName" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="filesize" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" BorderStyle="Solid" BorderColor="Silver" ToolTip="132" >
        </asp:GridView>
    </div>
        
        <div>
            <f:PageManager runat="server" />

         
            <f:Panel runat="server">
                <Toolbars>
                    <f:Toolbar runat="server">
                        <Items>
                            <f:FileUpload ID="fileupload" runat="server" Label="上传" ></f:FileUpload>
                            <f:Button ID="btn2" Text="test1" OnClick="btn1_Click" runat="server"></f:Button>
                              <f:Button ID="Button2" Text="test2" OnClick="btn2_Click" runat="server"></f:Button>
                              <f:Button ID="Button3" Text="test3" OnClick="btn3_Click" runat="server"></f:Button>
                              <f:Button ID="Button4" Text="test4" OnClick="btn4_Click" runat="server"></f:Button>
                        </Items>
                    </f:Toolbar>
                </Toolbars>
                <Items>
                    <f:ContentPanel runat="server">
                         <asp:GridView ID="Grid2" runat="server"></asp:GridView>
                    </f:ContentPanel>
                    <f:Grid ID="grid" runat="server" ShowBorder="true" >

                    </f:Grid>
                </Items>
            </f:Panel>
   
        </div>
    </form>
</body>
</html>

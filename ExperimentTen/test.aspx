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
                <asp:Button ID="Button1" runat="server" OnClick="btnupload_Click" Text="上传" />

               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Image ID="Image1" runat="server" Visible="False" />
                <asp:Label ID="fileUrl" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="fileName" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="filesize" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
        <asp:GridView ID="GridView1" runat="server" BorderStyle="Solid" BorderColor="Silver" ToolTip="132" >
        </asp:GridView>
    </form>
</body>
</html>

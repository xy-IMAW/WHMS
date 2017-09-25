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
             <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传" />

               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <br />
      
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    </div>
        <asp:Button ID="Button2" runat="server" Text="下载模板" OnClick="Button2_Click" />
        <asp:GridView ID="GridView1" runat="server" BorderStyle="Solid" BorderColor="Silver" ToolTip="132" >
        </asp:GridView>
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeData.aspx.cs" Inherits="WHMS.Infor_Data.GradeData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <f:PageManager ID="pagemanager1" runat="server" />
        <f:panel ID="panel1" runat="server">
            <Toolbars>
                <f:Toolbar ID="tool1" runat="server">
                    <Items>
                        <f:DropDownList ID="DL1" runat="server" Label="年级" >
                                </f:DropDownList>
                         <f:DropDownList ID="DL2" runat="server" Label="学年" >
                                </f:DropDownList>
                                <f:DropDownList ID="DL3" runat="server" Label="学期" >
                                </f:DropDownList>
                        <f:Button ID="btn" runat="server" Text="查看" OnClick="btn_Click"/>
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                   <f:ContentPanel runat="server" Margin="50,,50,">
                    <div style="align-content:center; align-items:center; text-align:center">               
                        <asp:Table ID="table1" runat="server" Width="70%" GridLines="Both" CellPadding="2" />
                    </div>                       
                </f:ContentPanel>     
            </Items>
            </f:panel>
    </div>
    </form>
</body>
</html>

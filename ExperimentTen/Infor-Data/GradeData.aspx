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
                        <f:Button ID="Button2" runat="server" Text="导出" OnClick="Button2_Click" />
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                   <f:CPHConnector runat="server">
                       <div style="align-content:center; align-items:center; text-align:center">   
                          <asp:GridView ID="GridView1" runat="server" Width="800px" Caption="" ShowFooter="true" ShowHeader="true" OnRowCreated="GridView1_RowCreated"  >
                               
                           </asp:GridView>            
                        <asp:Table ID="table1" runat="server" Width="70%" GridLines="Both" CellPadding="2" />
                    </div>  

                      </f:CPHConnector>   
            </Items>
            </f:panel>
        <f:Window ID="window1" Hidden="true" EnableIFrame="true" runat="server" EnableClose="true"  Width="800px" Height="600px" Target="Top"  EnableMaximize="true" ></f:Window>
    </div>
    </form>
</body>
</html>

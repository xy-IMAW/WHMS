<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Program.aspx.cs" Inherits="WHMS.Infor_Data.Program" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <f:PageManager ID="PageManager_01" AutoSizePanelID="panelMain" runat="server" />
        <f:Panel ID="panelMain" runat="server" ShowBorder="false" ShowHeader="false" EnableCollapse="true" Layout="Fit">
            <Items>
                <f:Grid ID="gridExample" Title="活动信息管理" ShowBorder="true" AllowPaging="true" ShowHeader="true"
                    DataKeyNames="ID" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="10"  PageIndex="0" OnPageIndexChange="gridExample_PageIndexChange"
                    EnableMultiSelect="false"  runat="server">
                    <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:DropDownList ID="DDL" runat="server" Label="年份" LabelAlign="Right" Width="80px" >
                                    
                                </f:DropDownList>
                                <f:Button ID="btnSearch" Text="查看" Icon="Zoom" runat="server" OnClick="btnSearch_Click"></f:Button>
                                <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server" OnClick="btnAdd_Click" >
                                </f:Button>
                                <f:Button ID="btnDelete" Text="删除" Icon="Delete" runat="server" OnClick="btnDelete_Click">
                                </f:Button>                                                       
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:TemplateField Width="80px">
                            <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField Width="100px" ColumnID="Program" SortField="Program" DataField="Program"
                                    TextAlign="Center" HeaderText="活动"></f:BoundField>
                          <f:BoundField Width="100px" ColumnID="Year" SortField="Year" DataField="Year"
                                    TextAlign="Center" HeaderText="年份"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Date" SortField="Date" DataField="Date"
                                    TextAlign="Center" HeaderText="日期"></f:BoundField>
                      
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        <f:Window ID="window1" Title="添加管理员"  EnableCollapse="true" Hidden="true" EnableIFrame="true"  CloseAction="HidePostBack" EnableMaximize="true"
            EnableResize="true" EnableClose="true" OnClose="window1_Close"  Target="Top" IsModal="true" Width="850px" Height="450px" runat="server">
        </f:Window>
    </form>
</body>
</html>

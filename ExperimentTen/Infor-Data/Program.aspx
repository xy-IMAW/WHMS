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
        <f:Panel ID="panel1" runat="server" ShowBorder="true" ShowHeader="true" EnableCollapse="true" Title="活动添加">
            <Items>
                <f:Form ID="form2" runat="server" BodyPadding="5px">
                    <Rows>
                        <f:FormRow>
                            <Items>
                                <f:TextBox ID="txtProgram" Text="" Label="活动名" LabelAlign="Right" runat="server" Required="true" Width="80px"></f:TextBox>
                                <f:DropDownList ID="selectSy" Label="学年" LabelAlign="Right" runat="server" Required="true" Width="100px"></f:DropDownList>
                                  <f:DropDownList ID="selectSe" Label="学期" LabelAlign="Right" runat="server" Required="true" Width="100px"></f:DropDownList>
                            </Items>
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                <f:DatePicker ID="date" Label="日期" LabelAlign="Right" runat="server" Required="true"></f:DatePicker>
                            </Items> 
                        </f:FormRow>
                        <f:FormRow>
                            <Items>
                                 <f:Button ID="btnAdd" Text="新增" Icon="Add" runat="server" OnClick="btnAdd_Click" >
                                </f:Button>
                            </Items>
                        </f:FormRow>
                    </Rows>
                </f:Form>
            </Items>
            </f:Panel>
        <f:Panel ID="panel2" runat="server" ShowBorder="true" ShowHeader="true" EnableCollapse="true" Layout="Fit" Title="活动信息">
              <Toolbars>
                        <f:Toolbar ID="toolbar_01" runat="server">
                            <Items>
                                <f:DropDownList ID="DDL" runat="server" Label="学期" LabelAlign="Right" Width="80px" >
                                    
                                </f:DropDownList>
                                <f:Button ID="btnSearch" Text="查看" Icon="Zoom" runat="server" OnClick="btnSearch_Click"></f:Button>
                               
                                <f:Button ID="btnDelete" Text="删除" Icon="Delete" runat="server" OnClick="btnDelete_Click">
                                </f:Button>                                                       
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
            <Items>
                <f:Grid ID="gridExample" ShowBorder="false" AllowPaging="true" ShowHeader="false"
                    DataKeyNames="ID" EnableCollapse="false" EnableCheckBoxSelect="true" PageSize="10"  PageIndex="0" OnPageIndexChange="gridExample_PageIndexChange"
                    EnableMultiSelect="false"  runat="server">
                  
                    <Columns>
                        <f:TemplateField Width="80px">
                            <ItemTemplate>
                               <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                        </f:TemplateField>
                        <f:BoundField Width="100px" ColumnID="Program" SortField="Program" DataField="Program"
                                    TextAlign="Center" HeaderText="活动"></f:BoundField>
                          <f:BoundField Width="100px" ColumnID="SySe" SortField="SySe" DataField="SySe"
                                    TextAlign="Center" HeaderText="学期"></f:BoundField>
                        <f:BoundField Width="120px" ColumnID="Date" SortField="Date" DataField="Date"
                                    TextAlign="Center" HeaderText="日期"></f:BoundField>
                      
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>
        
    </form>
</body>
</html>

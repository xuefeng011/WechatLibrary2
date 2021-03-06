﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>本地菜单管理</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="<%="../../ViewModels/LocalMenu/indexViewModel.js?ticks="+DateTime.Now.Ticks %>"></script>
    <ext:Store runat="server" ID="storeFirstMenu" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/LocalMenuService/GetLocalFirstMenu.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                    <ext:ModelField runat="server" Name="name"></ext:ModelField>
                    <ext:ModelField runat="server" Name="type"></ext:ModelField>
                    <ext:ModelField runat="server" Name="key"></ext:ModelField>
                    <ext:ModelField runat="server" Name="url"></ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Store runat="server" ID="storeSecondMenu" IDMode="Explicit" AutoLoad="False">
        <Proxy>
            <ext:AjaxProxy Url="/Service/LocalMenuService/GetLocalSecondMenu.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                    <ext:ModelField runat="server" Name="name"></ext:ModelField>
                    <ext:ModelField runat="server" Name="type"></ext:ModelField>
                    <ext:ModelField runat="server" Name="key"></ext:ModelField>
                    <ext:ModelField runat="server" Name="url"></ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Region="Center" Layout="HBoxLayout">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Stretch" />
                </LayoutConfig>
                <Items>
                    <ext:Panel runat="server" Title="一级菜单按钮" Flex="1" TitleAlign="Center">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeFirstMenu">
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="Name" DataIndex="name" Hideable="False" Resizable="False">
                                        </ext:Column>
                                        <ext:CommandColumn runat="server" Width="150" Resizable="False">
                                            <Commands>
                                                <%--<ext:GridCommand Icon="TableEdit" Text="修改" CommandName="modify">
                                                    <ToolTip Text="修改"></ToolTip>
                                                </ext:GridCommand>--%>
                                                <ext:GridCommand Icon="Delete" Text="删除" CommandName="delete">
                                                    <ToolTip Text="删除"></ToolTip>
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.firstMenuCommandClickCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <Listeners>
                                    <CellClick Handler="window.viewModel.firstMenuModifyCommand(arguments)"></CellClick>
                                </Listeners>
                            </ext:GridPanel>
                        </Items>
                        <Buttons>
                            <ext:Button runat="server" Text="添加" Icon="Add">
                                <Listeners>
                                    <Click Handler="window.viewModel.addNewFirstMenuCommand(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" Text="刷新" Icon="PageRefresh">
                                <Listeners>
                                    <Click Handler="window.viewModel.refreshFirstMenu(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="二级菜单按钮" Flex="1" TitleAlign="Center">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeSecondMenu">
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="Name" DataIndex="name" Hideable="False" Resizable="False"></ext:Column>
                                        <ext:CommandColumn runat="server" Width="150" Resizable="False">
                                            <Commands>
                                                <%--<ext:GridCommand Icon="TableEdit" Text="修改" CommandName="modify">
                                                    <ToolTip Text="修改"></ToolTip>
                                                </ext:GridCommand>--%>
                                                <ext:GridCommand Icon="Delete" Text="删除" CommandName="delete">
                                                    <ToolTip Text="删除"></ToolTip>
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.secondMenuCommandClickCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <Listeners>
                                    <CellClick Handler="window.viewModel.secondMenuModifyCommand(arguments)"></CellClick>
                                </Listeners>
                            </ext:GridPanel>
                        </Items>
                        <Buttons>
                            <ext:Button runat="server" Text="添加" Icon="Add">
                                <Listeners>
                                    <Click Handler="window.viewModel.addNewSecondMenuCommand(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" Text="刷新" Icon="PageRefresh">
                                <Listeners>
                                    <Click Handler="window.viewModel.refreshSecondMenu(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="菜单按钮设置" Flex="1" TitleAlign="Center" BodyPadding="10" Layout="FormLayout">
                        <Items>
                            <ext:RadioGroup runat="server" Layout="HBoxLayout" FieldLabel="按钮类型" LabelWidth="50">
                                <LayoutConfig>
                                    <ext:HBoxLayoutConfig runat="server" Align="Top" />
                                </LayoutConfig>
                                <Items>
                                    <ext:Radio runat="server" BoxLabel="None" Margins="0 5 0 5" ID="rdoNone"></ext:Radio>
                                    <ext:Radio runat="server" BoxLabel="Click" Margins="0 5 0 5" ID="rdoClick"></ext:Radio>
                                    <ext:Radio runat="server" BoxLabel="View" Margins="0 5 0 5" ID="rdoView"></ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                            <ext:TextField runat="server" FieldLabel="Name" EmptyText="按钮名字" ID="txtName" LabelWidth="50"></ext:TextField>
                            <ext:TextField runat="server" FieldLabel="Key" EmptyText="Key" ID="txtKey" LabelWidth="50"></ext:TextField>
                            <ext:TextField runat="server" FieldLabel="Url" EmptyText="Url" ID="txtUrl" LabelWidth="50"></ext:TextField>
                        </Items>
                        <Buttons>
                            <ext:Button runat="server" Text="保存修改" Icon="Disk">
                                <Listeners>
                                    <Click Handler="window.viewModel.saveSettingCommand(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
</html>

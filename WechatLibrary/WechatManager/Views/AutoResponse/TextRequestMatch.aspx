<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>文本消息自动回复管理</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="../../ViewModels/AutoResponse/textRequestMatchViewModel.js"></script>
    <ext:Store runat="server" ID="storeTextMatches" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Region="Center">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button runat="server" Text="添加" Icon="Add">
                                <Listeners>
                                    <Click Handler="window.viewModel.addNewWehcatTextRequestMatchCommand(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:GridPanel runat="server" StoreID="storeTextMatches">
                        <ColumnModel runat="server">
                            <Columns>
                                <ext:Column runat="server"></ext:Column>
                                <ext:CommandColumn runat="server">
                                    <Commands>
                                        <ext:GridCommand Text="修改" CommandName="modify"></ext:GridCommand>
                                        <ext:GridCommand Text="删除" CommandName="delete"></ext:GridCommand>
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    <ext:Window runat="server" Hidden="True" ID="addWindow" Title="添加新匹配" CloseAction="Hide" Layout="FormLayout">
        <Items>
            <ext:TextField runat="server" FieldLabel="匹配内容" ID="txt"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="添加">
                <Listeners>
                    <Click Handler="window.viewModel.saveNewWechatTextRequestMatchCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>

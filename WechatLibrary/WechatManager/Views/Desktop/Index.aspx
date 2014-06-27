<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>微信帐号管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="<%="../../ViewModels/Desktop/indexViewModel.js?ticks="+DateTime.Now.Ticks%>">
    </script>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Layout="BorderLayout" Region="Center">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Image runat="server" ImageUrl="http://mp.weixin.qq.com/favicon.ico"></ext:Image>
                            <ext:ToolbarSpacer runat="server" Width="5" />
                            <%--to show which wechat account is login.--%>
                            <ext:Label runat="server" ID="txtCurrentWechatId"></ext:Label>
                            <ext:ToolbarFill runat="server" />
                            <ext:Button runat="server" Text="设置" Icon="ApplicationEdit">
                                <Listeners>
                                    <%--setting current wechat account.--%>
                                    <Click Handler="window.viewModel.showSettingWindowCommand(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                            <ext:Button runat="server" Text="登出" Icon="ApplicationDelete">
                                <Listeners>
                                    <%--logout current wechat account.--%>
                                    <Click Handler="window.viewModel.logoutCommand(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:MenuPanel runat="server" Region="West" Width="170" Split="True">
                        <Menu runat="server">
                            <Items>
                                <ext:MenuItem runat="server" Text="本地微信菜单配置" Icon="ApplicationForm">
                                    <Listeners>
                                        <Click Handler="window.viewModel.localWechatMenuSettingCommand(arguments)"></Click>
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem runat="server" Text="微信服务器菜单管理" Icon="Computer">
                                    <Listeners>
                                        <Click Handler="window.viewModel.wechatServerMenuManageCommand(arguments)"></Click>
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem runat="server" Text="回复资源管理" Icon="PageBack">
                                    <Listeners>
                                        <Click Handler="window.viewModel.autoResponseResultManageCommand(arguments)"></Click>
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem runat="server" Text="文本消息自动回复" Icon="ShapeMoveBack">
                                    <Listeners>
                                        <Click Handler="window.viewModel.textMessageAutoResponseCommand(arguments)"></Click>
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem runat="server" Text="消息记录浏览" Icon="Note">
                                    <Listeners>
                                        <Click Handler="window.viewModel.messageLogCommand(arguments)"></Click>
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem runat="server" Text="消息群发" Icon="Group">
                                    <Listeners>
                                        <Click Handler="window.viewModel.groupSendCommand(arguments)"></Click>
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                        </Menu>
                    </ext:MenuPanel>
                    <ext:Panel runat="server" Region="Center" Split="True" ID="pnlMain">
                        <Loader runat="server" AutoLoad="false" Mode="Frame" DisableCaching="true">
                        </Loader>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>

    <ext:Window runat="server" Title="微信帐号设置" Layout="FormLayout" CloseAction="Hide" BodyPadding="10" Padding="10" Modal="True" Hidden="True" ID="winWechatAccountSetting" Icon="DatabaseEdit" Width="450">
        <Items>
            <ext:TextField runat="server" ID="txtAppId" EmptyText="AppId" FieldLabel="AppId" AnchorHorizontal="100%" AllowBlank="False"></ext:TextField>
            <ext:TextField runat="server" ID="txtSecret" EmptyText="Secret" FieldLabel="Secret" AnchorHorizontal="100%" AllowBlank="False"></ext:TextField>
            <ext:TextField runat="server" ID="txtToken" EmptyText="Token" FieldLabel="Token" AnchorHorizontal="100%" AllowBlank="False"></ext:TextField>
            <ext:TextField runat="server" ID="txtWechatId" EmptyText="WechatId" FieldLabel="WechatId" AnchorHorizontal="100%" AllowBlank="False"></ext:TextField>
            <ext:TextField runat="server" ID="txtNamespace" EmptyText="Namespace" FieldLabel="Namespace" AnchorHorizontal="100%"></ext:TextField>
            <ext:RadioGroup runat="server" Layout="HBoxLayout" FieldLabel="账号类型">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig runat="server" Align="Top" />
                </LayoutConfig>
                <Items>
                    <ext:Radio runat="server" BoxLabel="订阅号" Margins="0 5 0 5" ID="rdoNotServerAccount"></ext:Radio>
                    <ext:Radio runat="server" BoxLabel="服务号" Margins="0 5 0 5" ID="rdoServerAccount"></ext:Radio>
                </Items>
            </ext:RadioGroup>
        </Items>
        <Listeners>
            <Show Handler="window.viewModel.loadCurrentWechatAccountCommand(arguments)">
            </Show>
        </Listeners>
        <Buttons>
            <ext:Button runat="server" Text="保存" Icon="DatabaseSave" Width="100">
                <Listeners>
                    <Click Handler="window.viewModel.wechatSettingSaveCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>

<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>微信服务器菜单管理</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="../../ViewModels/WechatServerMenu/indexViewModel.js"></script>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Layout="VBoxLayout">
                <LayoutConfig>
                    <ext:VBoxLayoutConfig Align="Left"></ext:VBoxLayoutConfig>
                </LayoutConfig>
                <Items>
                    <ext:Button runat="server" Text="推送本地菜单到微信服务器" Width="250" Height="150" IconAlign="Top" Icon="Email">
                        <Listeners>
                            <Click Handler="window.viewModel.postLocalMenuToWechatServerCommand(arguments)"></Click>
                        </Listeners>
                    </ext:Button>
                    <ext:Button runat="server" Text="加载微信服务器配置菜单到本地" Width="250" Height="150" IconAlign="Top" Icon="DiskDownload">
                        <Listeners>
                            <Click Handler="window.viewModel.copyWechatServerMenuToLocalCommand(arguments)"></Click>
                        </Listeners>
                    </ext:Button>
                    <ext:Button runat="server" Text="删除微信服务器上的菜单" Width="250" Height="150" IconAlign="Top" Icon="Delete">
                        <Listeners>
                            <Click Handler="window.viewModel.deleteWechatServerMenuCommand(arguments)"></Click>
                        </Listeners>
                    </ext:Button>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
</html>

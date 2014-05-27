<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

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
    <script src="../../ViewModels/LocalMenu/indexViewModel.js"></script>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Layout="ColumnLayout" Region="Center" ID="pp" ManageHeight="True">
                <Items>
                    <ext:Panel runat="server" ColumnWidth="0.2" Title="a" ID="ppp" ManageHeight="True">
                        <Buttons>
                            <ext:Button runat="server" Text="fagfaga"></ext:Button>
                        </Buttons>
                    </ext:Panel>
                    <ext:Panel runat="server" ColumnWidth="0.2" Title="b"></ext:Panel>
                    <ext:Panel runat="server" ColumnWidth="0.6" Title="c"></ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
</html>

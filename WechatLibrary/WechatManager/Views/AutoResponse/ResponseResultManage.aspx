<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>自动回复资源管理</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="../../ViewModels/AutoResponse/responseResultManageViewModel.js"></script>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:TabPanel runat="server">
                <Items>
                    <ext:Panel runat="server" Title="回复文本消息" Closable="False">
                        <Items></Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="回复图片消息" Closable="False">
                        <Items></Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="回复图文消息" Closable="False">
                        <Items></Items>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</body>
</html>

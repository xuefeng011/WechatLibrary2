<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" ValidateRequest="false"%>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    语音：
    <a href="/MessageLog/ViewVoice?MediaId=<%=ViewBag.MediaId %>">查看</a>
</body>
</html>

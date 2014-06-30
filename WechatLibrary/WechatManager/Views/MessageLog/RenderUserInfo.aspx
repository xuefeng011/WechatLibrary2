<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>用户资料页</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <table>
        <tr>
            <td>OpenId</td>
            <td>昵称</td>
            <td>性别</td>
        </tr>
        <tr>
            <td><%=ViewBag.UserInfo.OpenId %></td>
            <td><%=ViewBag.UserInfo.NickName %></td>
            <td><%=ViewBag.UserInfo.Sex %></td>
        </tr>
    </table>
    <p>
        头像：<img src="<%=ViewBag.UserInfo.HeadImgUrl %>" />
    </p>
</body>
</html>

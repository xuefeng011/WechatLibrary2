<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" ValidateRequest="false" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Import Namespace="WechatLibrary.Model.Message.Response" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
    <style type="text/css">
        .table-b table td {
            border: 1px solid #F00;
        }
    </style>
</head>
<body style="font-size: medium">
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    图文：
    <div class="table-b">
        <table border="0" cellspacing="0" cellpadding="0">
            <tr>
                <th width="70">标题</th>
                <th width="200">内容</th>
                <th width="150">图片</th>
                <th width="50">链接</th>
            </tr>
            <%
                NewsResult newsResult = ViewBag.NewsResult as NewsResult;
                var articles = newsResult.Articles;
                for (int i = 0; i < articles.Count; i++)
                {
            %><tr>
                <td><%=articles[i].Title %></td>
                <td><%=articles[i].Description %></td>
                <td>
                    <img src="<%=articles[i].PicUrl %>" />
                </td>
                <td><a href="<%=articles[i].Url %>">链接</a></td>
            </tr>
            <%
            }
            %>
        </table>
    </div>
</body>
</html>

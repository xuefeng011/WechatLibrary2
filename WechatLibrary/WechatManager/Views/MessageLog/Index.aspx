<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>消息记录页</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="../../ViewModels/MessageLog/indexViewModel.js"></script>
    <ext:Store runat="server">
        <Proxy>
            <ext:AjaxProxy Url="/Service/MessageLogService/GetAll.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="RequestType">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="FromUserName">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="LogTime">
                    </ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Viewport runat="server">
        <Items>
            <ext:GridPanel runat="server" Region="Center">
                <ColumnModel>
                    <Columns>
                        <ext:Column runat="server" DataIndex="RequestType"></ext:Column>
                    </Columns>
                </ColumnModel>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
</body>
</html>

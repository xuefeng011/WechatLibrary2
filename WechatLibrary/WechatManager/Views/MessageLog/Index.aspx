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
    <script src="<%="../../ViewModels/MessageLog/indexViewModel.js?ticks="+DateTime.Now.Ticks %>">
    </script>
    <%--<ext:Store runat="server" ID="storeMessageLog">
        <Proxy>
            <ext:AjaxProxy Url="/Service/MessageLogService/GetAll.ashx" Json="True">
                <Reader>
                    <ext:JsonReader Root="data" TotalProperty="total" />
                </Reader>
            </ext:AjaxProxy>
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
                    <ext:ModelField runat="server" Name="RequestLogTime">
                    </ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>--%>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:GridPanel runat="server" Region="Center">
                <Store>
                    <ext:Store runat="server" RemoteSort="True" PageSize="15">
                        <Proxy>
                            <ext:AjaxProxy Url="/Service/MessageLogService/GetAll.ashx" Json="True">
                                <Reader>
                                    <ext:JsonReader Root="data" TotalProperty="total" />
                                </Reader>
                            </ext:AjaxProxy>
                        </Proxy>
                        <Model>
                            <ext:Model runat="server">
                                <Fields>
                                    <ext:ModelField runat="server" Name="FromUserName">
                                    </ext:ModelField>
                                    <ext:ModelField runat="server" Name="RequestId">
                                    </ext:ModelField>
                                    <ext:ModelField runat="server" Name="RequestType">
                                    </ext:ModelField>
                                    <ext:ModelField runat="server" Name="RequestLogTime">
                                    </ext:ModelField>
                                    <ext:ModelField runat="server" Name="ResponseId">
                                    </ext:ModelField>
                                    <ext:ModelField runat="server" Name="ResponseType">
                                    </ext:ModelField>
                                    <ext:ModelField runat="server" Name="ResponseLogTime">
                                    </ext:ModelField>
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <ColumnModel>
                    <Columns>
                        <ext:Column runat="server" DataIndex="FromUserName" Text="发送消息的用户" Width="100">
                        </ext:Column>
                        <ext:Column runat="server" DataIndex="RequestType" Text="请求消息类型" Width="100">
                        </ext:Column>
                        <ext:Column runat="server" DataIndex="RequestLogTime" Text="记录请求消息时间" Width="200">
                        </ext:Column>
                        <ext:Column runat="server" DataIndex="ResponseType" Text="返回消息类型" Width="100">
                        </ext:Column>
                        <ext:Column runat="server" DataIndex="ResponseLogTime" Text="记录返回消息时间" Width="200">
                        </ext:Column>
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" Mode="Single">
                    </ext:RowSelectionModel>
                </SelectionModel>
                <BottomBar>
                    <ext:PagingToolbar runat="server">
                    </ext:PagingToolbar>
                </BottomBar>
                <Listeners>
                    <CellClick Handler="window.viewModel.showMessageDetailCommand(arguments)">
                    </CellClick>
                </Listeners>
            </ext:GridPanel>
        </Items>
    </ext:Viewport>
    <ext:Window runat="server" ID="winMessageDetail" Modal="True" CloseAction="Hide" Title="消息原文" Hidden="True" Maximized="True" Layout="HBoxLayout" TitleAlign="Center">
        <LayoutConfig>
            <ext:HBoxLayoutConfig runat="server" Align="Stretch">
            </ext:HBoxLayoutConfig>
        </LayoutConfig>
        <Items>
            <ext:Panel ID="pnlRequestMessage" runat="server" Title="请求消息" TitleAlign="Center" Flex="1">
                <Loader runat="server" AutoLoad="False" DisableCaching="True" Mode="Frame">
                    <LoadMask Msg="Loading..." ShowMask="True">
                    </LoadMask>
                </Loader>
            </ext:Panel>
            <ext:Panel ID="pnlResponseResult" runat="server" Title="返回消息" TitleAlign="Center" Flex="1">
                <Loader runat="server" AutoLoad="False" DisableCaching="True" Mode="Frame">
                    <LoadMask Msg="Loading..." ShowMask="True">
                    </LoadMask>
                </Loader>
            </ext:Panel>
        </Items>
    </ext:Window>
</body>
</html>

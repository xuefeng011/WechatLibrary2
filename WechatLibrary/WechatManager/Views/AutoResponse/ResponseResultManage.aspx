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
    <ext:Store runat="server" ID="storeTextMessage" IDMode="Explicit">
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
    <ext:Store runat="server" ID="storeImageMessage" IDMode="Explicit">
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
    <ext:Store runat="server" ID="storeNewsMessage" IDMode="Explicit">
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
            <ext:TabPanel runat="server" Region="Center">
                <Items>
                    <ext:Panel runat="server" Title="回复文本消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server">
                                <ColumnModel>
                                    <Columns>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server"></ext:GridCommand>
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="回复图片消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server">
                                <ColumnModel>
                                    <Columns>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server" Icon="Delete" Text="删除" CommandName="delete"></ext:GridCommand>
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="回复图文消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server">
                                <ColumnModel>
                                    <Columns>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server" Icon="Delete" Text="删除" CommandName="delete"></ext:GridCommand>
                                            </Commands>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
</body>
</html>

<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>消息群发</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="<%="../../ViewModels/GroupSend/indexViewModel.js?ticks="+DateTime.Now.Ticks %>"></script>
    <ext:Store runat="server" ID="storeTextMessage" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetAllTextResult.ashx" Json="True">
            </ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="content">
                    </ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Store runat="server" ID="storeImageMessage" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetAllImageResult.ashx" Json="True">
            </ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="ImgName">
                    </ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Store runat="server" ID="storeVoiceMessage" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetAllVoiceResult.ashx" Json="True">
            </ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="VoiceName">
                    </ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Store runat="server" ID="storeNewsMessage" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetAllNewsResult.ashx" Json="True">
            </ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="Title">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="Content">
                    </ext:ModelField>
                    <ext:ModelField runat="server" Name="Count">
                    </ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:TabPanel runat="server" Region="Center">
                <Items>
                    <ext:Panel runat="server" Title="文本消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeTextMessage">
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="内容" DataIndex="content" Width="200">
                                        </ext:Column>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server" Icon="GroupGo" Text="群发" CommandName="send">
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.textMessageGroupSendCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="图片消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeImageMessage">
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="图片名称" DataIndex="ImgName" Width="200">
                                        </ext:Column>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server" Icon="GroupGo" Text="群发" CommandName="send">
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.imageMessageGroupSendCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="语音消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeVoiceMessage">
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="语音名称" DataIndex="VoiceName" Width="200">
                                        </ext:Column>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server" Icon="GroupGo" Text="群发" CommandName="send">
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.voiceMessageGroupSendCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="图文消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeNewsMessage">
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="第一条标题" DataIndex="Title" Width="200">
                                        </ext:Column>
                                        <ext:Column runat="server" Text="第一条内容" DataIndex="Content" Width="200">
                                        </ext:Column>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server" Icon="GroupGo" Text="群发" CommandName="send">
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.newsMessageGroupSendCommand(arguments)"></Command>
                                            </Listeners>
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

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
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetAllTextResult.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                    <ext:ModelField runat="server" Name="content"></ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Store runat="server" ID="storeImageMessage" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetAllImageResult.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                    <ext:ModelField runat="server" Name="mediaId"></ext:ModelField>
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
                            <ext:GridPanel runat="server" StoreID="storeTextMessage">
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Button runat="server" Text="新增" Icon="Add">
                                                <Listeners>
                                                    <Click Handler="window.viewModel.addNewTextResponseCommand(arguments)"></Click>
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="内容" DataIndex="content"></ext:Column>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server" Icon="NoteEdit" Text="修改" CommandName="modify"></ext:GridCommand>
                                                <ext:GridCommand runat="server" Icon="Delete" Text="删除" CommandName="delete"></ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.textResponseCommandClickCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="回复图片消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeImageMessage">
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Button runat="server" Text="新增" Icon="Add">
                                                <Listeners>
                                                    <Click Handler="window.viewModel.addNewImageResponseCommand(arguments)"></Click>
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
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
    <ext:Window runat="server" Modal="True" Title="添加新文本回复" CloseAction="Hide" Layout="FormLayout" ID="winNewTextMessage" Hidden="True" BodyPadding="8" Icon="Add" Width="300">
        <Items>
            <ext:TextField runat="server" FieldLabel="回复内容" ID="txtNewTextMessageContent" AnchorHorizontal="100%"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="Add" Text="添加">
                <Listeners>
                    <Click Handler="window.viewModel.submitNewTextResponseCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Window runat="server" Modal="True" Title="添加新图片回复" CloseAction="Hide" Layout="FormLayout" ID="winNewImageMessage" Hidden="True" BodyPadding="8" Icon="Add" Width="300">
        <Items>
            <ext:TextField runat="server" FieldLabel="图片MediaId" ID="txtNewImageMessageMediaId" AnchorHorizontal="100%"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="Add" Text="添加">
                <Listeners>
                    <Click Handler="window.viewModel.submitNewImageResponseCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Window runat="server" Modal="True" Title="修改文本回复" CloseAction="Hide" Layout="FormLayout" ID="winModifyTextMessage" Hidden="True">
        <Items>
            <ext:TextField runat="server" FieldLabel="回复内容" ID="txtModifyTextMessageContent" AnchorHorizontal="100%"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="NoteEdit" Text="修改">
                <Listeners>
                    <Click Handler="window.viewModel.submitModifyTextResponseCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>

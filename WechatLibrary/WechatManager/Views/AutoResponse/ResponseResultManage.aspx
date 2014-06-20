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
    <script src="<%= "../../ViewModels/AutoResponse/responseResultManageViewModel.js?ticks="+DateTime.Now.Ticks %>"></script>
    <%--<script src="../../ViewModels/AutoResponse/responseResultManageViewModel.js"></script>--%>
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
                    <ext:ModelField runat="server" Name="ImgName"></ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Store runat="server" ID="storeVoiceMessage" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetAllVoiceResult.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                    <ext:ModelField runat="server" Name="VoiceName"></ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Store runat="server" ID="storeNewsMessage" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetAllNewsResult.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                    <ext:ModelField runat="server" Name="Title"></ext:ModelField>
                    <ext:ModelField runat="server" Name="Content"></ext:ModelField>
                    <ext:ModelField runat="server" Name="Count"></ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Store runat="server" ID="storeNewsArticles" IDMode="Explicit" AutoLoad="False">
        <Proxy>
            <ext:AjaxProxy Url="/Service/AutoResponseService/GetNewsArticels.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                    <ext:ModelField runat="server" Name="Title"></ext:ModelField>
                    <ext:ModelField runat="server" Name="Description"></ext:ModelField>
                    <ext:ModelField runat="server" Name="Url"></ext:ModelField>
                    <ext:ModelField runat="server" Name="PicUrl"></ext:ModelField>
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
                                                <%--<ext:GridCommand runat="server" Icon="NoteEdit" Text="修改" CommandName="modify">
                                                </ext:GridCommand>--%>
                                                <ext:GridCommand runat="server" Icon="Delete" Text="删除" CommandName="delete">
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.textResponseCommandClickCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <Listeners>
                                    <CellClick Handler="window.viewModel.textResponseModifyCommand(arguments)"></CellClick>
                                </Listeners>
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
                                        <ext:Column runat="server" Text="图片名称" DataIndex="ImgName"></ext:Column>
                                        <%--<ext:Column runat="server" Text="图片MediaId" DataIndex="mediaId"></ext:Column>--%>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <%--<ext:GridCommand runat="server" Icon="ImageEdit" Text="修改" CommandName="modify">
                                                </ext:GridCommand>--%>
                                                <ext:GridCommand runat="server" Icon="Image" Text="查看" CommandName="view">
                                                </ext:GridCommand>
                                                <ext:GridCommand runat="server" Icon="Delete" Text="删除" CommandName="delete">
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.imageResponseCommandClickCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="回复语音消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeVoiceMessage">
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Button runat="server" Icon="Add" Text="添加">
                                                <Listeners>
                                                    <Click Handler="window.viewModel.addNewVoiceResponseCommand(arguments)">
                                                    </Click>
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="语音名称" DataIndex="VoiceName"></ext:Column>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <ext:GridCommand runat="server" Icon="DiskDownload" Text="下载" CommandName="download">
                                                </ext:GridCommand>
                                                <ext:GridCommand runat="server" Icon="Delete" Text="删除" CommandName="delete">
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.voiceResponseCommandClickCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <%--<Listeners>
                                    <CellClick Handler="window.viewModel.voiceResponseModifyCommand(arguments)">
                                    </CellClick>
                                </Listeners>--%>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="回复图文消息" Closable="False">
                        <Items>
                            <ext:GridPanel runat="server" StoreID="storeNewsMessage">
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Button runat="server" Icon="Add" Text="添加">
                                                <Listeners>
                                                    <Click Handler="window.viewModel.addNewNewsResponseCommand(arguments)"></Click>
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel>
                                    <Columns>
                                        <ext:Column runat="server" Text="第一条标题" DataIndex="Title"></ext:Column>
                                        <ext:Column runat="server" Text="第一条内容" DataIndex="Content"></ext:Column>
                                        <ext:Column runat="server" Text="条数" DataIndex="Count"></ext:Column>
                                        <ext:CommandColumn runat="server">
                                            <Commands>
                                                <%--<ext:GridCommand runat="server" Icon="Newspaper" Text="修改" CommandName="modify">
                                                </ext:GridCommand>--%>
                                                <ext:GridCommand runat="server" Icon="Delete" Text="删除" CommandName="delete">
                                                </ext:GridCommand>
                                            </Commands>
                                            <Listeners>
                                                <Command Handler="window.viewModel.newsResponseCommandClickCommand(arguments)"></Command>
                                            </Listeners>
                                        </ext:CommandColumn>
                                    </Columns>
                                </ColumnModel>
                                <Listeners>
                                    <CellClick Handler="window.viewModel.newsResponseModifyCommand(arguments)"></CellClick>
                                </Listeners>
                            </ext:GridPanel>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:TabPanel>
        </Items>
    </ext:Viewport>
    <ext:Window runat="server" Modal="True" Title="添加新文本回复" CloseAction="Hide" Layout="FormLayout" ID="winNewTextMessage" Hidden="True" BodyPadding="8" Icon="Add" Width="300">
        <Items>
            <ext:TextArea runat="server" FieldLabel="回复内容" ID="txtNewTextMessageContent" AnchorHorizontal="100%"></ext:TextArea>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="Add" Text="添加">
                <Listeners>
                    <Click Handler="window.viewModel.submitNewTextResponseCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Window runat="server" Modal="True" Title="添加新图片回复" CloseAction="Hide" Layout="FormLayout" ID="winNewImageMessage" Hidden="True" BodyPadding="8" Icon="Add" Width="400">
        <Items>
            <ext:FormPanel runat="server" ID="formNewImageMessage" Method="POST" Url="/Service/AutoResponseService/AddImageResult.ashx">
                <Items>
                    <ext:FileUploadField runat="server" FieldLabel="图片" ID="fileNewImageMessage" AnchorHorizontal="100%" AllowBlank="False">
                    </ext:FileUploadField>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Icon="Add" Text="添加">
                        <Listeners>
                            <Click Handler="window.viewModel.submitNewImageResponseCommand(arguments)">
                            </Click>
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
            <%--<ext:TextField runat="server" FieldLabel="图片Url" ID="txtNewImageMessageUrl" AnchorHorizontal="100%"></ext:TextField>--%>
            <%--<ext:TextField runat="server" FieldLabel="图片MediaId" ID="txtNewImageMessageMediaId" AnchorHorizontal="100%"></ext:TextField>--%>
        </Items>
        <%--<Buttons>
            <ext:Button runat="server" Icon="Add" Text="添加">
                <Listeners>
                    <Click Handler="window.viewModel.submitNewImageResponseCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>--%>
    </ext:Window>
    <ext:Window runat="server" Modal="True" Title="添加新语音回复" CloseAction="Hide" Layout="FormLayout" ID="winNewVoiceMessage" Hidden="True" BodyPadding="8" Icon="Add" Width="400">
        <Items>
            <ext:FormPanel runat="server" Method="POST" ID="formNewVoiceMessage" Url="/Service/AutoResponseService/AddVoiceResult.ashx">
                <Items>
                    <ext:FileUploadField runat="server" FieldLabel="音频文件" LabelWidth="60" ID="fileNewVoiceMessage" AnchorHorizontal="100%" AllowBlank="False"></ext:FileUploadField>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Icon="Add" Text="添加">
                        <Listeners>
                            <Click Handler="window.viewModel.submitNewVoiceResponseCommand(arguments)"></Click>
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
        <Buttons>
        </Buttons>
    </ext:Window>
    <ext:Window runat="server" Modal="True" Title="修改文本回复" CloseAction="Hide" Layout="FormLayout" ID="winModifyTextMessage" Hidden="True" Icon="NoteEdit" Width="300" BodyPadding="8">
        <Items>
            <ext:TextArea runat="server" FieldLabel="回复内容" ID="txtModifyTextMessageContent" AnchorHorizontal="100%"></ext:TextArea>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="NoteEdit" Text="修改">
                <Listeners>
                    <Click Handler="window.viewModel.submitModifyTextResponseCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <%--<ext:Window runat="server" Modal="True" Title="修改图片回复" CloseAction="Hide" Layout="FormLayout" ID="winModifyImageMessage" Hidden="True" Icon="PictureEdit" Width="300" BodyPadding="8">
        <Items>
            <ext:TextField runat="server" FieldLabel="图片MediaId" ID="txtModifyImageMessageMediaId" AnchorHorizontal="100%"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="NoteEdit" Text="修改">
                <Listeners>
                    <Click Handler="window.viewModel.submitModifyImageResponseCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>--%>
    <ext:Window runat="server" Modal="True" Title="添加图文回复" CloseAction="Hide" Layout="FormLayout" ID="winNewNewsMessage" Hidden="True" Width="300" BodyPadding="8" Icon="NewspaperAdd">
        <Items>
            <ext:TextField runat="server" FieldLabel="标题" ID="txtNewNewsMessageTitle" AnchorHorizontal="100%"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="内容" ID="txtNewNewsMessageDescription" AnchorHorizontal="100%"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="跳转链接" ID="txtNewNewsMessageUrl" AnchorHorizontal="100%"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="图片链接" ID="txtNewNewsMessagePicUrl" AnchorHorizontal="100%"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="NewspaperAdd" Text="添加">
                <Listeners>
                    <Click Handler="window.viewModel.submitNewNewsImageResponseCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Window runat="server" Modal="True" Title="修改图文回复" Hidden="True" ID="winModifyNewsMessage" BodyPadding="8" Icon="Newspaper" CloseAction="Hide" Layout="FormLayout" Maximized="True">
        <Items>
            <ext:TextField runat="server" FieldLabel="标题" ID="txtModifyNewsMessageTitle" AnchorHorizontal="100%"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="内容" ID="txtModifyNewsMessageDescription" AnchorHorizontal="100%"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="跳转链接" ID="txtModifyNewsMessageUrl" AnchorHorizontal="100%"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="图片链接" ID="txtModifyNewsMessagePicUrl" AnchorHorizontal="100%"></ext:TextField>
            <ext:GridPanel runat="server" StoreID="storeNewsArticles">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button runat="server" Icon="Add" Text="添加">
                                <Listeners>
                                    <Click Handler="window.viewModel.addNewNewsArticle(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel>
                    <Columns>
                        <ext:Column runat="server" Text="标题" DataIndex="Title"></ext:Column>
                        <ext:Column runat="server" Text="内容" DataIndex="Description"></ext:Column>
                        <ext:Column runat="server" Text="跳转链接" DataIndex="Url"></ext:Column>
                        <ext:Column runat="server" Text="图片链接" DataIndex="PicUrl"></ext:Column>
                        <ext:CommandColumn runat="server">
                            <Commands>
                                <%--<ext:GridCommand runat="server" Icon="NoteEdit" Text="修改" CommandName="modify">
                                </ext:GridCommand>--%>
                                <ext:GridCommand runat="server" Icon="Delete" Text="删除" CommandName="delete">
                                </ext:GridCommand>
                            </Commands>
                            <Listeners>
                                <Command Handler="window.viewModel.gridNewsArticleCommandClickCommand(arguments)"></Command>
                            </Listeners>
                        </ext:CommandColumn>
                    </Columns>
                </ColumnModel>
                <Listeners>
                    <CellClick Handler="window.viewModel.gridNewsArticleModifyCommand(arguments)"></CellClick>
                </Listeners>
            </ext:GridPanel>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="Disk" Text="保存修改">
                <Listeners>
                    <Click Handler="window.viewModel.submitNewsMessageChange(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Window runat="server" Icon="NewspaperAdd" Hidden="True" Modal="True" Title="添加新图文消息项" ID="winAddNewNewsArticle" BodyPadding="8" Layout="FormLayout" Width="300">
        <Items>
            <ext:TextField runat="server" ID="txtNewNewsArticleTitle" AnchorHorizontal="100%" FieldLabel="标题"></ext:TextField>
            <ext:TextField runat="server" ID="txtNewNewsArticleDescription" AnchorHorizontal="100%" FieldLabel="内容"></ext:TextField>
            <ext:TextField runat="server" ID="txtNewNewsArticleUrl" AnchorHorizontal="100%" FieldLabel=" 跳转链接"></ext:TextField>
            <ext:TextField runat="server" ID="txtNewNewsArticlePicUrl" AnchorHorizontal="100%" FieldLabel="图片链接"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="添加" Icon="Add">
                <Listeners>
                    <Click Handler="window.viewModel.submitNewNewsArticle(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Window runat="server" Modal="True" ID="winModifyNewsArticle" Hidden="True" Icon="Newspaper" Layout="FormLayout" Title="修改图文回复项" BodyPadding="5" Width="300">
        <Items>
            <ext:TextField runat="server" FieldLabel="标题" AnchorHorizontal="100%" ID="txtModifyNewsArticleTitle"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="内容" AnchorHorizontal="100%" ID="txtModifyNewsArticleDescription"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="跳转链接" AnchorHorizontal="100%" ID="txtModifyNewsArticleUrl"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="图片链接" AnchorHorizontal="100%" ID="txtModifyNewsArticlePicUrl"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Icon="Disk" Text="保存修改">
                <Listeners>
                    <Click Handler="window.viewModel.submitModifyNewsArticleChange(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>

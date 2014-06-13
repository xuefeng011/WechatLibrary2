<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>文本消息自动回复管理</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="../../ViewModels/AutoResponse/textRequestMatchViewModel.js"></script>
    <ext:Store runat="server" ID="storeTextMatches" IDMode="Explicit">
        <Proxy>
            <ext:AjaxProxy Url="/Service/TextRequestMatchService/GetAll.ashx" Json="True"></ext:AjaxProxy>
        </Proxy>
        <Model>
            <ext:Model runat="server">
                <Fields>
                    <ext:ModelField runat="server" Name="Id"></ext:ModelField>
                    <ext:ModelField runat="server" Name="MatchContent"></ext:ModelField>
                    <ext:ModelField runat="server" Name="MatchOption"></ext:ModelField>
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Region="Center">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button runat="server" Text="添加" Icon="Add">
                                <Listeners>
                                    <Click Handler="window.viewModel.addNewWehcatTextRequestMatchCommand(arguments)"></Click>
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:GridPanel runat="server" StoreID="storeTextMatches">
                        <ColumnModel runat="server">
                            <Columns>
                                <ext:Column runat="server" DataIndex="MatchContent" Text="匹配文本"></ext:Column>
                                <ext:Column runat="server" DataIndex="MatchOption" Text="匹配方式"></ext:Column>
                                <ext:CommandColumn runat="server">
                                    <Commands>
                                        <ext:GridCommand Text="修改" Icon="NoteEdit" CommandName="modify"></ext:GridCommand>
                                        <ext:GridCommand Text="删除" Icon="Delete" CommandName="delete"></ext:GridCommand>
                                    </Commands>
                                    <Listeners>
                                        <Command Handler="window.viewModel.textMatchesCommandClickCommand(arguments)"></Command>
                                    </Listeners>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    <ext:Window runat="server" Hidden="True" ID="addWindow" Title="添加新匹配" CloseAction="Hide" Layout="FormLayout" Modal="True" BodyPadding="5" Icon="Add" Width="300">
        <Items>
            <ext:TextField runat="server" FieldLabel="匹配内容" ID="txtNewTextMatch"></ext:TextField>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="添加" Icon="Add">
                <Listeners>
                    <Click Handler="window.viewModel.saveNewWechatTextRequestMatchCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Window runat="server" ID="modifyWindow" Title="修改文本消息自动匹配" CloseAction="Hide" Layout="FormLayout" Modal="True" BodyPadding="5" Hidden="True" Icon="PageEdit" Width="500" Height="300">
        <Items>
            <ext:TextField runat="server" FieldLabel="匹配内容" ID="txtModifyTextMatchContent" AnchorHorizontal="100%"></ext:TextField>
            <ext:ComboBox runat="server" FieldLabel="匹配方式" ID="cmbModifyTextMatchOption" AnchorHorizontal="100%" Editable="False">
                <Items>
                    <ext:ListItem Text="完全匹配" />
                    <ext:ListItem Text="不区分大小写完全匹配" />
                    <ext:ListItem Text="部分匹配" />
                    <ext:ListItem Text="不区分大小写部分匹配" />
                </Items>
            </ext:ComboBox>
            <ext:TextField runat="server" FieldLabel="匹配等级" ID="txtModifyTextMatchLevel" AnchorHorizontal="100%"></ext:TextField>
            <ext:ComboBox runat="server" FieldLabel="自动回复类型" ID="cmbResponseType" AnchorHorizontal="100%" Editable="False">
                <Items>
                    <ext:ListItem Text="文本" />
                    <ext:ListItem Text="图片" />
                    <ext:ListItem Text="图文" />
                </Items>
                <Listeners>
                    <Select Handler="window.viewModel.cmbResponseTypeSelected(arguments)"></Select>
                </Listeners>
            </ext:ComboBox>
            <%--文本消息资源--%>
            <ext:ComboBox runat="server" FieldLabel="文本消息" ID="cmbResponseTextMessage" AnchorHorizontal="100%" Editable="False" Hidden="True" ValueField="Id" DisplayField="Content"></ext:ComboBox>
            <%--图片消息资源--%>
            <ext:ComboBox runat="server" FieldLabel="图片消息" ID="cmbResponseImageMessage" AnchorHorizontal="100%" Editable="False" Hidden="True"></ext:ComboBox>
            <%--图文消息资源--%>
            <ext:ComboBox runat="server" FieldLabel="图文消息" ID="cmbResponseNewsMessage" AnchorHorizontal="100%" Editable="False" Hidden="True"></ext:ComboBox>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="修改" Icon="NoteEdit">
                <Listeners>
                    <Click Handler="window.viewModel.submitModify(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>

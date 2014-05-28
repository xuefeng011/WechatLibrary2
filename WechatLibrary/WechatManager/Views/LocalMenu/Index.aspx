<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>本地菜单管理</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="../../ViewModels/LocalMenu/indexViewModel.js"></script>
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Region="Center" Layout="HBoxLayout">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig Align="Stretch" />
                </LayoutConfig>
                <Items>
                    <ext:Panel runat="server" Title="一级菜单按钮" Flex="1" TitleAlign="Center">
                        <Items>
                            <ext:GridPanel runat="server">
                            </ext:GridPanel>
                        </Items>
                        <Buttons>
                            <ext:Button runat="server" Text="添加" Icon="Add">
                                <Listeners>
                                    <Click Handler=""></Click>
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="二级菜单按钮" Flex="1" TitleAlign="Center">
                        <Items></Items>
                        <Buttons>
                            <ext:Button runat="server" Text="添加" Icon="Add">
                                <Listeners>
                                    <Click Handler=""></Click>
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                    <ext:Panel runat="server" Title="菜单按钮设置" Flex="1" TitleAlign="Center" BodyPadding="10" Layout="FormLayout">
                        <Items>
                            <ext:RadioGroup runat="server" Layout="HBoxLayout" FieldLabel="按钮类型">
                                <LayoutConfig>
                                    <ext:HBoxLayoutConfig runat="server" Align="Top" />
                                </LayoutConfig>
                                <Items>
                                    <ext:Radio runat="server" BoxLabel="None" Margins="0 5 0 5"></ext:Radio>
                                    <ext:Radio runat="server" BoxLabel="Click" Margins="0 5 0 5"></ext:Radio>
                                    <ext:Radio runat="server" BoxLabel="View" Margins="0 5 0 5"></ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                            <ext:TextField runat="server" FieldLabel="Name" EmptyText="按钮名字"></ext:TextField>
                            <ext:TextField runat="server" FieldLabel="Key" EmptyText="Key"></ext:TextField>
                            <ext:TextField runat="server" FieldLabel="Url" EmptyText="Url"></ext:TextField>
                        </Items>
                        <Buttons>
                            <ext:Button runat="server" Text="保存修改" Icon="Disk">
                                <Listeners>
                                    <Click Handler=""></Click>
                                </Listeners>
                            </ext:Button>
                        </Buttons>
                    </ext:Panel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
</html>

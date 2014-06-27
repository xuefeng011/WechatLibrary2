<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>添加新微信帐号</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="../../ViewModels/Home/addWechatAccountViewModel.js"></script>
    <ext:Window runat="server" Modal="True" Layout="FormLayout" Icon="Add" Title="添加新微信帐号" Width="400" Padding="10" BodyPadding="10">
        <Items>
            <ext:TextField runat="server" FieldLabel="AppId" AnchorHorizontal="100%" ID="txtAppId" AllowBlank="False" EmptyText="AppId"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="Secret" AnchorHorizontal="100%" ID="txtSecret" AllowBlank="False" EmptyText="Secret"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="Token" AnchorHorizontal="100%" ID="txtToken" AllowBlank="False" EmptyText="Token"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="WechatId" AnchorHorizontal="100%" ID="txtWechatId" AllowBlank="False" EmptyText="WechatId"></ext:TextField>
            <ext:TextField runat="server" FieldLabel="Namespace" AnchorHorizontal="100%" ID="txtNamespace" EmptyText="Namespace"></ext:TextField>
            <ext:RadioGroup runat="server" Layout="HBoxLayout" FieldLabel="账号类型">
                <LayoutConfig>
                    <ext:HBoxLayoutConfig runat="server" Align="Top" />
                </LayoutConfig>
                <Items>
                    <ext:Radio runat="server" BoxLabel="订阅号" Margins="0 5 0 5" ID="rdoNotServerAccount" Checked="True">
                    </ext:Radio>
                    <ext:Radio runat="server" BoxLabel="服务号" Margins="0 5 0 5" ID="rdoServerAccount"></ext:Radio>
                </Items>
            </ext:RadioGroup>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="添加" Icon="Add">
                <Listeners>
                    <Click Handler="window.viewModel.addCommand(arguments)"></Click>
                </Listeners>
            </ext:Button>
        </Buttons>
        <Listeners>
            <Close Handler="window.viewModel.closeCommand(arguments)"></Close>
        </Listeners>
    </ext:Window>
</body>
</html>

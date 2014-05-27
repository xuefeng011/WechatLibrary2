<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>微信帐号登录页</title>
    <link rel="shortcut icon" type="image/x-icon" href="http://mp.weixin.qq.com/favicon.ico"
        media="screen" />
</head>
<body>
    <ext:ResourceManager runat="server" Theme="Gray">
    </ext:ResourceManager>
    <script src="../../ViewModels/Home/indexViewModel.js"></script>
    <ext:Window runat="server" Closable="false" Modal="true" Icon="Lock" Width="450"
        Title="登录" Resizable="false" Padding="10" Layout="FormLayout" BodyPadding="10">
        <Items>
            <ext:ComboBox ID="cmbWechatId" runat="server" AnchorHorizontal="100%" FieldLabel="微信 Id" Editable="False" AllowBlank="False" EmptyText="now loading the WechatIds, please wait...">
            </ext:ComboBox>
        </Items>
        <Buttons>
            <ext:Button runat="server" Text="添加新微信帐号" Icon="Add" Width="120">
                <Listeners>
                    <Click Handler="window.viewModel.addCommand(arguments)">
                    </Click>
                </Listeners>
            </ext:Button>
            <ext:Button runat="server" Text="登录" Icon="LockGo" Width="120" ID="btnLogin">
                <Listeners>
                    <Click Handler="window.viewModel.loginCommand(arguments)">
                    </Click>
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
</body>
</html>

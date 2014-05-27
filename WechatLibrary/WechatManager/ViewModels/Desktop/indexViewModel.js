(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            // it will show current wechat id.
            txtCurrentWechatId: Ext.getCmp('txtCurrentWechatId'),
            // the main panel to use other function, like menu setting, auto response.
            pnlMain: Ext.getCmp('pnlMain'),
            // the window to modify current wechat account information.
            winWechatAccountSetting: Ext.getCmp('winWechatAccountSetting'),
            // the controls in setting window.
            txtAppId: Ext.getCmp('txtAppId'),
            txtSecret: Ext.getCmp('txtSecret'),
            txtToken: Ext.getCmp('txtToken'),
            txtWechatId: Ext.getCmp('txtWechatId'),
            txtNamespace: Ext.getCmp('txtNamespace'),
            loadCurrentWechatIdCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Service/WechatAccountService/LoadCurrentWechatId.ashx',
                    method: 'POST',
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            window.viewModel.txtCurrentWechatId.setText(responseObj.wechatId);
                        } else {
                            Ext.Msg.alert('Error', 'please login again!', function () {
                                window.location.href = "/Home/Index";
                            });
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'please login again!', function () {
                            window.location.href = "/Home/Index";
                        });
                    }
                });
            },
            // when click the tool bar setting button, show the setting window.
            showSettingWindowCommand: function (parameters) {
                window.viewModel.winWechatAccountSetting.show();
            },
            // when click the tool bar logout button, navigate to the logout page, it will remove all the session.
            logoutCommand: function (parameters) {
                window.location.href = "/Desktop/Logout";
            },
            localWechatMenuSettingCommand: function (parameters) {
                var pnl = window.viewModel.pnlMain;
                var loader = pnl.loader;
                loader.suspendEvents();
                loader.url = "/LocalMenu/Index";
                pnl.load();
            },
            // when the setting window is showed, load current wechat account information from data base.
            loadCurrentWechatAccountCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Service/WechatAccountService/LoadCurrentWechatAccountInformation.ashx',
                    method: 'POST',
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            var data = responseObj.data;
                            window.viewModel.txtAppId.setRawValue(data.AppId);
                            window.viewModel.txtSecret.setRawValue(data.Secret);
                            window.viewModel.txtToken.setRawValue(data.Token);
                            window.viewModel.txtWechatId.setRawValue(data.WechatId);
                            window.viewModel.txtNamespace.setRawValue(data.Namespace);
                        } else {
                            Ext.Msg.alert('Error', responseObj.info, function () {
                                window.viewModel.winWechatAccountSetting.hide();
                            });
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', '加载信息失败！', function () {
                            window.viewModel.winWechatAccountSetting.hide();
                        });
                    }
                });
            },
            wechatSettingSaveCommand: function (parameters) {
                var appid = window.viewModel.txtAppId.getRawValue();
                var secret = window.viewModel.txtSecret.getRawValue();
                var token = window.viewModel.txtToken.getRawValue();
                var wechatId = window.viewModel.txtWechatId.getRawValue();
                var namespace = window.viewModel.txtNamespace.getRawValue();
                Ext.Ajax.request({
                    url: '/Service/WechatAccountService/SaveWechatAccountSetting.ashx',
                    method: 'POST',
                    params: {
                        AppId: appid,
                        Secret: secret,
                        Token: token,
                        WechatId: wechatId,
                        Namespace:namespace
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.location.href = "/Desktop/Logout";
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'save the change fail!');
                    }
                });
            }
        };
        // load login wechatId after dom ready.
        window.viewModel.loadCurrentWechatIdCommand();
    });
}());
(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            postLocalMenuToWechatServerCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Sevice/WechatServerMenuService/PostLocalWechatMenu.ashx',
                    method: 'POST',
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info);
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', "this program coder: I'm sorry, I think there is something wrong with the network, please check the network and post local wechat menu to wechat server again!");
                    }
                });
            },
            copyWechatServerMenuToLocalCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Service/WechatServerMenuService/CopyWechatServerMenuToLocal.ashx',
                    method: 'POST',
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info);
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'there is a error occurred when copying wechat server menu to local data base!');
                    }
                });
            },
            deleteWechatServerMenuCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '',
                    method: 'POST',
                    success: function (response, options) {
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'delete wechat server menu fail!');
                    }
                });
            }
        };
    });
}());

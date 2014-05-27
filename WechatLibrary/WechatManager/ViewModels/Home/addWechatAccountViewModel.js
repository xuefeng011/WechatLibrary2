(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            txtAppId: Ext.getCmp('txtAppId'),
            txtSecret: Ext.getCmp('txtSecret'),
            txtToken: Ext.getCmp('txtToken'),
            txtWechatId: Ext.getCmp('txtWechatId'),
            txtNamespace: Ext.getCmp('txtNamespace'),
            // check other control value, if validate success, add to the data base and navigate to /home/index.
            addCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Service/WechatAccountService/AddNewWechatAccount.ashx',
                    method: 'POST',
                    params: {
                        AppId: window.viewModel.txtAppId.getValue(),
                        Secret: window.viewModel.txtSecret.getValue(),
                        Token: window.viewModel.txtToken.getValue(),
                        WechatId: window.viewModel.txtWechatId.getValue(),
                        Namespace: window.viewModel.txtNamespace.getValue()
                    },
                    success: function (response, options) {
                        // get response text.
                        var responseText = response.responseText;
                        // deserialize to json.
                        var responseObj = Ext.decode(responseText);
                        // get the background method invoke information.
                        var info = responseObj.info;
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', info, function () {
                                // navigate to /home/index after click the button.
                                window.location.href = "/Home/Index";
                            });
                        } else {
                            Ext.Msg.alert('Error', info);
                        }
                    },
                    failure: function (response, options) {
                        alert(response.responseText);
                        Ext.Msg.alert('Error', '添加失败！');
                    }
                });
            },
            // when close the window, navigate to /home/index.
            closeCommand: function (parameters) {
                window.location.href = "/Home/Index";
            }
        };
    });
}());
(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            // the combobox show the wechatIds.
            cmbWechatId: Ext.getCmp('cmbWechatId'),
            // when the combobox expand, load the wechatIds from data base.
            loadCommand: function (parameters) {
                    Ext.Ajax.request({
                        url: "/Service/WechatAccountService/GetAllWechatId.ashx",
                        method: "POST",
                        success: function (response, options) {
                            // get the response text.
                            var responseText = response.responseText;
                            // deserialize to json.
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                // remove all items in combobox.
                                while (window.viewModel.cmbWechatId.store.getCount() > 0) {
                                    window.viewModel.cmbWechatId.removeByIndex(0);
                                }
                                var list = responseObj.data;
                                // add the list to combobox.
                                for (var i = 0; i < list.length; i++) {
                                    window.viewModel.cmbWechatId.addItem(list[i]);
                                }
                                // expand the combobox after loaded.
                                window.viewModel.cmbWechatId.expand();
                            } else {
                                Ext.Msg.alert("Error","加载失败！");
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert("Error","加载失败！");
                        }
                    });
            },
            // when the button clicked, show the page to add a new wechat account.
            addCommand: function (parameters) {
                window.location.href = "/Home/AddWechatAccount";
            },
            // select the wechatId to login, if success, navigate to the desktop page.
            loginCommand: function (parameters) {
                // get the text which in the combobox.
                var currentWechatId = window.viewModel.cmbWechatId.getRawValue();
                if (currentWechatId == "") {
                    // text is empty, show the messagebox.
                    Ext.Msg.alert('Error', 'please select a WechatId to login!');
                    return;
                }

                Ext.Ajax.request({
                    url: '/Desktop/Login',
                    method: 'POST',
                    params: {
                         wechatId: currentWechatId
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            // login success, navigate to /Desktop/Index.
                            window.location.href = "/Desktop/Index";
                        } else {
                            // login fail, show the reason.
                            Ext.Msg.alert('Error',responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error','login fail!');
                    }
                });
            }
        };
        // execute loadCommand after dom ready.
        window.viewModel.loadCommand();
    });
}());
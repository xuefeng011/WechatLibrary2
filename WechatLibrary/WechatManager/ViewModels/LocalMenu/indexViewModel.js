(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            addNewFirstMenuCommand: function (parameters) {
                var firstMenuCount = storeFirstMenu.getCount();
                if (firstMenuCount >= 3) {
                    Ext.Msg.alert('Error', '一级菜单按钮最多只能有 3 个！');
                    return;
                }
                Ext.Msg.prompt('添加一级菜单按钮', '按钮名称', function (btn, text) {
                    if (btn == "ok") {
                        if (text == "") {
                            Ext.Msg.alert('Error', '菜单按钮名字不能为空！');
                            return;
                        }

                        Ext.Ajax.request({
                            url: '/Service/LocalMenuService/AddNewFirstMenu.ashx',
                            method: 'POST',
                            params: { name: text },
                            success: function (response, options) {
                                var responseText = response.responseText;
                                var responseObj = Ext.decode(responseText);
                                if (responseObj.success) {
                                    Ext.Msg.alert('Success', responseObj.info, function () {
                                        storeFirstMenu.load();
                                    });
                                } else {
                                    Ext.Msg.alert('Error',responseObj.info);
                                }
                            },
                            failure: function (response, options) {
                                Ext.Msg.alert('Error', '添加失败');
                            }
                        });
                    } else {
                        return;
                    }
                });
            },
            addNewSecondMenuCommand: function (parameters) {
            },
            firstMenuCommandClickCommand: function (parameters) {
            },
            secondMenuCommandClickCommand: function (parameters) {
            },
            saveSettingCommand: function (parameters) {
            }
        };
    });
}());

(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            rdoNone: Ext.getCmp('rdoNone'),
            rdoClick: Ext.getCmp('rdoClick'),
            rdoView: Ext.getCmp('rdoView'),
            txtName: Ext.getCmp('txtName'),
            txtKey: Ext.getCmp('txtKey'),
            txtUrl: Ext.getCmp('txtUrl'),
            currentId: "",
            storeFirstMenu: Ext.StoreManager.get('storeFirstMenu'),
            storeSecondMenu: Ext.StoreManager.get('storeSecondMenu'),
            addNewFirstMenuCommand: function (parameters) {
                var firstMenuCount = window.viewModel.storeFirstMenu.getCount();
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
                                        window.viewModel.storeFirstMenu.load();
                                    });
                                } else {
                                    Ext.Msg.alert('Error', responseObj.info);
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
                var secondCount = window.viewModel.storeSecondMenu.getCount();
                if (secondCount >= 5) {
                    Ext.Msg.alert('Error', 'second level menu count must less than 6!');
                    return;
                }

                var currentParentId = window.viewModel.currentId;
                if (currentParentId == "") {
                    Ext.Msg.alert('Error', 'please select a first menu button!');
                    return;
                }

                Ext.Msg.prompt('添加二级菜单按钮', '按钮名称', function (btn, text) {
                    if (btn == "ok") {
                        if (text == "") {
                            Ext.Msg.alert('Error', 'button name could not be empty!');
                            return;
                        } else {
                            Ext.Ajax.request({
                                url: '/Service/LocalMenuService/AddNewSecondMenu.ashx',
                                method: 'POST',
                                params: {
                                    Id: currentParentId,
                                    name: text
                                },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info);
                                        window.viewModel.storeSecondMenu.load();
                                    } else {
                                        Ext.Msg.alert('Error', responseObj.info);
                                    }
                                },
                                failure: function (response, options) {
                                    Ext.Msg.alert('Error', 'add fail!');
                                }
                            });
                        }
                    } else {
                        return;
                    }
                });
            },
            firstMenuCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                    // cache current first btn id
                    window.viewModel.currentId = data.Id;

                    // load second panel
                    var secondStore = window.viewModel.storeSecondMenu;
                    secondStore.proxy.url = "/Service/LocalMenuService/GetLocalSecondMenu.ashx?Id=" + data.Id;
                    secondStore.load();

                    // load setting panel
                    Ext.Ajax.request({
                        url: '/Service/LocalMenuService/GetMenuButtonSetting.ashx',
                        method: 'POST',
                        params: { Id: data.Id },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                var data = responseObj.data;
                                window.viewModel.txtName.setRawValue(data.name);
                                window.viewModel.txtKey.setRawValue(data.key);
                                window.viewModel.txtUrl.setRawValue(data.url);
                                if (data.type == "click") {
                                    window.viewModel.rdoClick.setRawValue(true);
                                } else if (data.type == "view") {
                                    window.viewModel.rdoView.setRawValue(true);
                                } else {
                                    window.viewModel.rdoNone.setRawValue(true);
                                }
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'load setting fail!');
                        }
                    });
                } else if (commandName == "delete") {
                    Ext.Msg.confirm('Warning', 'make sure to delete this menu button?', function (btn) {
                        if (btn == "yes") {
                            Ext.Ajax.request({
                                url: '/Service/LocalMenuService/DeleteFirstMenu.ashx',
                                method: 'POST',
                                params: { Id: data.Id },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info, function () {
                                            window.viewModel.storeFirstMenu.load();
                                        });
                                    } else {
                                        Ext.Msg.alert('Error', responseObj.info);
                                    }
                                },
                                failure: function (response, options) {
                                    Ext.Msg.alert('Error', 'delete the menu error!');
                                }
                            });
                        } else {
                            return;
                        }
                    });
                }


                window.temp = parameters;
            },
            secondMenuCommandClickCommand: function (parameters) {
            },
            saveSettingCommand: function (parameters) {
            }
        };
    });
}());

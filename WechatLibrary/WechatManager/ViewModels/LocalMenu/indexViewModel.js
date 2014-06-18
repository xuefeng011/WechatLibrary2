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
            currentLevel: 0,
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
                        if (text.length > 4) {
                            Ext.Msg.alert('Error', '一级菜单按钮最多 4 个汉字');
                            return;
                        }

                        Ext.Ajax.request({
                            url: '/Service/LocalMenuService/AddNewFirstMenu.ashx',
                            method: 'POST',
                            params: {
                                name: text
                            },
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
                        if (text.length > 7) {
                            Ext.Msg.alert('Error', '二级菜单按钮最多 7 个汉字');
                            return;
                        }
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
            firstMenuModifyCommand: function (parameters) {
                var data = parameters[3].data;

                // cache current first btn id
                window.viewModel.currentId = data.Id;

                // cache current level.
                window.viewModel.currentLevel = 1;

                // load second panel
                var secondStore = window.viewModel.storeSecondMenu;
                secondStore.proxy.url = "/Service/LocalMenuService/GetLocalSecondMenu.ashx?Id=" + data.Id;
                secondStore.load();

                // load setting panel
                Ext.Ajax.request({
                    url: '/Service/LocalMenuService/GetMenuButtonSetting.ashx',
                    method: 'POST',
                    params: {
                        Id: data.Id
                    },
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
                                window.viewModel.rdoView.setRawValue(false);
                                window.viewModel.rdoNone.setRawValue(false);
                            } else if (data.type == "view") {
                                window.viewModel.rdoView.setRawValue(true);
                                window.viewModel.rdoClick.setRawValue(false);
                                window.viewModel.rdoNone.setRawValue(false);
                            } else {
                                window.viewModel.rdoNone.setRawValue(true);
                                window.viewModel.rdoClick.setRawValue(false);
                                window.viewModel.rdoView.setRawValue(false);
                            }
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'load setting fail!');
                    }
                });
            },
            firstMenuCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                    // cache current first btn id
                    window.viewModel.currentId = data.Id;

                    // cache current level.
                    window.viewModel.currentLevel = 1;

                    // load second panel
                    var secondStore = window.viewModel.storeSecondMenu;
                    secondStore.proxy.url = "/Service/LocalMenuService/GetLocalSecondMenu.ashx?Id=" + data.Id;
                    secondStore.load();

                    // load setting panel
                    Ext.Ajax.request({
                        url: '/Service/LocalMenuService/GetMenuButtonSetting.ashx',
                        method: 'POST',
                        params: {
                            Id: data.Id
                        },
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
                                    window.viewModel.rdoView.setRawValue(false);
                                    window.viewModel.rdoNone.setRawValue(false);
                                } else if (data.type == "view") {
                                    window.viewModel.rdoView.setRawValue(true);
                                    window.viewModel.rdoClick.setRawValue(false);
                                    window.viewModel.rdoNone.setRawValue(false);
                                } else {
                                    window.viewModel.rdoNone.setRawValue(true);
                                    window.viewModel.rdoClick.setRawValue(false);
                                    window.viewModel.rdoView.setRawValue(false);
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
                                params: {
                                    Id: data.Id
                                },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info, function () {
                                            // Reload store.
                                            window.viewModel.storeFirstMenu.load();
                                            // Clear store.
                                            window.viewModel.storeSecondMenu.proxy.url = "/Service/LocalMenuService/GetLocalSecondMenu.ashx";
                                            window.viewModel.storeSecondMenu.load();
                                            // Clear up button selected.
                                            window.viewModel.currentId = "";
                                            // Clear textbox.
                                            window.viewModel.txtName.setRawValue('');
                                            window.viewModel.txtKey.setRawValue('');
                                            window.viewModel.txtUrl.setRawValue('');
                                            // Clear radio button.
                                            window.viewModel.rdoClick.setRawValue(false);
                                            window.viewModel.rdoView.setRawValue(false);
                                            window.viewModel.rdoNone.setRawValue(false);
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
            },
            secondMenuModifyCommand: function (parameters) {
                var data = parameters[3].data;

                // cache current first btn id
                window.viewModel.currentId = data.Id;

                // cache current level.
                window.viewModel.currentLevel = 2;

                // load setting panel
                Ext.Ajax.request({
                    url: '/Service/LocalMenuService/GetMenuButtonSetting.ashx',
                    method: 'POST',
                    params: {
                        Id: data.Id
                    },
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
                                window.viewModel.rdoView.setRawValue(false);
                                window.viewModel.rdoNone.setRawValue(false);
                            } else if (data.type == "view") {
                                window.viewModel.rdoView.setRawValue(true);
                                window.viewModel.rdoClick.setRawValue(false);
                                window.viewModel.rdoNone.setRawValue(false);
                            } else {
                                window.viewModel.rdoNone.setRawValue(true);
                                window.viewModel.rdoClick.setRawValue(false);
                                window.viewModel.rdoView.setRawValue(false);
                            }
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'load setting fail!');
                    }
                });
            },
            secondMenuCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                    // cache current first btn id
                    window.viewModel.currentId = data.Id;

                    // cache current level.
                    window.viewModel.currentLevel = 2;

                    // load setting panel
                    Ext.Ajax.request({
                        url: '/Service/LocalMenuService/GetMenuButtonSetting.ashx',
                        method: 'POST',
                        params: {
                            Id: data.Id
                        },
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
                                    window.viewModel.rdoView.setRawValue(false);
                                    window.viewModel.rdoNone.setRawValue(false);
                                } else if (data.type == "view") {
                                    window.viewModel.rdoView.setRawValue(true);
                                    window.viewModel.rdoClick.setRawValue(false);
                                    window.viewModel.rdoNone.setRawValue(false);
                                } else {
                                    window.viewModel.rdoNone.setRawValue(true);
                                    window.viewModel.rdoClick.setRawValue(false);
                                    window.viewModel.rdoView.setRawValue(false);
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
                    Ext.Msg.confirm('Warning', 'make sure to delete the button?', function (btn) {
                        if (btn == 'yes') {
                            Ext.Ajax.request({
                                url: '/Service/LocalMenuService/DeleteSecondMenu.ashx',
                                method: 'POST',
                                params: { Id: data.Id },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info, function () {
                                            // Reload store.
                                            window.viewModel.storeFirstMenu.load();
                                            // Clear store.
                                            window.viewModel.secondStore.proxy.url = "/Service/LocalMenuService/GetLocalSecondMenu.ashx";
                                            window.viewModel.storeSecondMenu.load();
                                            // Clear up button selected.
                                            window.viewModel.currentId = "";
                                            // Clear textbox.
                                            window.viewModel.txtName.setRawValue('');
                                            window.viewModel.txtKey.setRawValue('');
                                            window.viewModel.txtUrl.setRawValue('');
                                            // Clear radio button.
                                            window.viewModel.rdoClick.setRawValue(false);
                                            window.viewModel.rdoView.setRawValue(false);
                                            window.viewModel.rdoNone.setRawValue(false);
                                        });
                                    } else {
                                        Ext.Msg.alert('Error', responseObj.info);
                                    }
                                },
                                failure: function (response, options) {
                                    Ext.Msg.alert('Error', 'delete failed!');
                                }
                            });
                        } else {
                            return;
                        }
                    });
                }
            },
            saveSettingCommand: function (parameters) {
                var currentId = window.viewModel.currentId;
                if (currentId == "" || currentId == null) {
                    Ext.Msg.alert('Error', 'please click select a button first!');
                    return;
                }
                var name = window.viewModel.txtName.getRawValue();

                if (window.viewModel.currentLevel == 1) {
                    if (name.length > 4) {
                        Ext.Msg.alert('Error', '一级菜单名字不能超过 4 个汉字。');
                        return;
                    }
                } else if (window.viewModel.currentLevel == 2) {
                    if (name.length > 7) {
                        Ext.Msg.alert('Error', '二级菜单名字不能超过 7 个汉字。');
                        return;
                    }
                }

                var type;
                if (window.viewModel.rdoClick.checked) {
                    type = "click";
                } else if (window.viewModel.rdoView.checked) {
                    type = "view";
                } else {
                    type = "none";
                }
                var key = window.viewModel.txtKey.getRawValue();
                var url = window.viewModel.txtUrl.getRawValue();
                Ext.Ajax.request({
                    url: '/Service/LocalMenuService/SubmitMenuButtonSetting.ashx',
                    method: 'POST',
                    params: {
                        Id: currentId,
                        name: name,
                        type: type,
                        key: key,
                        url: url
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info);
                            window.viewModel.storeFirstMenu.load();
                            window.viewModel.storeSecondMenu.load();
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'save setting fail!');
                    }
                });
            }
        };
    });
}());

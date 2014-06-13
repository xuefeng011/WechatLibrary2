(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            addWindow: Ext.getCmp('addWindow'),
            modifyWindow: Ext.getCmp('modifyWindow'),
            txtNewTextMatch: Ext.getCmp('txtNewTextMatch'),
            storeTextMatches: Ext.StoreManager.get('storeTextMatches'),
            txtModifyTextMatchContent: Ext.getCmp('txtModifyTextMatchContent'),
            cmbModifyTextMatchOption: Ext.getCmp('cmbModifyTextMatchOption'),
            cmbResponseType: Ext.getCmp('cmbResponseType'),
            cmbResponseTextMessage: Ext.getCmp('cmbResponseTextMessage'),
            cmbResponseImageMessage: Ext.getCmp('cmbResponseImageMessage'),
            cmbResponseNewsMessage: Ext.getCmp('cmbResponseNewsMessage'),
            txtModifyTextMatchLevel: Ext.getCmp('txtModifyTextMatchLevel'),
            cmbResponseTypeSelected: function (parameters) {
                var selectedValue = window.viewModel.cmbResponseType.value;
                if (selectedValue == '文本') {
                    // Set combobox visible.
                    window.viewModel.cmbResponseTextMessage.show();
                    window.viewModel.cmbResponseImageMessage.hide();
                    window.viewModel.cmbResponseNewsMessage.hide();
                    // Load Text Messages From Data Base.
                    Ext.Ajax.request({
                        url: '/Service/TextRequestMatchService/LoadTextResults.ashx',
                        method: 'POST',
                        params: {
                            Id: window.viewModel.modifyWindow.modifyId
                        },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                var data = responseObj.data;
                                /* Remove the combobox old datas.*/
                                while (window.viewModel.cmbResponseTextMessage.store.getCount() > 0) {
                                    window.viewModel.cmbResponseTextMessage.removeByIndex(0);
                                }
                                for (var i = 0; i < data.length; i++) {
                                    /* The first parameter is the display field and the second parameter is the value field. */
                                    window.viewModel.cmbResponseTextMessage.addItem(data[i].Content, data[i].Id);
                                }
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'load text resources fail!');
                        }
                    });
                } else if (selectedValue == '图片') {
                    // Set combobox visible.
                    window.viewModel.cmbResponseTextMessage.hide();
                    window.viewModel.cmbResponseImageMessage.show();
                    window.viewModel.cmbResponseNewsMessage.hide();
                    // Load Image Messages From Data Base.
                    Ext.Ajax.request({
                        url: '/Service/TextRequestMatchService/LoadImageResults.ashx',
                        method: 'POST',
                        params: {
                            Id: window.viewModel.modifyWindow.modifyId
                },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                var data = responseObj.data;
                                /* Remove the combobox old datas.*/
                                while (window.viewModel.cmbResponseImageMessage.store.getCount()>0) {
                                    window.viewModel.cmbResponseImageMessage.removeByIndex(0);
                                }
                                for (var i = 0; i < data.length; i++) {
                                    /* The first parameter is the display field and the second parameter is the value field. */
                                    window.viewModel.cmbResponseImageMessage.addItem(data[i].MediaId,data[i].Id);
                                }
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'Load image resources fail!');
                        }
                    });
                } else if (selectedValue == '图文') {
                    // Set combobox visible.
                    window.viewModel.cmbResponseTextMessage.hide();
                    window.viewModel.cmbResponseImageMessage.hide();
                    window.viewModel.cmbResponseNewsMessage.show();
                    // Load News Message From Data Base.
                }
            },
            addNewWehcatTextRequestMatchCommand: function (parameters) {
                window.viewModel.txtNewTextMatch.setRawValue('');
                window.viewModel.addWindow.show();
            },
            submitModify: function (parameters) {
                var matchContent = window.viewModel.txtModifyTextMatchContent.getValue();

                var matchOption = window.viewModel.cmbModifyTextMatchOption.value;
                if (matchOption == '完全匹配') {
                    matchOption = 'equals';
                } else if (matchOption == '不区分大小写完全匹配') {
                    matchOption = 'equalsignore';
                } else if (matchOption == '部分匹配') {
                    matchOption = 'contains';
                } else if (matchOption == '不区分大小写部分匹配') {
                    matchOption = 'containsignore';
                } else {
                    Ext.Msg.alert('Error', 'match option must select!');
                    return;
                }

                var matchLevel = window.viewModel.txtModifyTextMatchLevel.getValue();

                var isLevelValidate = parseInt(matchLevel) == matchLevel && parseInt(matchLevel) > 0;
                if (isLevelValidate == false) {
                    Ext.Msg.alert('Error', 'match level must be integer and must bigger than zero.');
                    return;
                }

                var responseType = window.viewModel.cmbResponseType.value;
                if (responseType != '文本' || responseType != '图片' || responseType != '图文') {
                    Ext.Msg.alert('Error', 'Auto response type must selected!');
                    return;
                }

                alert('submit');
            },
            saveNewWechatTextRequestMatchCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Service/TextRequestMatchService/Add.ashx',
                    method: 'POST',
                    params: {
                        Content: window.viewModel.txtNewTextMatch.getRawValue()
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.storeTextMatches.load();
                                window.viewModel.addWindow.close();
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'add failed!');
                    }
                });
            },
            textMatchesCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                    Ext.Ajax.request({
                        url: '/Service/TextRequestMatchService/GetById.ashx',
                        method: 'POST',
                        params: { Id: data.Id },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                // Get the text match data from json object.
                                var data = responseObj.data;

                                // Set each control value;
                                window.viewModel.txtModifyTextMatchContent.setRawValue(data.MatchContent);
                                var matchOption = data.MatchOption;
                                if (matchOption == 'equals') {
                                    window.viewModel.cmbModifyTextMatchOption.select('完全匹配');
                                } else if (matchOption == 'equalsignore') {
                                    window.viewModel.cmbModifyTextMatchOption.select('不区分大小写完全匹配');
                                } else if (matchOption == 'contains') {
                                    window.viewModel.cmbModifyTextMatchOption.select('部分匹配');
                                } else if (matchOption == 'containsignore') {
                                    window.viewModel.cmbModifyTextMatchOption.select('不区分大小写部分匹配');
                                } else {
                                    window.viewModel.cmbModifyTextMatchOption.select('');
                                }
                                window.viewModel.txtModifyTextMatchLevel.setRawValue(data.MatchLevel);
                                // Cache the modify item id.
                                window.viewModel.modifyWindow.modifyId = data.Id;

                                // Show the setting window.
                                window.viewModel.modifyWindow.show();
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'load information fail!');
                        }
                    });
                } else if (commandName == "delete") {
                    Ext.Msg.confirm('Warning', 'make sure to delete this match?', function (btn) {
                        if (btn == 'yes') {
                            Ext.Ajax.request({
                                url: '/Service/TextRequestMatchService/Delete.ashx',
                                method: 'POST',
                                params: {
                                    Id: data.Id
                                },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info, function () {
                                            // Refresh the grid panel.
                                            window.viewModel.storeTextMatches.load();
                                        });
                                    } else {
                                        Ext.Msg.alert('Error', responseObj.info);
                                    }
                                },
                                failure: function (response, options) {
                                    Ext.Msg.alert('Error', 'delete fail!');
                                }
                            });
                        }
                    });
                }
            }
        };
    });
}());
